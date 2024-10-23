using System.Globalization;
using System.Text;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni;

public class StartUp
{
    static void Main(string[] args)
    {
        SoftUniContext dbContext = new SoftUniContext();

        //03.
        //Console.WriteLine(GetEmployeesFullInformation(dbContext));

        //04.
        //Console.WriteLine(GetEmployeesWithSalaryOver50000(dbContext));

        //05.
        //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(dbContext));

        //06.
        //Console.WriteLine(AddNewAddressToEmployee(dbContext));

        //07.
        //Console.WriteLine(GetEmployeesInPeriod(dbContext));

        //08.
        //Console.WriteLine(GetAddressesByTown(dbContext));

        //09.
        //Console.WriteLine(GetEmployee147(dbContext));

        //10.
        //Console.WriteLine(GetDepartmentsWithMoreThan5Employees(dbContext));

        //11.
        //Console.WriteLine(GetLatestProjects(dbContext));

        //12.
        //Console.WriteLine(IncreaseSalaries(dbContext));

        //13.
        //Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(dbContext));

        //14.
        //Console.WriteLine(DeleteProjectById(dbContext));

        //15.
        Console.WriteLine(RemoveTown(dbContext));

    }

    //03. Employees Full Information
    //public static string GetEmployeesFullInformation(SoftUniContext context)
    //{
    //    StringBuilder sb = new StringBuilder();

    //    var employees = context.Employees
    //        .OrderBy(e => e.EmployeeId)
    //        .Select(e => new
    //        {
    //            e.FirstName,
    //            e.MiddleName,
    //            e.LastName,
    //            e.JobTitle,
    //            e.Salary
    //        })
    //        .ToArray();

    //    foreach (var emp in employees)
    //    {
    //        sb.AppendLine($"{emp.FirstName} {emp.LastName} {emp.MiddleName} {emp.JobTitle} {emp.Salary:f2}");
    //    }
    //    return sb.ToString().TrimEnd();
    //}

    //04. Employees with Salary Over 50 000
    //public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    //{
    //    StringBuilder sb = new StringBuilder();

    //    var employees = context.Employees
    //            .OrderBy(e => e.FirstName)
    //            .Select(e => new
    //            {
    //                e.FirstName,
    //                e.Salary
    //            })
    //            .Where(e => e.Salary > 50000)
    //            .ToArray();

    //    foreach (var emp in employees)
    //    {
    //        sb.AppendLine($"{emp.FirstName} - {emp.Salary:f2}");
    //    }
    //    return sb.ToString().TrimEnd();
    //}

    ////05. Employees from Research and Development
    //public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    //{
    //    StringBuilder sb = new StringBuilder();

    //    var employees = context.Employees
    //                .OrderBy(e => e.Salary)
    //                .ThenByDescending(e => e.FirstName)
    //                .Where(e => e.Department.Name == "Research and Development")
    //                .Select(e => new
    //                {
    //                    e.FirstName,
    //                    e.LastName,
    //                    e.Department.Name,
    //                    e.Salary
    //                })
    //                .ToArray();

    //    foreach (var emp in employees)
    //    {
    //        sb.AppendLine($"{emp.FirstName} {emp.LastName} from {emp.Name} - ${emp.Salary:f2}");
    //    }
    //    return sb.ToString().TrimEnd();
    //}

    //    //06. Adding a New Address and Updating Employee
    //    public static string AddNewAddressToEmployee(SoftUniContext context)
    //    {
    //        StringBuilder sb = new StringBuilder();

    //        Address address = new Address()
    //        {
    //            AddressText = "Vitoshka 15",
    //            TownId = 4
    //        };

    //        Employee? employee = context.Employees
    //            .FirstOrDefault(e => e.LastName == "Nakov");

    //        employee.Address = address;

    //        context.SaveChanges();

    //        var adressess = context.Employees
    //            .OrderByDescending(e => e.AddressId)
    //            .Take(10)
    //            .Select(e => e.Address.AddressText)
    //            .ToList();

