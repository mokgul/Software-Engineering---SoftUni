using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<int,int> valuesByCount = new Dictionary<int,int>();
            for (int i = 0; i < count; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if(!valuesByCount.ContainsKey(num))
                    valuesByCount.Add(num,0);
                valuesByCount[num]++;
            }

            Console.WriteLine(valuesByCount.Single(n =>n.Value % 2 == 0).Key);
        }
    }
}
