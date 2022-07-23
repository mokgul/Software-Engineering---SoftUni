using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Company_Roster
{
    class Employee
    {
        public Employee(string name, double salary, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Department = department;
        }
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
    }

    class Department
    {
        public Department()
        {
            List<Employee> Members = new List<Employee>();
        }
        public string Name { get; set; }

        public List<Employee> Members { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int employeeCount = int.Parse(Console.ReadLine());

            List<Employee> employees = new List<Employee>();
            List<Department> departmentList = new List<Department>();

            for (int i = 0; i < employeeCount; i++)
            {
                string[] line = Console.ReadLine().Split(' ');

                string name = line[0];
                double salary = double.Parse(line[1]);
                string department = line[2];

                Employee employee = new Employee(name, salary, department);
                employees.Add(employee);

                bool depIsInList = (departmentList.Any(p => p.Name == department)) ? true : false;
                if (!depIsInList)
                {
                    departmentList.Add(new Department() { Name = department, Members = new List<Employee>() });
                }
            }

            foreach (Department department in departmentList)
            {
                foreach (Employee employee in employees)
                {
                    if (department.Name == employee.Department)
                    {
                        department.Members.Add(employee); 
                    }
                }
            }

            double averageSalary = 0;
            double highestAvr = 0;
            string bestDepartment = string.Empty;

            foreach (Department department in departmentList)
            {
                foreach (Employee employee in department.Members)
                {
                    averageSalary += employee.Salary;
                }

                averageSalary = averageSalary / department.Members.Count;
                if (averageSalary > highestAvr)
                {
                    highestAvr = averageSalary;
                    bestDepartment = department.Name;
                }

                averageSalary = 0;
            }

            Department best = departmentList.Find(p => p.Name == bestDepartment);
            best.Members = best.Members.OrderByDescending(p => p.Salary).ToList();

            Console.WriteLine($"Highest Average Salary: {bestDepartment}");
            foreach (Employee employee in best.Members)
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
            }
        }
    }
}
