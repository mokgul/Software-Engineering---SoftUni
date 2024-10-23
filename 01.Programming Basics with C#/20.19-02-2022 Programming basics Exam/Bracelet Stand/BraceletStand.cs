using System;

namespace Bracelet_Stand
{
    class BraceletStand
    {
        static void Main(string[] args)
        {
            double pocketMoney = double.Parse(Console.ReadLine());
            double dailyProfit = double.Parse(Console.ReadLine());
            double expensies = double.Parse(Console.ReadLine());
            double giftPrice = double.Parse(Console.ReadLine());

            int days = 5;
            pocketMoney *= days;
            double totalProfit = dailyProfit * days;
            double total = pocketMoney + totalProfit;
            double moneyLeft = total - expensies;
            if (moneyLeft >= giftPrice)
            {
                Console.WriteLine($"Profit: {moneyLeft:f2} BGN, the gift has been purchased.");
            }
            else
            {
                double moneyNeeded = giftPrice - moneyLeft;
                Console.WriteLine($"Insufficient money: {moneyNeeded:f2} BGN.");
            }
        }
    }
}
