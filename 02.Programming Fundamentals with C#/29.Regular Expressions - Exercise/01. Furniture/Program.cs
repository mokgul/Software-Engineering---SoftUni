using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<furniture>[A-z]+)<<(?<price>[\d]+.?[\d]+)!(?<quantity>[\d]+)";
            Regex regex = new Regex(pattern);

            double totalCost = 0;
            List<string> furnituresBought = new List<string>();
            string line = Console.ReadLine();

            while (line != "Purchase")
            {
                Match match = regex.Match(line);
                if (match.Success)
                {
                    string furniture = match.Groups["furniture"].Value;
                    double price = double.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);
                    totalCost += price * quantity;

                    furnituresBought.Add(furniture);
                }
                line = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            furnituresBought.ForEach(x => Console.WriteLine(x));
            Console.WriteLine($"Total money spend: {totalCost:f2}");
        }
    }
}
