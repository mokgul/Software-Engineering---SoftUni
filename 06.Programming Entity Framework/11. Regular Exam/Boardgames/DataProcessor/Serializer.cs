using System.Diagnostics.CodeAnalysis;
using Boardgames.DataProcessor.ExportDto;
using Newtonsoft.Json;

namespace Boardgames.DataProcessor
{
    using Data;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        [SuppressMessage("ReSharper.DPA", "DPA0007: Large number of DB records", MessageId = "count: 267")]
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            var creators = context.Creators
                .Where(c => c.Boardgames.Any())
                .ToArray()
                .Select(c => new ExportCreatorsWithTheirBoardgamesDto()
                {
                    BoardgamesCount = c.Boardgames.Count,
                    CreatorName = c.FirstName + " " + c.LastName,
                    Boardgames = c.Boardgames
                        .Select(b => new ExportBoardgameCreatorDto()
                        {
                            BoardgameName = b.Name,
                            BoardgameYearPublished = b.YearPublished,
                        })
                        .OrderBy(n => n.BoardgameName)
                        .ToArray()
                })
                .OrderByDescending(c => c.BoardgamesCount)
                .ThenBy(n => n.CreatorName)
                .ToArray();

            return Serialize<ExportCreatorsWithTheirBoardgamesDto[]>(creators, "Creators");
        }

        [SuppressMessage("ReSharper.DPA", "DPA0007: Large number of DB records", MessageId = "count: 278")]
        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context.Sellers
                .Where(s => s.BoardgamesSellers.Any()
                            && s.BoardgamesSellers.Any(y => y.Boardgame.YearPublished >= year)
                            && s.BoardgamesSellers.Any(r => r.Boardgame.Rating <= rating))
                .ToArray()
                .Select(b => new ExportSellersWithMostBoardgamesDto()
                {
                    Name = b.Name,
                    Website = b.Website,
                    Boardgames = b.BoardgamesSellers
                        .Where(y => y.Boardgame.YearPublished >= year && y.Boardgame.Rating <= rating)
                        .Select(b => new ExportBoardgameDto()
                        {
                            Name = b.Boardgame.Name,
                            Rating = b.Boardgame.Rating,
                            Mechanics = b.Boardgame.Mechanics,
                            Category = b.Boardgame.CategoryType.ToString(),
                        })
                        .OrderByDescending(r => r.Rating)
                        .ThenBy(n => n.Name)
                        .ToArray()
                })
                .OrderByDescending(b => b.Boardgames.Count())
                .ThenBy(n => n.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(sellers, Formatting.Indented);
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