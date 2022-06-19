using System;

namespace _08._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());

            double result = GetFactorial(first) / GetFactorial(second);
            Console.WriteLine($"{result:f2}");
        }

        private static double GetFactorial(int a)
        {
            double result = 1;
            for (double i = a; i > 0; i--)
            {
                result *= i;
            }

            return result;
        }
    }
}