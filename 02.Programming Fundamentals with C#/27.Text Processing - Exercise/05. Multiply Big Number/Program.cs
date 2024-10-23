using System;
using System.Linq;
using System.Text;

namespace _05._Multiply_Big_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());

            int remainder = 0;
            StringBuilder result = new StringBuilder();
            for (int i = number.Length - 1; i >= 0; i--)
            {
                int currentDigit = (int.Parse(number[i].ToString()) * multiplier) + remainder;

                result.Append(currentDigit % 10);
                remainder = currentDigit / 10;
            }

            if (remainder != 0)
            {
                result.Append(remainder);
            }

            if (multiplier == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine(string.Join("", result.ToString().Reverse()));
            }
        }
    }
}
