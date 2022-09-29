using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;

namespace _3._Post_Office
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patternCapitals = @"(?<1>[#$%*&])(?<capitals>[A-Z]+)\k<1>";
            string patternLenghts = @"(?<lengths>[\d]{2}\:[\d]{2})";

            string[] parts = Console.ReadLine().Split('|');

            Match capitals = Regex.Match(parts[0], patternCapitals);
            MatchCollection lenghts = Regex.Matches(parts[1], patternLenghts);

            string[] words = parts[2].Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<int, int> wordParameters = new Dictionary<int, int>();
            foreach (var ch in capitals.ToString().ToCharArray())
            {
                foreach (Match item in lenghts)
                {
                    string[] current = item.ToString().Split(':');
                    int currentLetter = int.Parse(current[0]);
                    int currentLength = int.Parse(current[1]);
                    if (ch == (char)currentLetter)
                    {
                        if (!wordParameters.ContainsKey(currentLetter))
                            wordParameters.Add(currentLetter, currentLength);
                    }
                }
            }

            foreach (var item in wordParameters)
            {
                for (int i = 0; i < words.Length; i++)
                {
                    string currentWord = words[i];
                    char starting = (char)item.Key;
                    int length = item.Value + 1; // the regex counts the letters without the capital, thats why we add + 1 for full length
                    if (currentWord.StartsWith(starting) && currentWord.Length == length)
                        Console.WriteLine(words[i]);
                }
            }
        }
    }
}
