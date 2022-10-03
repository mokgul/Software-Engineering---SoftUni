using System;

namespace _05._Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int sumDigits = 0;
                int digits = i;
                while (digits > 0)
                {
                    sumDigits += digits % 10;
                    digits /= 10;
                }
                bool special = (sumDigits == 5) ? true : (sumDigits == 7) ? true : (sumDigits == 11) ? true : false;
                if (special)
                    Console.WriteLine($"{i} -> True");
                else
                    Console.WriteLine($"{i} -> False");
            }
        }
    }
}