using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Orders
{
    class Product
    {
        public Product(string name, decimal price, int quantity)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal GetTotal()
        {
            decimal total = this.Price * this.Quantity;
            return total;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> products = GetInfo();
            Dictionary<string, decimal> orders = new Dictionary<string, decimal>();

            foreach (var item in products)
            {
                decimal total = item.Value.GetTotal();
                orders[item.Key] = total;
            }

            foreach (var item in orders)
            {
                Console.WriteLine($"{item.Key} -> {item.Value:f2}");
            }

        }

        private static Dictionary<string, Product> GetInfo()
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            string line = Console.ReadLine();
            while (line != "buy")
            {
                string[] tokens = line.Split(" ");

                string name = tokens[0];
                decimal price = decimal.Parse(tokens[1]);
                int quantity = int.Parse(tokens[2]);

                Product product = new Product(name, price, quantity);
                if (!products.ContainsKey(name))
                {
                    products.Add(name, product);
                }
                else
                {
                    foreach (var item in products.Where(t => t.Key == name))
                    {
                        item.Value.Price = price;
                        item.Value.Quantity += quantity;
                    }
                }

                line = Console.ReadLine();
            }
            return products;
        }
    }
}
