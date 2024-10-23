using System;
using System.Linq;

namespace _15.Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var integers = Console.ReadLine().Split().Select(int.Parse).ToList();
            integers = integers.Where(x => x > integers.Average()).ToList();
            Console.WriteLine(integers.Count > 0
            ? string.Join(" ",integers.OrderByDescending(x => x).Take(5).ToList())
            : "No");
        }
    }
}
