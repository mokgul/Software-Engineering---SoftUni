using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string line = Console.ReadLine();
            while (line != "end")
            {
                string[] tokens = line.Split(" : ");
                string course = tokens[0];
                string student = tokens[1];

                if (!courses.ContainsKey(course))
                {
                    courses.Add(course, new List<string>());
                }
                courses[course].Add(student);

                line = Console.ReadLine();
            }

            foreach (var item in courses)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
                Console.WriteLine($"{string.Join(Environment.NewLine, item.Value.Select(x => $"-- {x}"))}");
            }
        }
    }
}
