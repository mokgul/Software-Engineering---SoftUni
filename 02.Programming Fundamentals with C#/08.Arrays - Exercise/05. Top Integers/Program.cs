using System;
using System.Linq;

namespace _05._Top_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            string top = string.Empty;

            for (int i = 0; i < numbers.Length; i++)
            {
                bool isBigger = false;
                int elementToCompare = numbers[i];
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (elementToCompare > numbers[j])
                        isBigger = true;
                    else
                    {
                        isBigger = false;
                        break;
                    }
                }

                if (i == numbers.Length - 1) isBigger = true;

                if (isBigger)
                {
                    top += (elementToCompare + " ");
                }

            }

            int[] output = top.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Console.WriteLine(string.Join(" ", output));
        }
    }
}