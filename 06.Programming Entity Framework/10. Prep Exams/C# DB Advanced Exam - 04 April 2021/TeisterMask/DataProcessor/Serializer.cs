using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using TeisterMask.DataProcessor.ExportDto;

namespace TeisterMask.DataProcessor
{
    using Data;

    public class Serializer
    {
        [SuppressMessage("ReSharper.DPA", "DPA0007: Large number of DB records", MessageId = "count: 1124")]
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects
                .Where(p => p.Tasks.Any())
                .ToArray()
                .Select(p => new ExportProjectWithTheirTasksDto()
                {
                    TasksCount = p.Tasks.Count(),
                    ProjectName = p.Name,
                    HasEndDate = p.DueDate == null ? "No" : "Yes",
                    Tasks = p.Tasks
                        .Select(t => new ExportTaskProjectDto()
                        {
                            Name = t.Name,
                            Label = t.LabelType.ToString(),
                        })
                        .OrderBy(n => n.Name)
                        .ToArray()
                })
                .OrderByDescending(c => c.TasksCount)
                .ThenBy(n => n.ProjectName)
                .ToArray();

            return Serialize<ExportProjectWithTheirTasksDto[]>(projects, "Projects");
        }

        [SuppressMessage("ReSharper.DPA", "DPA0007: Large number of DB records", MessageId = "count: 1085")]
        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .Where(e => e.EmployeesTasks.Any() && e.EmployeesTasks.Any(d => d.Task.OpenDate >= date))
                .ToArray()
                .Select(e => new ExportMostBusiestEmployeesDto()
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                        .Where(d => d.Task.OpenDate >= date)
                        .OrderByDescending(d => d.Task.DueDate)
                        .ThenBy(n => n.Task.Name)
                        .Select(t => new ExportTaskDto()
                        {
                            TaskName = t.Task.Name,
                            OpenDate = t.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                            DueDate = t.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            LabelType = t.Task.LabelType.ToString(),
                            ExecutionType = t.Task.ExecutionType.ToString(),
                        })
                        .ToArray()
                })
                .OrderByDescending(c => c.Tasks.Count())
                .ThenBy(u => u.Username)
                .Take(10);

            return JsonConvert.SerializeObject(employees, Formatting.Indented);
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