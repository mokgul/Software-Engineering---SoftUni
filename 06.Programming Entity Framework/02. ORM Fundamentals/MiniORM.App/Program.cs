using MiniORM.App.Data.Entities;
using MiniORM.App.Data;

namespace MiniORM.App;

    public class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Server=(LocalDB)\db charp softuni; Database=SoftUni; Integrated Security=true";
            var context = new SoftUniDbContext(connectionString);

            context.Employees.Add(new Employee
            {
                FirstName = "Gosho",
                LastName = "Inserted",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true,
            });

            var employee = context.Employees.Last();
            employee.FirstName = "Modified";
            context.SaveChanges();
        }
    }
