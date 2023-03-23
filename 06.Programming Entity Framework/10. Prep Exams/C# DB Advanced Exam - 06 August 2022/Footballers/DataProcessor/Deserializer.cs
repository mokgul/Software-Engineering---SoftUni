using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using Footballers.Data.Models;
using Footballers.Data.Models.Enums;
using Footballers.DataProcessor.ImportDto;
using Newtonsoft.Json;

namespace Footballers.DataProcessor
{
    using Footballers.Data;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            ImportCoachesDto[] coaches = Deserialize<ImportCoachesDto[]>(xmlString, "Coaches");

            StringBuilder sb = new StringBuilder();

            foreach (var coach in coaches)
            {
                if (!IsValid(coach) || string.IsNullOrEmpty(coach.Nationality))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Coach currCoach = new Coach()
                {
                    Name = coach.Name,
                    Nationality = coach.Nationality
                };
                foreach (var f in coach.Footballers)
                {
                    bool startDate = DateTime.TryParseExact(f.ContractStartDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime start);

                    bool endDate = DateTime.TryParseExact(f.ContractEndDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime end);

                    if (!IsValid(f) || !startDate || !endDate || start > end )
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Footballer footballer = new Footballer()
                    {
                        Name = f.Name,
                        ContractStartDate = start,
                        ContractEndDate = end,
                        BestSkillType = Enum.Parse<BestSkillType>(f.BestSkillType),
                        PositionType = Enum.Parse<PositionType>(f.PositionType)
                    };
                    currCoach.Footballers.Add(footballer);
                }
                context.Coaches.Add(currCoach);
                sb.AppendLine(string.Format(SuccessfullyImportedCoach, currCoach.Name, currCoach.Footballers.Count()));
            }

            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            ImportTeamsDto[] teams = JsonConvert.DeserializeObject<ImportTeamsDto[]>(jsonString)!;

            StringBuilder sb = new StringBuilder();

            foreach (var team in teams)
            {
                if (!IsValid(team) || team.Trophies == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Team currTeam = new Team()
                {
                    Name = team.Name,
                    Nationality = team.Nationality,
                    Trophies = team.Trophies
                };
                foreach (var currId in team.FootballersIds.Distinct())
                {
                    bool footballerInDb = context.Footballers.Any(f => f.Id == currId);
                    if (!IsValid(currId) || !footballerInDb)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    TeamFootballer tf = new TeamFootballer()
                    {
                        Team = currTeam,
                        TeamId = currTeam.Id,
                        Footballer = context.Footballers.First(f => f.Id == currId),
                        FootballerId = context.Footballers.First(f => f.Id == currId).Id,
                    };
                    currTeam.TeamsFootballers.Add(tf);
                    
                }
                context.Teams.Add(currTeam);
                sb.AppendLine(string.Format(SuccessfullyImportedTeam, currTeam.Name, currTeam.TeamsFootballers.Count));
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
