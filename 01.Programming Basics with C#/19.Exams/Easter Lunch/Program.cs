using System;

namespace Easter_Lunch
{
    class Program
    {
        static void Main(string[] args)
        {
            double bread = 3.20;
            double eggs = 4.35; // per set of 12 eggs
            double cookies = 5.40;
            double paint = 0.15; // per egg

            int breadQty = int.Parse(Console.ReadLine());
            int eggsSets = int.Parse(Console.ReadLine());
            int cookiesQty = int.Parse(Console.ReadLine());

            double total = (eggsSets * 12) * paint + cookiesQty * cookies + eggsSets * eggs + breadQty * bread;
            Console.WriteLine($"{total:f2}");
        }
    }
}
