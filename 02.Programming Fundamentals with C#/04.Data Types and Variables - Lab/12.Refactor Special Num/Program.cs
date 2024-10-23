using System;

namespace _12.Refactor_Special_Num
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                int sum = 0;
                int digits = i;
                while (digits > 0)
                {
                    sum += digits % 10;
                    digits /= 10;
                }
                bool special = false;
                special = ((sum == 5) || (sum == 7) || (sum == 11));
                Console.WriteLine("{0} -> {1}", i, special);
            }

        }
    }
}