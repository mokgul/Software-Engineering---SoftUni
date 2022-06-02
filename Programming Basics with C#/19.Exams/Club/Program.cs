using System;

namespace Club
{
    class Program
    {
        static void Main(string[] args)
        {
            double profitDesired = double.Parse(Console.ReadLine());
            double price = 0;
            double profit = 0;

            string cocktail = Console.ReadLine();
            while (cocktail != "Party!")
            {
                int amount = int.Parse(Console.ReadLine());
                price = cocktail.Length * amount;
                if (price % 2 == 1) price *= 0.75;

                profit += price;
                if (profit >= profitDesired) break;

                cocktail = Console.ReadLine();
            }

            if (cocktail == "Party!")
            {
                Console.WriteLine($"We need {(profitDesired - profit):f2} leva more.");
            }
            if (profit >= profitDesired)
            {
                Console.WriteLine("Target acquired.");
            }
            Console.WriteLine($"Club income - {profit:f2} leva.");
        }
    }
}
