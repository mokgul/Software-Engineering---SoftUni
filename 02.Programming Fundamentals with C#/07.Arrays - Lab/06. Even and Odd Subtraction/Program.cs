using System;
using System.Linq;

namespace _05._Even_And_Odd_Substraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int evenSum = 0;
            int oddSum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                    evenSum += numbers[i];
                else
                {
                    oddSum += numbers[i];
                }
            }

            Console.WriteLine(evenSum - oddSum);
        }
    }
}