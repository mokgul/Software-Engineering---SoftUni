// ReSharper disable InconsistentNaming

using System.Globalization;
using System.Text;
using Newtonsoft.Json;
using TeisterMask.Data.Models;
using TeisterMask.Data.Models.Enums;
using TeisterMask.DataProcessor.ImportDto;
using Task = TeisterMask.Data.Models.Task;

namespace TeisterMask.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            ImportProjectsDto[] projects = Deserialize<ImportProjectsDto[]>(xmlString, "Projects");

            StringBuilder sb = new StringBuilder();

            foreach (var project in projects)
            {
                bool validOpenDate = DateTime.TryParseExact(project.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var openDate);
                bool validDueDate = DateTime.TryParseExact(project.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dueDate);
                if (!IsValid(project) || !validOpenDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Project currProject = new Project()
                {
                    Name = project.Name,
                    OpenDate = openDate,
                    DueDate = validDueDate == false ? null : dueDate
                };
                foreach (var task in project.Tasks)
                {
                    bool validOpenDateTask = DateTime.TryParseExact(task.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var openDateTask);
                    bool validDueDateTask = DateTime.TryParseExact(task.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dueDateTask);

                    if (!IsValid(task)
                        || !validOpenDateTask
                        || !validDueDateTask
                        || (openDateTask < openDate)
                        || (currProject.DueDate != null && dueDateTask > dueDate))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task currTask = new Task()
                    {
                        Name = task.Name,
                        OpenDate = openDateTask,
                        DueDate = dueDateTask,
                        ExecutionType = Enum.Parse<ExecutionType>(task.ExecutionType),
                        LabelType = Enum.Parse<LabelType>(task.LabelType),
                    };
                    currProject.Tasks.Add(currTask);
                }
                context.Projects.Add(currProject);
                sb.AppendLine(string.Format(SuccessfullyImportedProject, currProject.Name, currProject.Tasks.Count));
            }

            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            ImportEmployeesDto[] employees = JsonConvert.DeserializeObject<ImportEmployeesDto[]>(jsonString)!;

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                if (!IsValid(employee))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Employee currEmployee = new Employee()
                {
                    Username = employee.Username,
                    Email = employee.EmailAddress,
                    Phone = employee.Phone
                };
                foreach (var id in employee.TaskIds.Distinct())
                {
                    if (context.Tasks.FirstOrDefault(i => i.Id == id) == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    currEmployee.EmployeesTasks.Add(new EmployeeTask()
                    {
                        Employee = currEmployee,
                        EmployeeId = currEmployee.Id,
                        Task = context.Tasks.First(i => i.Id == id),
                        TaskId = id
                    });
                }
                context.Employees.Add(currEmployee);
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, currEmployee.Username,
                    currEmployee.EmployeesTasks.Count));
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