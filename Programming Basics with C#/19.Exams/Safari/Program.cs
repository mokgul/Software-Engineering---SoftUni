using System;

namespace Safari
{
    class Program
    {
        static void Main(string[] args)
        {
            double fuelPrice = 2.10;
            double guide = 100;
            double total = 0;

            double budget = double.Parse(Console.ReadLine());
            double fuel = double.Parse(Console.ReadLine());
            string day = Console.ReadLine();

            double fuelTotal = fuel * fuelPrice;
            total = fuelTotal + guide;
            if (day == "Saturday") total *= 0.90;
            else if (day == "Sunday") total *= 0.80;

            if (budget >= total)
                Console.WriteLine($"Safari time! Money left: {(budget - total):f2} lv.");
            else
                Console.WriteLine($"Not enough money! Money needed: {(total - budget):f2} lv.");
        }
    }
}
