using System;

namespace Family_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            double price = double.Parse(Console.ReadLine());
            double others = double.Parse(Console.ReadLine()) / 100.0;

            if (nights > 7) price *= 0.95;
            double nightsPrice = nights * price;
            double othersPrice = others * budget;
            double total = nightsPrice + othersPrice;
            if (total <= budget)
                Console.WriteLine($"Ivanovi will be left with {(budget - total):f2} leva after vacation.");
            else
                Console.WriteLine($"{(total - budget):f2} leva needed.");

        }
    }
}
