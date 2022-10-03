using System;

namespace Small_Shop
{
    class SmallShop
    {
        static void Main(string[] args)
        {
            var item     = Console.ReadLine();
            var city     = Console.ReadLine();
            var quantity = double.Parse(Console.ReadLine());
            double price = 0;

            switch (city)
            {
                case  "Sofia":
                    {
                        switch (item)
                        {
                            case "coffee":  price = 0.50; break;
                            case "water":   price = 0.80; break;
                            case "beer":    price = 1.20; break;
                            case "sweets":  price = 1.45; break;
                            case "peanuts": price = 1.60; break;
                        }
                    }
                    break;
                case "Plovdiv":
                    {
                        switch (item)
                        {
                            case "coffee":  price = 0.40; break;
                            case "water":   price = 0.70; break;
                            case "beer":    price = 1.15; break;
                            case "sweets":  price = 1.30; break;
                            case "peanuts": price = 1.50; break;
                        }
                    }
                    break;
                case "Varna":
                    {
                    switch (item)
                    {
                            case "coffee":  price = 0.45; break;
                            case "water":   price = 0.70; break;
                            case "beer":    price = 1.10; break;
                            case "sweets":  price = 1.35; break;
                            case "peanuts": price = 1.55; break;
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
            double total = quantity * price;
            Console.WriteLine(total);
        }
    }
}
