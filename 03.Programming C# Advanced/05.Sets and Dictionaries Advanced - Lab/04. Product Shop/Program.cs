using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var shops = new SortedDictionary<string, Dictionary<string, double>>();
            string command = Console.ReadLine();
            while (command != "Revision")
            {
                string[] tokens = command.Split(", ");
                string shop = tokens[0];
                string product = tokens[1];
                double price = double.Parse(tokens[2]);
                if(!shops.ContainsKey(shop))
                    shops.Add(shop, new Dictionary<string, double>());
                shops[shop].Add(product, price);
                command = Console.ReadLine();
            }

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");  
                }
            }
        }
    }
}
