using System;
using System.Linq;

namespace _08._Letters_Change_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            char[] upper =
            {
                ' ', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                'U', 'V', 'W', 'X', 'Y', 'Z'
            };
            char[] lower =
            {
                ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                'u', 'v', 'w', 'x', 'y', 'z'
            };

            double operationsSum = 0;
            foreach (var str in input)
            {
                string number = str.Substring(1, str.Length - 2);
                char start = str[0];
                char end = str[^1];
                double currentSum = 0;

                char firstOperation = char.IsUpper(start) ? '/' : '*';
                char secondOperation = char.IsUpper(end) ? '-' : '+';

                currentSum = firstOperation == '/' 
                    ? (double.Parse(number) / Array.IndexOf(upper,start))
                    : (double.Parse(number) * Array.IndexOf(lower,start));

                currentSum = secondOperation == '-'
                    ? (currentSum - Array.IndexOf(upper,end))
                    : (currentSum + Array.IndexOf(lower,end));

                operationsSum += currentSum;
            }

            Console.WriteLine("{0:0.00}",operationsSum);
        }
    }
}
