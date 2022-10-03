using System;
using System.Collections.Generic;

namespace _04._Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] info = input.Split(' ');

                Student student = new Student();
                student.FirstName = info[0];
                student.LastName = info[1];
                student.Age = info[2];
                student.HomeTown = info[3];

                students.Add(student);

                input = Console.ReadLine();
            }

            string cityName = Console.ReadLine();

            foreach (Student student in students)
            {
                if (student.HomeTown == cityName)
                {
                    Console.WriteLine($"{student.FirstName} " +
                                      $"{student.LastName} is " +
                                      $"{student.Age} years old.");
                }
            }
        }
    }

    class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Age { get; set; }

        public string HomeTown { get; set; }
    }
}
