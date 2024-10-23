using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] lengths = Console.ReadLine().Split().Select(int.Parse).ToArray();
            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();
            for (int i = 0; i < lengths[0] + lengths[1]; i++)
            {
                if (i < lengths[0])
                    first.Add(int.Parse(Console.ReadLine()));
                else
                    second.Add(int.Parse(Console.ReadLine()));
            }
            first.IntersectWith(second);
            Console.WriteLine(string.Join(" ",first));
        }
    }
}
