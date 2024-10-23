using System;

namespace Odd__Even_Position
{
    class OddEvenPosition
    {
        static void Main(string[] args)
        {
            double oddSum = 0;
            double oddMin = double.MaxValue;
            double oddMax = double.MinValue;
            double evenSum = 0;
            double evenMin = double.MaxValue;
            double evenMax = double.MinValue;
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                double num = double.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum += num;
                    if (num < evenMin) evenMin = num;
                    if (num > evenMax) evenMax = num;
                }
                else
                {
                    oddSum += num;
                    if (num < oddMin) oddMin = num;
                    if (num > oddMax) oddMax = num;
                }
            }
            Console.WriteLine($"OddSum={oddSum:f2},");
            if (n == 0)
            {
                Console.WriteLine($"OddMin=No,");
                Console.WriteLine($"OddMax=No,");
            }
            else
            {
                Console.WriteLine($"OddMin={oddMin:f2},");
                Console.WriteLine($"OddMax={oddMax:f2},");
            }
            Console.WriteLine($"EvenSum={evenSum:f2},");
            if (n == 0 || n == 1)
            {
                Console.WriteLine($"EvenMin=No,");
                Console.WriteLine($"EvenMax=No");
            }
            else
            {
                Console.WriteLine($"EvenMin={evenMin:f2},");
                Console.WriteLine($"EvenMax={evenMax:f2}");
            }
        }
    }
}
