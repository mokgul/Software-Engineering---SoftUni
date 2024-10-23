using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VaporStore.Data.Models.Enums;
using VaporStore.DataProcessor.ExportDto;

namespace VaporStore.DataProcessor
{
    using Data;
    using System.Text;
    using System.Xml.Serialization;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var games = context.Genres
                .Where(g => genreNames.Contains(g.Name)
                            && g.Games.Any())
                .Select(g => new ExportGamesByGenresDto()
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games
                        .Where(g => g.Purchases.Any())
                        .Select(gg => new ExportGameDto()
                        {
                            Id = gg.Id,
                            Title = gg.Name,
                            DeveloperName = gg.Developer.Name,
                            Tags = string.Join(", ", gg.GameTags.Select(n => n.Tag.Name)),
                            PlayersCount = gg.Purchases.Count()
                        })
                        .OrderByDescending(p => p.PlayersCount)
                        .ThenBy(i => i.Id)
                        .ToArray(),
                    TotalPlayers = g.Games.SelectMany(gg => gg.Purchases).Count()
                })
                .OrderByDescending(c => c.TotalPlayers)
                .ThenBy(g => g.Id)
                .ToArray();

            return JsonConvert.SerializeObject(games, Formatting.Indented);
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string purchaseType)
        {
            var type = Enum.Parse<PurchaseType>(purchaseType);

            var users = context.Users
                .ToArray()
                .Where(u => u.Cards.Any(c => c.Purchases.Any(p => p.Type == type)))
                .Select(u => new ExportUserPurchasesByType()
                {
                    Username = u.Username,
                    Purchases = u.Cards.SelectMany(c => c.Purchases)
                        .Where(p => p.Type == type)
                        .Select(p => new ExportPurchaseDto()
                        {
                            Card = p.Card.Number,
                            Cvc = p.Card.Cvc,
                            Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game = new ExportGameXMLDto()
                            {
                                Title = p.Game.Name,
                                Genre = p.Game.Genre.Name,
                                Price = p.Game.Price,
                            }
                        })
                        .OrderBy(p => p.Date)
                        .ToArray(),
                    TotalSpent = u.Cards
                        .Sum(c => c.Purchases
                            .Where(p => p.Type == type)
                            .Sum(p => p.Game.Price))
                })
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToArray();

            return Serialize<ExportUserPurchasesByType[]>(users, "Users");
        }

        private static string Serialize<T>(T dataTransferObjects, string xmlRootAttributeName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttributeName));

            StringBuilder sb = new StringBuilder();
            using var write = new StringWriter(sb);

            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);

            serializer.Serialize(write, dataTransferObjects, xmlNamespaces);

            return sb.ToString();
        }
    }
}