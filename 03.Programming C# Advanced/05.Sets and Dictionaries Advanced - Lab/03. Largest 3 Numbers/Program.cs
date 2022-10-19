using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> sorted = new List<int>(integers.OrderByDescending(x=>x).Take(3));
            Console.WriteLine(string.Join(" ", sorted));
        }
    }
}
