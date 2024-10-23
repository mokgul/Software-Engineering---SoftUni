using System;

namespace Series
{
    class Program
    {
        static void Main(string[] args)
        {
            double price = 0;
            double total = 0;
            string name = "";
            double budget = double.Parse(Console.ReadLine());
            int amount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= amount; i++)
            {
                name = Console.ReadLine();
                price = double.Parse(Console.ReadLine());
                switch (name)
                {
                    case "Thrones": price *= 0.50; break;
                    case "Lucifer": price *= 0.60; break;
                    case "Protector": price *= 0.70; break;
                    case "TotalDrama": price *= 0.80; break;
                    case "Area": price *= 0.90; break;
                }
                total += price;
            }
            if (budget >= total)
                Console.WriteLine($"You bought all the series and left with {(budget - total):f2} lv.");
            else
                Console.WriteLine($"You need {(total - budget):f2} lv. more to buy the series!");
        }
    }
}
