﻿using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.Data.Models.Enums;
using VaporStore.DataProcessor.ImportDto;

namespace VaporStore.DataProcessor
{
    using System.ComponentModel.DataAnnotations;

    using Data;

    public static class Deserializer
    {
        public const string ErrorMessage = "Invalid Data";

        public const string SuccessfullyImportedGame = "Added {0} ({1}) with {2} tags";

        public const string SuccessfullyImportedUser = "Imported {0} with {1} cards";

        public const string SuccessfullyImportedPurchase = "Imported {0} for {1}";

        [SuppressMessage("ReSharper.DPA", "DPA0000: DPA issues")]
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            ImportGamesDto[] games = JsonConvert.DeserializeObject<ImportGamesDto[]>(jsonString)!;

            StringBuilder sb = new StringBuilder();
            foreach (var game in games)
            {
                bool release = DateTime.TryParseExact(game.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime validReleaseDate);
                if (!IsValid(game)
                    || String.IsNullOrEmpty(game.Name)
                    || !release
                    || !game.Tags.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Genre genre = context.Genres.FirstOrDefault(g => g.Name == game.Genre);
                if (genre == null)
                {
                    genre = new Genre() { Name = game.Genre };
                    context.Genres.Add(genre);
                    //We use SaveChanges here cause when we try to look in the context the method looks at the original state of the context and not over changed ( aka the added genres ). The change tracker keeps the changes but we need to apply them in order to be able to check if there is an existing entity of the one we are looking for.
                    context.SaveChanges();
                }

                Developer developer = context.Developers.FirstOrDefault(g => g.Name == game.DeveloperName);
                if (developer == null)
                {
                    developer = new Developer() { Name = game.DeveloperName };
                    context.Developers.Add(developer);
                    context.SaveChanges();
                }


                Game currGame = new Game()
                {
                    Name = game.Name,
                    Price = game.Price,
                    ReleaseDate = validReleaseDate,
                    Genre = genre,
                    Developer = developer
                };
                
                foreach (var tag in game.Tags)
                {
                    if(string.IsNullOrEmpty(tag))
                        continue;
                    Tag currTag = context.Tags.FirstOrDefault(t => t.Name == tag);
                    if (currTag == null)
                    {
                        currTag = new Tag() { Name = tag };
                        context.Tags.Add(currTag);
                        context.SaveChanges();
                    }
                    
                    currGame.GameTags.Add(new GameTag(){Game = currGame, Tag = currTag});
                }

                context.Games.Add(currGame);
                sb.AppendLine(string.Format(SuccessfullyImportedGame, currGame.Name, currGame.Genre.Name, currGame.GameTags.Count));
            }

            // Here is a valid way to use SaveChanges() at the end, cause we do not try to check the current state of context.Games, we are just adding to the context. The change tracker keeps these changes ( the added entities ) and we save the changes at the end.
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            ImportUsersAndCardsDto[] users = JsonConvert.DeserializeObject<ImportUsersAndCardsDto[]>(jsonString)!;

            StringBuilder sb = new StringBuilder();

            foreach (var user in users)
            {
                if (!IsValid(user))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                User currUser = new User()
                {
                    FullName = user.FullName,
                    Username = user.Username,
                    Email = user.Email,
                    Age = user.Age
                };

                foreach (var card in user.Cards)
                {
                    if (!IsValid(card))
                    {
                        sb.Append(ErrorMessage);
                        continue;
                    }
                    currUser.Cards.Add(
                        new Card()
                        {
                            Number = card.CardNumber,
                            Cvc = card.Cvc,
                            Type = Enum.Parse<CardType>(card.CardType)
                        });
                }
                context.Users.Add(currUser);
                sb.AppendLine(string.Format(SuccessfullyImportedUser, currUser.Username, currUser.Cards.Count()));
            }
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        [SuppressMessage("ReSharper.DPA", "DPA0006: Large number of DB commands", MessageId = "count: 88")]
        [SuppressMessage("ReSharper.DPA", "DPA0007: Large number of DB records", MessageId = "count: 971")]
        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            ImportPurchasesDto[] purchases = Deserialize<ImportPurchasesDto[]>(xmlString, "Purchases");
            
            StringBuilder sb = new StringBuilder();

            foreach (var p in purchases)
            {
                if (!IsValid(p))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Purchase purchase = new Purchase()
                {
                    Game = context.Games.First(g => g.Name == p.Title),
                    Type = Enum.Parse<PurchaseType>(p.PurchaseType),
                    ProductKey = p.ProductKey,
                    Card = context.Cards.First(c => c.Number == p.Card),
                    Date = DateTime.ParseExact(p.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)
                };
                context.Purchases.Add(purchase);
                sb.AppendLine(string.Format(SuccessfullyImportedPurchase, purchase.Game.Name,
                    purchase.Card.User.Username));
            }

            context.SaveChanges();
            return sb.ToString().ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        private static T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute root = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), root);

            using StringReader reader = new StringReader(inputXml);

            T dtos = (T)serializer.Deserialize(reader);
            return dtos;
        }
    }
}