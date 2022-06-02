using System;

namespace Fruit_Shop
{
    class FruitShop
    {
        static void Main(string[] args)
        {
            string[] week    = { "monday", "tuesday", "wednesday", "thursday", "friday" };
            string[] weekend = { "saturday", "sunday" };
            double price = 0.00;

            var fruit = Console.ReadLine().ToLower();
            string day      = Console.ReadLine().ToLower();
            double quantity = double.Parse(Console.ReadLine());

            if (day == week[0] || day == week[1] || day == week[2] || day == week[3] || day == week[4])
            {
                switch (fruit)
                {
                    case "banana":     price = 2.50; break;
                    case "apple":      price = 1.20; break;
                    case "orange":     price = 0.85; break;
                    case "grapefruit": price = 1.45; break;
                    case "kiwi":       price = 2.70; break;
                    case "pineapple":  price = 5.50; break;
                    case "grapes":     price = 3.85; break;
                    default: Console.WriteLine("error"); break;
                }
            }
            else if (day == weekend[0] || day == weekend[1])
            {
                switch (fruit)
                {
                    case "banana":     price = 2.70; break;
                    case "apple":      price = 1.25; break;
                    case "orange":     price = 0.90; break;
                    case "grapefruit": price = 1.60; break;
                    case "kiwi":       price = 3.00; break;
                    case "pineapple":  price = 5.60; break;
                    case "grapes":     price = 4.20; break;
                    default: Console.WriteLine("error"); break;
                }
            }
            else
                Console.WriteLine("error");

            double total = quantity * price;
            if(total != 0)
            Console.WriteLine($"{total:f2}");

        }
    }
}
