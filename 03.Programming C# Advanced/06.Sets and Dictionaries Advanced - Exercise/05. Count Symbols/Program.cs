using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char,int> countOfChars = new SortedDictionary<char,int>();
            string line = Console.ReadLine();
            for (int i = 0; i < line.Length; i++)
            {
                if(!countOfChars.ContainsKey(line[i]))
                    countOfChars.Add(line[i],0);
                countOfChars[line[i]]++;
            }
            foreach(var pair in countOfChars)
                Console.WriteLine($"{pair.Key}: {pair.Value} time/s");
        }
    }
}
