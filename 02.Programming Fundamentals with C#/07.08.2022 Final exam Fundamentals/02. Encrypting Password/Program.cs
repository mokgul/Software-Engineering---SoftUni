using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Encrypting_Password
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            string invalid = "Try another password!";
            List<string> encrypted = new List<string>();

            string pattern =
                @"(?<symbols>.+)>(?<nums>\d{3})\|(?<lower>[a-z]{3})\|(?<upper>[A-Z]{3})\|(?<any>[^<>]{3})<\k<symbols>";
            for (int i = 0; i < numberOfInputs; i++)
            {
                string input = Console.ReadLine();
                if (Regex.IsMatch(input, pattern))
                {
                    Match match = Regex.Match(input, pattern);
                    string current = "Password: " +
                                     match.Groups["nums"].Value +
                                    match.Groups["lower"].Value +
                                    match.Groups["upper"].Value +
                                    match.Groups["any"].Value;
                    encrypted.Add(current);
                }
                else
                {
                    encrypted.Add(invalid);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, encrypted));
        }
    }
}
