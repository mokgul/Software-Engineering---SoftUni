using System;
using System.Linq;
using System.Reflection;

namespace _07._Equal_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstArray = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int[] secondArray = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int sum = 0;
            bool identical = true;
            for (int index = 0; index < firstArray.Length; index++)
            {
                if (firstArray[index] != secondArray[index])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {index} index");
                    identical = false;
                    break;
                }
                else
                {
                    sum += firstArray[index];
                }
            }
            if (identical)
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
        }
    }
}