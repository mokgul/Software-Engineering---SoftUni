using System;

namespace Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double total = 0;
            string coins = "";
            string product = "";
            //                  Nuts   Water  Crisps  Soda   Coke
            string[] prices = { "2.0", "0.7", "1.5", "0.8", "1.0" };
            double product_price = 0;
            while(coins != "Start")
            {
                coins = Console.ReadLine();
                if (coins == "Start") break;
                switch (coins)
                {
                    case "0.1":
                    case "0.2":
                    case "0.5":
                    case "1":
                    case "2":
                        total += double.Parse(coins);
                        break;
                    default:
                        Console.WriteLine($"Cannot accept {coins}");
                        continue;
                }
            }
            while(product != "End")
            {
                product = Console.ReadLine();
                if (product == "End") break;
                switch (product)
                {
                    case "Nuts":
                        product_price = (double.Parse(prices[0]) <= total) ? double.Parse(prices[0]) : 0;
                        break;
                    case "Water":
                        product_price = (double.Parse(prices[1]) <= total) ? double.Parse(prices[1]) : 0;
                        break;
                    case "Crisps":
                        product_price = (double.Parse(prices[2]) <= total) ? double.Parse(prices[2]) : 0;
                        break;
                    case "Soda":
                        product_price = (double.Parse(prices[3]) <= total) ? double.Parse(prices[3]) : 0;
                        break;
                    case "Coke":
                        product_price = (double.Parse(prices[4]) <= total) ? double.Parse(prices[4]) : 0;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        continue;
                }
                if (product_price > 0)
                {
                    total -= product_price;
                    Console.WriteLine($"Purchased {product.ToLower()}");
                }
                else
                    Console.WriteLine("Sorry, not enough money");
            }
            Console.WriteLine($"Change: {total:f2}");
        }
    }
}