    //        foreach (var item in adressess)
    //        {
    //            sb.AppendLine($"{item}");
    //        }
    //        return sb.ToString().TrimEnd();
    //    }
    //

    //07. Employees and Projects
    //public static string GetEmployeesInPeriod(SoftUniContext context)
    //{
    //    StringBuilder sb = new StringBuilder();

    //    var employees = context.Employees
    //        .Take(10)
    //        .Select(e => new
    //        {
    //            e.FirstName,
    //            e.LastName,
    //            ManagerFirst = e.Manager.FirstName,
    //            ManagerLast = e.Manager.LastName,
    //            Project = e.EmployeesProjects
    //                .Where(p => p.Project.StartDate.Year >= 2001 
    //                            && p.Project.StartDate.Year <= 2003)
    //                .Select(ep => new
    //                {
    //                    ProjectName = ep.Project.Name,
    //                    ProjStartDate = ep.Project.StartDate,
    //                    ProjectEndDate = ep.Project.EndDate,
    //                })
    //        });
    //    foreach (var emp in employees)
    //    {
    //        sb.AppendLine($"{emp.FirstName} {emp.LastName} - Manager: {emp.ManagerFirst} {emp.ManagerLast}");
    //        foreach (var item in emp.Project)
    //        {
    //            sb.AppendLine(item.ProjectEndDate.HasValue

    //            ? $"--{item.ProjectName} - {item.ProjStartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {item.ProjectEndDate.Value.ToString("M/d/yyyy h:mm:ss tt",CultureInfo.InvariantCulture)}"

    //                 :$"--{item.ProjectName} - {item.ProjStartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - not finished");
    //        }
    //    }
    //    return sb.ToString().TrimEnd();
    //}

    //08. Addresses by Town
    //public static string GetAddressesByTown(SoftUniContext context)
    //{
    //    StringBuilder sb = new StringBuilder();

    //    var addresses = context.Addresses
    //        .OrderByDescending(a => a.Employees.Count)
    //        .ThenBy(a => a.Town.Name)
    //        .ThenBy(a => a.AddressText)
    //        .Select(a => new
    //        {
    //            a.AddressText,
    //            TownName = a.Town.Name,
    //            Count = a.Employees.Count
    //        })
    //        .Take(10);

    //    foreach (var address in addresses)
    //    {
    //        sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.Count} employees");
    //    }
    //    return sb.ToString().TrimEnd();
    //}

    //09. Employee 147
    //public static string GetEmployee147(SoftUniContext context)
    //{
    //    StringBuilder sb = new StringBuilder();

    //    var employee = context.Employees
    //        .Where(e => e.EmployeeId == 147)
    //        .Select(e => new
    //        {
    //            e.FirstName,
    //            e.LastName,
    //            e.JobTitle,
    //            Projects = e.EmployeesProjects
    //                .OrderBy(ep => ep.Project.Name)
    //                .Select(ep => ep.Project.Name)
    //        });

    //    foreach (var item in employee)
    //    {
    //        sb.AppendLine($"{item.FirstName} {item.LastName} - {item.JobTitle}");

    //        foreach (var proj in item.Projects)
    //            sb.AppendLine($"{proj}");
    //    }
    //    return sb.ToString().TrimEnd();
    //}

    //10. Departments with More Than 5 Employees
    //    public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
    //    {
    //        StringBuilder sb = new StringBuilder();

    //        var employees = context.Departments
    //            .Where(c => c.Employees.Count > 5)
    //            .OrderBy(c => c.Employees.Count)
    //            .ThenBy(d => d.Name)
    //            .Select(e => new
    //            {
    //                DepartmentName = e.Name,
    //                ManagerFirst = e.Manager.FirstName,
    //                ManagerLastName = e.Manager.LastName,
    //                Employees = e.Employees
    //                    .OrderBy(e => e.FirstName)
    //                    .ThenBy(e => e.LastName)
    //                    .Select(e => new
    //                    {
    //                        EmployeeFirst = e.FirstName,
    //                        EmployeeLastName = e.LastName,
    //                        JobTitle = e.JobTitle,
    //                    })
    //            });
    //        foreach (var dep in employees)
    //        {
    //            sb.AppendLine($"{dep.DepartmentName} - {dep.ManagerFirst} {dep.ManagerLastName}");
    //            foreach (var emp in dep.Employees)
    //            {
    //                sb.AppendLine($"{emp.EmployeeFirst} {emp.EmployeeLastName} - {emp.JobTitle}");
    //            }
    //        }
    //        return sb.ToString().TrimEnd();
    //    }

