using System;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            SortedSet<string> set = new SortedSet<string>();
            for (int i = 0; i < count; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                set.UnionWith(line);
            }

            Console.WriteLine(string.Join(" ", set));
        }
    }
}
