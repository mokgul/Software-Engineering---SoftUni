using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Gauss__Trick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> gaussNumbers = new List<int>();

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                int currentGauss = numbers[i] + numbers[numbers.Count - 1 - i];
                gaussNumbers.Add(currentGauss);
            }

            if (numbers.Count % 2 != 0)
            {
                gaussNumbers.Add(numbers[numbers.Count / 2]);
            }
            foreach (int num in gaussNumbers)
            {
                Console.Write(num + " ");
            }
        }
    }
}