using System;

namespace Dishwasher
{
    class Dishwasher
    {
        static void Main(string[] args)
        {
            int bottleVolume = 750;
            int dishDetergent = 5;
            int potDetergent = 15;
            int detergentUsedForDishes = 0;
            int detergentUsedForPots = 0;
            int dishwasherLoads = 0;
            int itemsToBeWashed = 0;
            int dishesWashed = 0;
            int potsWashed = 0;
            string input = "";

            int bottleQty = int.Parse(Console.ReadLine());
            int totalDetergent = bottleQty * bottleVolume;

            while (totalDetergent >= 0)
            {
                dishwasherLoads++;

                if (totalDetergent < 0) break;

                input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                itemsToBeWashed = int.Parse(input);
                if (dishwasherLoads % 3 == 0)
                {
                    potsWashed += itemsToBeWashed;
                    detergentUsedForPots = itemsToBeWashed * potDetergent;
                    totalDetergent -= detergentUsedForPots;
                }
                else if (dishwasherLoads % 3 != 0)
                {
                    dishesWashed += itemsToBeWashed;
                    detergentUsedForDishes = itemsToBeWashed * dishDetergent;
                    totalDetergent -= detergentUsedForDishes;
                }
            }
            if (totalDetergent >= 0)
            {
                Console.WriteLine("Detergent was enough!");
                Console.WriteLine($"{dishesWashed} dishes and {potsWashed} pots were washed.");
                Console.WriteLine($"Leftover detergent {totalDetergent} ml.");
            }
            else
            {
                Console.WriteLine($"Not enough detergent, {Math.Abs(totalDetergent)} ml. more necessary!");
            }
        }
    }
}
