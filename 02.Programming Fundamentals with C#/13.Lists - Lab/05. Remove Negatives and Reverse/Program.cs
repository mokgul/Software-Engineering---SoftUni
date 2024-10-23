using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Remove_Negatives_and_Reverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < integers.Count; i++)
            {
                if (integers[i] < 0)
                {
                    integers.RemoveAt(i);
                    i--; //goes 1 position back cause the next element goes
                    // 1 position back as well
                }
            }

            integers.Reverse();
            if (integers.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                Console.WriteLine(string.Join(" ", integers));
            }
        }
    }
}