    //11. Find Latest 10 Projects
    //public static string GetLatestProjects(SoftUniContext context)
    //{
    //    StringBuilder sb = new StringBuilder();

    //    var projects = context.Projects
    //        .OrderByDescending(p => p.StartDate)
    //        .Select(p => new
    //        {
    //            p.Name,
    //            p.Description,
    //            p.StartDate
    //        })
    //        .Take(10);

    //    foreach (var project in projects.OrderBy(p => p.Name))
    //    {
    //        sb.AppendLine(project.Name);
    //        sb.AppendLine(project.Description);
    //        sb.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
    //    }
    //    return sb.ToString().TrimEnd();
    //}

    //12. Increase Salaries
    //public static string IncreaseSalaries(SoftUniContext context)
    //{
    //    StringBuilder sb = new StringBuilder();

    //    var employees = context.Employees
    //        .Where(d => new string[]
    //        {
    //            "Engineering",
    //            "Tool Design",
    //            "Marketing",
    //            "Information Services"
    //        }.Contains(d.Department.Name))
    //        .OrderBy(e => e.FirstName)
    //        .ThenBy(e => e.LastName)
    //        .ToArray();
    //        employees.ToList().ForEach(e => e.Salary = e.Salary + 0.12m * e.Salary);
    //        employees.ToList().ForEach(e => sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})"));
    //        return sb.ToString().TrimEnd();
    //}

    //13. Find Employees by First Name Starting With Sa
    //public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
    //{
    //    StringBuilder sb = new StringBuilder();

    //    var employees = context.Employees
    //        .Where(e => e.FirstName.StartsWith("Sa"))
    //        .OrderBy(e => e.FirstName)
    //        .ThenBy(e => e.LastName)
    //        .Select(e => new
    //        {
    //            e.FirstName,
    //            e.LastName,
    //            e.JobTitle,
    //            e.Salary
    //        });
    //    foreach (var emp in employees)
    //    {
    //        sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle} - (${emp.Salary:f2})");
    //    }
    //    return sb.ToString().TrimEnd();
    //}

    //14. Delete Project by Id
    //public static string DeleteProjectById(SoftUniContext context)
    //{
    //    StringBuilder sb = new StringBuilder();

    //    var project = context.Projects
    //        .Find(2);
    //    context.Projects.Remove(project!);

    //    var projects = context.EmployeesProjects
    //        .FirstOrDefault(p => p.ProjectId == 2);
    //    context.EmployeesProjects.Remove(projects!);

    //    context.SaveChanges();

    //    var additionalPr = context.Projects
    //        .Select(e => e.Name)
    //        .Take(10);
    //    foreach (var name in  additionalPr)
    //    {
    //        sb.AppendLine(name);
    //    }
    //    return sb.ToString().TrimEnd();
    //}

    //15. Remove Town
    public static string RemoveTown(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var town = context.Towns
            .FirstOrDefault(t => t.Name == "Seattle");

        var addresses = context.Addresses
            .Where(a => a.TownId == town!.TownId)
            .ToArray();

        var employeeAddress = context.Employees
            .Where(e => addresses.Contains(e.Address));

        foreach (var emp in employeeAddress)
            emp.AddressId = null;

        context.Addresses.RemoveRange(addresses);
        context.Towns.Remove(town!);

        context.SaveChanges();

        sb.AppendLine($"{addresses.Count()} addresses in Seattle were deleted");
        return sb.ToString().TrimEnd();

    }
}
