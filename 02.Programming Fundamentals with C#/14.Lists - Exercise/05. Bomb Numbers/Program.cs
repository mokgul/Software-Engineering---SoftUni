using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            int[] bomb = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            while(numbers.Contains(bomb[0]))
            {
                int originalCount = numbers.Count;
                for (int i = 0; i < originalCount; i++)
                {
                    if (i > numbers.Count - 1) break;
                    if (numbers[i] == bomb[0])
                    {
                        int detonatedCount = bomb[1];
                        int start = i - detonatedCount;
                        int count = detonatedCount * 2 + 1;
                        if (start < 0)
                        {
                            start = 0;
                            count = count - 1;

                            // start begins at minus, we are setting it to zero so it works.
                        }

                        if ((start + count) > numbers.Count - 1)
                            count = numbers.Count - start;
                        numbers.RemoveRange(start, count);
                        break;
                    }
                }
            }

            int sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }

            Console.WriteLine(sum);
        }
    }
}
