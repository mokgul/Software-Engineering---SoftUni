using System;

namespace Beer_And_Chips
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double budget = double.Parse(Console.ReadLine());
            int beers = int.Parse(Console.ReadLine());
            int chips = int.Parse(Console.ReadLine());

            double beerPrice = beers * 1.20;
            double chipsPrice = Math.Ceiling(chips * (0.45 * beerPrice));
            double total = beerPrice + chipsPrice;
            if (budget >= total)
            {
                Console.WriteLine($"{name} bought a snack and has {(budget - total):f2} leva left.");
            }
            else
                Console.WriteLine($"{name} needs {(total - budget):f2} more leva!");
        }
    }
}
