using System;

namespace Fishing_Boat
{
    class FishingBoat
    {
        static void Main(string[] args)
        {
            double rent          = 0;
            var rentSpring       = 3000;
            var rentSummerAutumn = 4200;
            var rentWinter       = 2600;

            int budget    = int.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();

            switch(season)
            {
                case "spring": rent = rentSpring;       break;
                case "summer":
                case "autumn": rent = rentSummerAutumn; break;
                case "winter": rent = rentWinter;       break;
            }

            int fishermanQny = int.Parse(Console.ReadLine());
            if (fishermanQny <= 6)
                rent *= 0.90;
            else if (fishermanQny <= 11)
                rent *= 0.85;
            else if (fishermanQny > 12)
                rent *= 0.75;

            if (fishermanQny % 2 == 0 && season != "autumn")
                rent *= 0.95;

            if (budget >= rent)
                Console.WriteLine($"Yes! You have {(budget - rent):f2} leva left.");
            else
                Console.WriteLine($"Not enough money! You need {(rent - budget):f2} leva.");
        }
    }
}
