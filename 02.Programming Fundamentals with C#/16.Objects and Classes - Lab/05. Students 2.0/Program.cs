using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Students_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            string line = Console.ReadLine();
            while (line != "end")
            {
                string[] tokens = line.Split(' ');

                string firstName = tokens[0];
                string lastName = tokens[1];
                int age = int.Parse(tokens[2]);
                string city = tokens[3];

                //using LINQ
                //Student student = students.FirstOrDefault(
                //    s => s.FirstName == firstName &&
                //         s.LastName == lastName);
                //if (student == null)
                //{
                //    students.Add(new Student()
                //    {
                //        FirstName = firstName,
                //        LastName = lastName,
                //        Age = age,
                //        City = city
                //    });
                //}
                //else
                //{
                //    student.FirstName = firstName;
                //    student.LastName = lastName;
                //    student.Age = age;
                //    student.City = city;
                //    cw the newly added student
                //}

                if (IsStudentExisting(students, firstName, lastName))
                {
                    Student student = GetStudent(students, firstName, lastName);

                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.City = city;

                }
                else
                {
                    Student student = new Student()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        City = city
                    };

                    students.Add(student);
                }
                line = Console.ReadLine();
            }
            string filterCity = Console.ReadLine();

            foreach (Student student in students)
            {
                if (student.City == filterCity)
                {
                    Console.WriteLine($"{student.FirstName} " +
                                      $"{student.LastName} " +
                                      $"is {student.Age} " +
                                      $"years old.");
                }
            }

            //using LINQ
            //List<Student> filteredStudents = students.
            //    Where(s => s.City == filterCity)
            //    .ToList();
            //foreach (Student student in filteredStudents)
            //{
            //    Console.WriteLine($"{student.FirstName} " +
            //                      $"{student.LastName} " +
            //                      $"is {student.Age} " +
            //                      $"years old.");
            //}
        }

        static bool IsStudentExisting(List<Student> students, string firstName, string lastName)
        {
            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }
            return false;
        }

        static Student GetStudent(List<Student> students, string firstName, string lastName)
        {
            Student existingStudent = null;

            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    existingStudent = student;
                }
            }

            return existingStudent;
        }
    }

    class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string City { get; set; }
    }
}
