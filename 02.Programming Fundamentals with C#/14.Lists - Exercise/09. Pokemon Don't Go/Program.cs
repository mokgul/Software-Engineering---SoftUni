using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Pokemon_Don_t_Go
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            int valueToRemove = 0;
            int sumOfRemoved = 0;
            while (integers.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                if (index < 0)
                {
                    valueToRemove = integers[0];// cause index is less than 0, valueToRemove gets
                    //the value of 0 element
                    sumOfRemoved += valueToRemove;
                    integers[0] = integers[integers.Count - 1];
                    //instead of removing 0 and coping last, 0 gets the value of last
                    integers = ModifyValues(integers, valueToRemove);
                }
                else if (index > integers.Count - 1)
                {
                    valueToRemove = integers[integers.Count - 1];
                    sumOfRemoved += valueToRemove;
                    integers[integers.Count - 1] = integers[0];
                    integers = ModifyValues(integers, valueToRemove);
                }
                else
                {
                    valueToRemove = integers[index];
                    sumOfRemoved += valueToRemove;
                    integers.RemoveAt(index);
                    integers = ModifyValues(integers, valueToRemove);
                }
            }

            Console.WriteLine(sumOfRemoved);
        }

        private static List<int> ModifyValues(List<int> integers, int valueToRemove)
        {
            for (int i = 0; i < integers.Count; i++)
            {
                if (integers[i] <= valueToRemove)
                {
                    integers[i] += valueToRemove;
                }
                else
                {
                    integers[i] -= valueToRemove;
                }
            }

            return integers;
        }
    }
}
