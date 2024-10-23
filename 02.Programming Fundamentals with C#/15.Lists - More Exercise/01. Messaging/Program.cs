using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Messaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split()
                .Select(int.Parse).ToList();
            
            numbers = numbers.Select(x => GetSum(x)).ToList();

            string text = Console.ReadLine();
            string message = string.Empty;
            message = GetMessage(numbers, text, message);
            Console.WriteLine(message);
        }

        private static int GetSum(int x)
        {
            int sum = 0;
            while (x != 0)
            {
                sum += x % 10;
                x /= 10;
            }
            return sum;
        }

        private static string GetMessage(List<int> numbers, string text,string message)
        {
            for (int i = 0; i < numbers.Count;i++)
            {
                int currentNumber = numbers[i];
                while (currentNumber > text.Length - 1) 
                    currentNumber -= text.Length;

                message += text[currentNumber];
                text = text.Remove(currentNumber, 1);
            }

            return message;
        }
    }
}
