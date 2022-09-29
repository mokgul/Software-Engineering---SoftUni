using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;

namespace _2._Rage_Quit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string pattern = @"(?<message>[^\d]+)(?<times>[\d]+)";
            StringBuilder finalMessage = new StringBuilder();
            List<char> unique = new List<char>();
            MatchCollection matches = Regex.Matches(message, pattern);

            foreach (Match match in matches)
            {
                string stringToPrint = match.Groups["message"].Value.ToUpper();
                int countToRepeat = int.Parse(match.Groups["times"].Value);

                for (int i = 0; i < countToRepeat; i++)
                    finalMessage.Append(stringToPrint);

            }
            for (int i = 0; i < finalMessage.Length; i++)
            {
                if (!unique.Contains(finalMessage[i]))
                {
                    unique.Add(finalMessage[i]);
                }
            }
            //counting the unique symbols must happen outside of the loop for creating the final
            //message cause there could be strings with quantifier equal to 0 
            //and its unique chars shouldnt be counted towards the count of unique elements

            Console.WriteLine($"Unique symbols used: {unique.Count}");
            Console.WriteLine(finalMessage);
        }
    }
}
