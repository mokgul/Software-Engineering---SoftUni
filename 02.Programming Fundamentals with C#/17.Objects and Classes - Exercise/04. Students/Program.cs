using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int studentCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < studentCount; i++)
            {
                Student student = new Student(
                    Console.ReadLine().Split(" "));
                students.Add(student);
            }
            students = students.OrderByDescending(s => s.Grade).ToList();
            foreach (Student student in students)
            {
                Console.WriteLine($"{student.FirstName} " +
                                  $"{student.LastName}: " +
                                  $"{student.Grade:f2}");
            }
        }
    }

    class Student
    {
        public Student(string[] info)
        {
            this.FirstName = info[0];
            this.LastName = info[1];
            this.Grade = double.Parse(info[2]);
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Grade { get; set; }
    }
}
