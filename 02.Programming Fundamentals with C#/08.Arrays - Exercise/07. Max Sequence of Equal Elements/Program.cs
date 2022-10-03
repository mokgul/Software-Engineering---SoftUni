using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int counter = 1;
            int max = 0;
            int element = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                    counter++;
                else
                {
                    counter = 1;
                }

                if (max < counter)
                {
                    max = counter;
                    element = numbers[i];
                }
            }

            int[] equals = new int[max];

            foreach (int i in equals)
            {
                equals[i] = element;
                Console.Write($"{element} ");
            }
        }
    }
}