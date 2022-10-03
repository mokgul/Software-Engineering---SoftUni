using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(" ")
                .Select(w => w.ToLower())
                .ToArray();

            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (!counts.ContainsKey(word))
                {
                    counts.Add(word, 0);
                }

                counts[word]++;
            }

            foreach (var word in counts.Where(item => item.Value % 2 != 0))
            {
                Console.Write($"{word.Key} ");
            }
        }
    }
}
