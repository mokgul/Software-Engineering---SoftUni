using System;
using System.Collections.Generic;

namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var continents = new Dictionary<string, Dictionary<string, List<string>>>();
            int linesQty = int.Parse(Console.ReadLine());
            for (int i = 0; i < linesQty; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ');
                string continent = tokens[0];
                string country = tokens[1];
                string city = tokens[2];

                if(!continents.ContainsKey(continent))
                    continents.Add(continent, new Dictionary<string, List<string>>());
                if(!continents[continent].ContainsKey(country))
                    continents[continent].Add(country, new List<string>());
                continents[continent][country].Add(city);
            }

            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ",country.Value)}");
                }
            }
        }
    }
}
