using System.Text;
using System.Xml.Serialization;
using Boardgames.Data.Models;
using Boardgames.Data.Models.Enums;
using Boardgames.DataProcessor.ImportDto;
using Newtonsoft.Json;

namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using Data;
   
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            ImportCreatorsDto[] creators = Deserialize<ImportCreatorsDto[]>(xmlString, "Creators");

            StringBuilder sb = new StringBuilder();

            foreach (var creator in creators)
            {
                if (!IsValid(creator))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Creator currCreator = new Creator()
                {
                    FirstName = creator.FirstName,
                    LastName = creator.LastName,
                };
                foreach (var bg in creator.Boardgames)
                {
                    if (!IsValid(bg))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Boardgame boardgame = new Boardgame()
                    {
                        Name = bg.Name,
                        Rating = bg.Rating,
                        YearPublished = bg.YearPublished,
                        CategoryType = Enum.Parse<CategoryType>(bg.CategoryType),
                        Mechanics = bg.Mechanics
                    };
                    currCreator.Boardgames.Add(boardgame);
                }
                context.Creators.Add(currCreator);
                sb.AppendLine(string.Format(SuccessfullyImportedCreator, currCreator.FirstName, currCreator.LastName,
                    currCreator.Boardgames.Count));
            }

            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            ImportSellersDto[] sellers = JsonConvert.DeserializeObject<ImportSellersDto[]>(jsonString)!;

            StringBuilder sb = new StringBuilder();

            foreach (var seller in sellers)
            {
                if (!IsValid(seller))
                {
                    sb.AppendLine(ErrorMessage); 
                    continue;
                }

                Seller currSeller = new Seller()
                {
                    Name = seller.Name,
                    Address = seller.Address,
                    Country = seller.Country,
                    Website = seller.Website,
                };
                foreach (var id in seller.Boardgames.Distinct())
                {
                    if (context.Boardgames.FirstOrDefault(i => i.Id == id) == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    currSeller.BoardgamesSellers.Add(new BoardgameSeller()
                    {
                        Seller = currSeller,
                        SellerId = currSeller.Id,
                        Boardgame =  context.Boardgames.First(i => i.Id == id),
                        BoardgameId = id
                    });
                }

                context.Sellers.Add(currSeller);
                sb.AppendLine(string.Format(SuccessfullyImportedSeller, currSeller.Name,
                    currSeller.BoardgamesSellers.Count));
            }

            context.SaveChanges();
            return sb.ToString().TrimEnd();
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
