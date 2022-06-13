using System;
using System.Linq;

namespace _06._Equal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int leftSum = 0;
            int rightSum = 0;
            bool found = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                leftSum = 0;
                rightSum = 0;
                int currentElement = numbers[i];
                if (i == 0)
                {
                    leftSum = 0;
                    for (int j = i + 1; j < numbers.Length; j++)
                    {
                        rightSum += numbers[j];
                    }
                }
                else if (i == numbers.Length - 1)
                {
                    rightSum = 0;
                    for (int j = 0; j < numbers.Length - 1; j++)
                    {
                        leftSum += numbers[j];
                    }
                }
                else
                {
                    for (int j = 0; j < i; j++)
                    {
                        leftSum += numbers[j];
                    }

                    for (int j = i + 1; j < numbers.Length; j++)
                    {
                        rightSum += numbers[j];
                    }
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("no");
            }
        }
    }
}