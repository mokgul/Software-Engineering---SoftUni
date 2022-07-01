using System;

namespace _2._1._Simple_Calculations___USD_to_BGN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double usd = double.Parse(Console.ReadLine());
            double bgn = usd * 1.79549;
            Console.WriteLine($"{bgn:f2} BGN");
        }
    }
}
