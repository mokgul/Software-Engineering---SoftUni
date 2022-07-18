using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Messaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //NOT FINISHED, 80% done
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            string text = Console.ReadLine();
            string output = String.Empty;

            for (int i = 0; i < numbers.Count; i++)
            {
                int digitSum = 0;
                int currentNum = numbers[i];
                while (currentNum > 0)
                {
                    digitSum += currentNum % 10;
                    currentNum /= 10;
                }

                if (digitSum > text.Length - 1)
                    digitSum -= text.Length;

                output += text[digitSum];
                text.Remove(digitSum,1);

            }

            Console.WriteLine(output);
        }
    }
}
