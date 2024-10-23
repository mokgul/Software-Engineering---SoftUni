using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Merging_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> first = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> second = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> merged = new List<int>();

            int biggerCount = Math.Max(first.Count, second.Count);

            for (int i = 0; i < biggerCount; i++)
            {
                if (i < first.Count)
                {
                    merged.Add(first[i]);
                }

                if (i < second.Count)
                {
                    merged.Add(second[i]);
                }
            }

            foreach (int item in merged)
            {
                Console.Write(item + " ");
            }
        }
    }
}