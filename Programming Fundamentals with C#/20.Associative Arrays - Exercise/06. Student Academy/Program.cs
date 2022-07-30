using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double>());
                }

                students[name].Add(grade);
            }

            Dictionary<string, double> bestStudents = new Dictionary<string, double>();
            foreach (var student in students)
            {
                double current = student.Value.Average();
                if (current >= 4.50)
                {
                    bestStudents.Add(student.Key, current);
                }
            }

            foreach (var student in bestStudents)
            {
                Console.WriteLine($"{student.Key} -> {student.Value:f2}");
            }
        }
    }
}
