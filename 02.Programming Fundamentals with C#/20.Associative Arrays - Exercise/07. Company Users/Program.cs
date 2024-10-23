using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] tokens = line.Split(" -> ");
                string companyName = tokens[0];
                string employeeID = tokens[1];

                if (!companies.ContainsKey(companyName))
                {
                    companies.Add(companyName, new List<string>());
                }
                if(!companies[companyName].Contains(employeeID))
                    companies[companyName].Add(employeeID);
                line = Console.ReadLine();
            }

            foreach (var item in companies)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine($"{string.Join(Environment.NewLine, item.Value.Select(x => $"-- {x}"))}");
            }
        }
    }
}
