using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _06._Extract_Emails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> emails = new List<string>();
            string regexPattern =
                @"(?<=\s|^)[A-Za-z0-9]+((\.|_|-)?[A-Za-z0-9]+)*@[A-Za-z]+((-|\.)?[A-za-z]+)*\.[A-Za-z]+";
            string input = Console.ReadLine();
            MatchCollection email = Regex.Matches(input, regexPattern);
            foreach (Match match in email)
            {
                Console.WriteLine($"{match}");
            }
        }
    }
}
