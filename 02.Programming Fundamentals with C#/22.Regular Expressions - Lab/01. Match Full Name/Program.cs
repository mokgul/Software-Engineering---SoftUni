using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Match_Full_Name
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?<first>[A-Z][a-z]+) (?<last>[A-Z][a-z]+)\b";

            string names = Console.ReadLine();

            MatchCollection matchedNames = Regex.Matches(names, pattern);

            foreach (Match name in matchedNames)
            {
                Console.Write(name.Groups["first"].Value + " " + name.Groups["last"].Value + " ");
            }

            Console.WriteLine();
        }
    }
}
