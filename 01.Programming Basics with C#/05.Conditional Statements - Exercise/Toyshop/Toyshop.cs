using System;

namespace Toyshop
{
    class Toyshop
    {
        static void Main(string[] args)
        {
            double puzzle = 2.60;
            double doll   = 3.00;
            double bear   = 4.10;
            double minion = 8.20;
            double truck  = 2.00;
            double rent   = 0.10;

            double travelPrice = double.Parse(Console.ReadLine());
            int puzzleAmount   = int.Parse(Console.ReadLine());
            int dollAmount     = int.Parse(Console.ReadLine());
            int bearAmount     = int.Parse(Console.ReadLine());
            int minionAmount   = int.Parse(Console.ReadLine());
            int truckAmount    = int.Parse(Console.ReadLine());

            int totalToys = puzzleAmount + dollAmount + bearAmount + minionAmount + truckAmount;
            double puzzlePrice = puzzleAmount * puzzle;
            double dollPrice   = dollAmount * doll;
            double bearPrice   = bearAmount * bear;
            double minionPrice = minionAmount * minion;
            double truckPrice  = truckAmount * truck;
            double totalEarning = puzzlePrice + dollPrice + bearPrice + minionPrice + truckPrice;
            if (totalToys >= 50)
            {
                totalEarning -= totalEarning*0.25;
            }
            totalEarning -= totalEarning * rent;
            if (totalEarning >= travelPrice)
            {
                Console.WriteLine("Yes! " + $"{totalEarning - travelPrice:0.00}" + " lv left.");
            }
            else
            {
                Console.WriteLine("Not enough money! " + $"{Math.Abs(totalEarning - travelPrice):0.00}" +" lv needed.");
            }
        }
    }
}
