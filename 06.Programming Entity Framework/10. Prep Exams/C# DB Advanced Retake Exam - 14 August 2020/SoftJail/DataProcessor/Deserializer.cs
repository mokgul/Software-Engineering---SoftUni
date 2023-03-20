using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using SoftJail.Data.Models;
using SoftJail.Data.Models.Enums;
using SoftJail.DataProcessor.ImportDto;

namespace SoftJail.DataProcessor
{
    using System.ComponentModel.DataAnnotations;

    using Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";

        private const string SuccessfullyImportedDepartment = "Imported {0} with {1} cells";

        private const string SuccessfullyImportedPrisoner = "Imported {0} {1} years old";

        private const string SuccessfullyImportedOfficer = "Imported {0} ({1} prisoners)";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            ImportDepartmentsCellsDto[] departments = JsonConvert.DeserializeObject<ImportDepartmentsCellsDto[]>(jsonString)!;

            StringBuilder sb = new StringBuilder();

            foreach (var dep in departments)
            {
                if (!IsValid(dep) || !dep.Cells.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Department department = new Department() { Name = dep.Name };
                bool invalidCell = false;
                foreach (var cell in dep.Cells)
                {
                    if (!IsValid(cell))
                    {
                        sb.AppendLine(ErrorMessage);
                        invalidCell = true;
                        break;
                    }

                    Cell currentCell = new Cell()
                    {
                        CellNumber = cell.CellNumber,
                        HasWindow = cell.HasWindow,
                        Department = department,
                        DepartmentId = department.Id,
                    };
                    department.Cells.Add(currentCell);
                }
                if (invalidCell) continue;
                context.Departments.Add(department);
                sb.AppendLine(string.Format(SuccessfullyImportedDepartment, department.Name, department.Cells.Count));
            }
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            ImportPrisonersAndMailsDto[] prisoners =
                JsonConvert.DeserializeObject<ImportPrisonersAndMailsDto[]>(jsonString)!;

            StringBuilder sb = new StringBuilder();

            foreach (var prisoner in prisoners)
            {
                if (!IsValid(prisoner))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Prisoner currPrisoner = new Prisoner()
                {
                    FullName = prisoner.FullName,
                    Nickname = prisoner.Nickname,
                    Age = prisoner.Age,
                    IncarcerationDate = DateTime.ParseExact(prisoner.IncarcerationDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture),
                    ReleaseDate = prisoner.ReleaseDate == null ? null : DateTime.ParseExact(prisoner.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Bail = prisoner.Bail,
                    CellId = prisoner.CellId
                };
                bool invalidMail = false;
                foreach (var mail in prisoner.Mails)
                {
                    if (!IsValid(mail))
                    {
                        sb.AppendLine(ErrorMessage);
                        invalidMail = true;
                        break;
                    }

                    Mail currMail = new Mail()
                    {
                        Description = mail.Description,
                        Sender = mail.Sender,
                        Address = mail.Address,
                    };
                    currPrisoner.Mails.Add(currMail);
                }
                if (invalidMail) continue;
                context.Prisoners.Add(currPrisoner);
                sb.AppendLine(string.Format(SuccessfullyImportedPrisoner, currPrisoner.FullName, currPrisoner.Age.ToString()));
            }
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            ImportOfficersAndPrisonersDto[] officers =
                Deserialize<ImportOfficersAndPrisonersDto[]>(xmlString, "Officers");

            StringBuilder sb = new StringBuilder();

            foreach (var officer in officers)
            {
                if (!IsValid(officer))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if(!Enum.IsDefined(typeof(Position), officer.Position) || 
                   !Enum.IsDefined(typeof(Weapon), officer.Weapon))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Officer currOfficer = new Officer()
                {
                    FullName = officer.FullName,
                    Salary = officer.Salary,
                    Position = Enum.Parse<Position>(officer.Position),
                    Weapon = Enum.Parse<Weapon>(officer.Weapon),
                    DepartmentId = officer.DepartmendId
                };
                foreach (var prisoner in officer.PrisonerIds)
                {
                    var currPrisoner = new OfficerPrisoner()
                    {
                        Officer = currOfficer,
                        OfficerId = currOfficer.Id,
                        Prisoner = context.Prisoners.FirstOrDefault(p => p.Id == prisoner.Id)!,
                        PrisonerId = prisoner.Id,
                    };
                    currOfficer.OfficerPrisoners.Add(currPrisoner);
                }
                context.Officers.Add(currOfficer);
                sb.AppendLine(string.Format(SuccessfullyImportedOfficer, currOfficer.FullName,
                    currOfficer.OfficerPrisoners.Count()));
            }

            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
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