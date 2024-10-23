using System;

namespace Food_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int chickenAmount = int.Parse(Console.ReadLine());
            int fishAmout     = int.Parse(Console.ReadLine());
            int veggieAmount  = int.Parse(Console.ReadLine());
            double Price      = chickenAmount * 10.35 + fishAmout * 12.40 + veggieAmount * 8.15;
            double dessert    = 0.20 * Price;
            Console.WriteLine(Price + dessert + 2.50);
        }
    }
}
