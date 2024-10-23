using System;

namespace Basketball_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double yearTax = double.Parse(Console.ReadLine());
            double shoes = 0.60 * yearTax;
            double clothes = 0.80 * shoes;
            double ball = 0.25 * clothes;
            double others = 0.20 * ball;
            double total = yearTax + shoes + clothes + ball + others;
            Console.WriteLine("{0:0.00}", total);
        }
    }
}
