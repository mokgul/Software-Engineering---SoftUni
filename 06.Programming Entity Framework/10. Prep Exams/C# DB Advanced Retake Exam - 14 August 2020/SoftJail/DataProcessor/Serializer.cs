using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SoftJail.DataProcessor.ExportDto;

namespace SoftJail.DataProcessor
{
    using Data;
    using System.Linq;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(p => ids.Contains(p.Id))
                .Select(p => new ExportPrisonersByCellsDto()
                {
                    PrisonerId = p.Id,
                    PrisonerName = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                        .Where(o => o.PrisonerId == p.Id)
                        .Select(o => new ExportOfficerDto()
                        {
                            OfficerName = o.Officer.FullName,
                            Department = o.Officer.Department.Name
                        })
                        .OrderBy(o => o.OfficerName)
                        .ToArray(),
                    TotalOfficerSalary = p.PrisonerOfficers
                        .Where(o => o.PrisonerId == p.Id)
                        .Sum(of => of.Officer.Salary)
                })
                .OrderBy(p => p.PrisonerName)
                .ThenBy(p => p.PrisonerId)
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(prisoners, Formatting.Indented);
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
           string[] Prisoners = prisonersNames.Split(',');

           var messages = context.Prisoners
               .Where(p => Prisoners.Contains(p.FullName))
               .Select(pr => new ExportPrisonersInboxDto()
               {
                   PrisonerId = pr.Id,
                   PrisonerName = pr.FullName,
                   IncarcerationDate = pr.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                   Messages = pr.Mails
                       .Select(m => new ExportMessageDto()
                       {
                           Description = Reverse(m.Description),
                       })
                       .ToArray()
               })
               .OrderBy(p => p.PrisonerName)
               .ThenBy(p => p.PrisonerId)
               .AsNoTracking()
               .ToArray();

           return Serialize(messages, "Prisoners");
        }

        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
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