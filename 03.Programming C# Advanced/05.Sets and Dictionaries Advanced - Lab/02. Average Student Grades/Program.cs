using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,List<double>> students = new Dictionary<string,List<double>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] student = Console.ReadLine().Split();
                if(!students.ContainsKey(student[0]))
                    students.Add(student[0], new List<double>());
                students[student[0]].Add(double.Parse(student[1]));
            }

            foreach (var student in students)
            {
                Console.Write($"{student.Key} -> ");
                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.WriteLine($" (avg: {student.Value.Average():f2})");
            }
        }
    }
}
