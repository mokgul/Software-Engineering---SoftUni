using System;

namespace _03._Floating_Equality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const double PRECISION = 0.000001;

            double numberA = double.Parse(Console.ReadLine());
            double numberB = double.Parse(Console.ReadLine());

            double diff = Math.Abs(numberA - numberB);
            bool Equal = (diff <= PRECISION) ? true : false;

            if (Equal)
                Console.WriteLine("True");
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}