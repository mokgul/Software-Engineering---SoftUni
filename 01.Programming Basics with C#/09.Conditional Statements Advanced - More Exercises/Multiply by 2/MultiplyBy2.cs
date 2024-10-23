using System;

namespace Multiply_by_2
{
    class MultiplyBy2
    {
        static void Main(string[] args)
        {
            double result = 0.00;
            double num;
            num = double.Parse(Console.ReadLine());
            while (num >= 0)
            {
                result = num * 2;
                Console.WriteLine($"Result: {result:f2}");
                num = double.Parse(Console.ReadLine());
            }
            Console.WriteLine("Negative number!");
        }
    }
}
