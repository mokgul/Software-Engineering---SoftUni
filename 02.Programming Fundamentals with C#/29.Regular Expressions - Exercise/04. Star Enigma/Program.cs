using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfMessages = int.Parse(Console.ReadLine());
            List<string> attacked = new List<string>();
            List<string> destroyed = new List<string>();

            for (int i = 0; i < numberOfMessages; i++)
            {
                string input = Console.ReadLine();
                string pattern = @"[starSTAR]";
                MatchCollection matches = Regex.Matches(input, pattern);
                
                string decrypted = string.Empty;
                for (int j = 0; j < input.Length; j++)
                {
                    decrypted += (char)(input[j] - matches.Count);
                }

                string messagePattern =
                    @"@(?<name>[A-Z][a-z]+)[^@\-!:>]*:(?<population>[\d]+)[^@\-!:>]*!(?<type>[AD])![^@\-!:>]*\->(?<count>[\d]+)";
                Match info = Regex.Match(decrypted, messagePattern);
                if (info.Success)
                {
                    string name = info.Groups["name"].Value;
                    int population = int.Parse(info.Groups["population"].Value);
                    char type = char.Parse(info.Groups["type"].Value);
                    int soldierCount = int.Parse(info.Groups["count"].Value);

                    if(type == 'A' && !attacked.Contains(name))
                        attacked.Add(name);
                    else if(type == 'D' && !destroyed.Contains(name))
                        destroyed.Add(name);
                }
            }

            Console.WriteLine($"Attacked planets: {attacked.Count}");
            attacked = attacked.OrderBy(x => x).ToList();
            attacked.ForEach(x => Console.WriteLine($"-> {x}"));

            Console.WriteLine($"Destroyed planets: {destroyed.Count}");
            destroyed = destroyed.OrderBy(x => x).ToList();
            destroyed.ForEach(x => Console.WriteLine($"-> {x}"));
        }
    }
}
