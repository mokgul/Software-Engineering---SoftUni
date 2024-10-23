using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> full = Console.ReadLine()
                    .Split('|')
                    .Reverse()
                    .ToList();

            List<string> result = new List<string>();

            for (int i = 0; i < full.Count; i++)
            {
                List<string> current = full[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                result.AddRange(current);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
