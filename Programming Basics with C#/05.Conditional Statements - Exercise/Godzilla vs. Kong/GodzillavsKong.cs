using System;

namespace Godzilla_vs._Kong
{
    class GodzillavsKong
    {
        static void Main(string[] args)
        {
            double budget      = double.Parse(Console.ReadLine());
            int extras         = int.Parse(Console.ReadLine());
            double outfitPrice = double.Parse(Console.ReadLine());

            double decor = budget * 0.10;
            double outfitTotalPrice = extras * outfitPrice;
            if(extras > 150)
            {
                outfitTotalPrice -= outfitTotalPrice * 0.10;
            }
            double expensies = decor + outfitTotalPrice;
            if (expensies > budget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine("Wingard needs " + $"{Math.Abs(expensies - budget):0.00}" + " leva more.");
            }
            else if(expensies <= budget)
            {
                Console.WriteLine("Action!");
                Console.WriteLine("Wingard starts filming with " + $"{Math.Abs(expensies - budget):0.00}" + " leva left.");
            }
        }
    }
}
