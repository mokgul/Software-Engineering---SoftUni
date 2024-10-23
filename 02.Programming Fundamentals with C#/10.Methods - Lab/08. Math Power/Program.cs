using System;
using System.Runtime.CompilerServices;

namespace _08._Math_Power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double @base = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            double result = MathPower(@base, power);
            Console.WriteLine(result);
        }

        private static double MathPower(double @base, int power)
        {
            double result = 1;
            for (int i = 1; i <= power; i++)
            {
                result *= @base;
            }

            return result;
        }

    }
}