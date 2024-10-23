
namespace _02._Enter_Numbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = new List<int>();

            while (numbers.Count < 10)
            {
                try
                {
                    if (!numbers.Any())
                    {
                        numbers.Add(ReadNumber(1, 100));
                    }
                    else
                    {
                        int currentMax = numbers.Max();
                        numbers.Add(ReadNumber(currentMax, 100));
                    }
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        public static int ReadNumber(int start, int end)
        {
            string userInput = Console.ReadLine();
            int number;
            try
            {
                number = int.Parse(userInput);
            }
            catch (FormatException)
            {
                throw new FormatException($"Invalid Number!");
            }

            if (number <= start || number >= end)
            {
                throw new ArgumentException($"Your number is not in range {start} - {end}!");
            }

            return number;
        }
    }
}
