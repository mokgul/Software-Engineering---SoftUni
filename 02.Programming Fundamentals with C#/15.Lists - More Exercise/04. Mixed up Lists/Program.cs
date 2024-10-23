using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Mixed_up_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> firstInput = Console.ReadLine().Split().ToList();
            List<string> secondInput = Console.ReadLine().Split().Reverse().ToList();
            List<int> full = new List<int>();
            for (int i = 0; i < Math.Min(firstInput.Count, secondInput.Count); i++)
            {
                full.Add(int.Parse(firstInput[i]));
                full.Add(int.Parse(secondInput[i]));
            }

            int start = firstInput.Count > secondInput.Count
                ? int.Parse(firstInput[^2]) // same as firstInput[firstInput.Count - 2], index 2 counting from end to start
                : int.Parse(secondInput[^2]);

            int end = firstInput.Count > secondInput.Count
                ? int.Parse(firstInput[^1])
                : int.Parse(secondInput[^1]);

            var final = full.Where(x => x > Math.Min(start, end) && x < Math.Max(start, end)).OrderBy(x => x).ToList();
            Console.WriteLine(string.Join(" ", final));
        }
    }
}
