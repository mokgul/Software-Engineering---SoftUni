using System;

namespace _1._Binary_Digits_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            int count = 0;
            int remainder = 0;
            while (n > 0)
            {
                remainder = n % 2;
                n /= 2;
                if (remainder == b)
                    count++;
            }

            Console.WriteLine(count);
        }
    }
}
