using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Theatre.Data.Models;
using Theatre.Data.Models.Enums;
using Theatre.DataProcessor.ImportDto;

namespace Theatre.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using Theatre.Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";



        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            ImportPlaysDto[] plays = Deserialize<ImportPlaysDto[]>(xmlString, "Plays");

            StringBuilder sb = new StringBuilder();

            foreach (var play in plays)
            {
                bool isGenreValid = Enum.TryParse(play.Genre, out Genre resultGenre);
                bool durationValid = TimeSpan.TryParseExact(play.Duration, "c", CultureInfo.InvariantCulture,
                    TimeSpanStyles.None, out TimeSpan duration);
                if (!IsValid(play)
                    || !isGenreValid
                    || !durationValid
                    || !(duration >= new TimeSpan(0, 1, 0, 0))
                   )
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                
                Play currPlay = new Play()
                {
                    Title = play.Title,
                    Duration = duration,
                    Rating = (float)play.Rating,
                    Genre = resultGenre,
                    Description = play.Description,
                    Screenwriter = play.Screenwriter,
                };
                context.Plays.Add(currPlay);
                sb.AppendLine(string.Format(SuccessfulImportPlay,currPlay.Title, currPlay.Genre, currPlay.Rating));
            }

            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            ImportCastsDto[] casts = Deserialize<ImportCastsDto[]>(xmlString, "Casts");

            StringBuilder sb = new StringBuilder();

            foreach (var cast in casts)
            {
                if (!IsValid(cast))
                {
                    sb.AppendLine(ErrorMessage); 
                    continue;
                }

                Cast currCast = new Cast()
                {
                    FullName = cast.FullName,
                    IsMainCharacter = cast.IsMainCharacter,
                    PhoneNumber = cast.PhoneNumber,
                    PlayId = cast.PlayId,
                };
                context.Casts.Add(currCast);
                sb.AppendLine(string.Format(SuccessfulImportActor, currCast.FullName,
                    currCast.IsMainCharacter ? "main" : "lesser"));
            }

            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            ImportProjectionsDto[] projections = JsonConvert.DeserializeObject<ImportProjectionsDto[]>(jsonString)!;

            StringBuilder sb = new StringBuilder();

            foreach (var item in projections)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Data.Models.Theatre theatre = new Data.Models.Theatre()
                {
                    Name = item.Name,
                    NumberOfHalls = (sbyte)item.NumberOfHalls,
                    Director = item.Director
                };
                foreach (var ticket in item.Tickets)
                {
                    if (!IsValid(ticket))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Ticket currTicket = new Ticket()
                    {
                        Price = ticket.Price,
                        RowNumber = (sbyte)ticket.RowNumber,
                        PlayId = ticket.PlayId,
                    };
                    theatre.Tickets.Add(currTicket);
                }

                context.Theatres.Add(theatre);
                sb.AppendLine(string.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count()));
            }

            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
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
