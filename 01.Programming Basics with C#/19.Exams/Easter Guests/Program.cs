using System;

namespace Easter_Guests
{
    class Program
    {
        static void Main(string[] args)
        {
            int guests = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double bread = Math.Ceiling(guests / 3.00);
            int eggs = guests * 2;
            double breadPrice = bread * 4;
            double eggPrice = eggs * 0.45;
            double price = breadPrice + eggPrice;

            if (budget >= price)
            {
                Console.WriteLine($"Lyubo bought {bread} Easter bread and {eggs} eggs.");
                Console.WriteLine($"He has {(budget - price):f2} lv. left.");
            }
            else
            {
                Console.WriteLine($"Lyubo doesn't have enough money.");
                Console.WriteLine($"He needs {(price - budget):f2} lv. more.");
            }
        }
    }
}
