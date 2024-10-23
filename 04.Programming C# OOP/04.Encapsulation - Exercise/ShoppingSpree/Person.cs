
using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private double money;

        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<Product>();
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"Name cannot be empty");
                name = value;
            }
        }

        public double Money
        {
            get => money;
            set
            {
                if (value < 0)
                    throw new ArgumentException($"Money cannot be negative");
                money = value;
            }
        }
        public List<Product> BagOfProducts { get; set; }

        public void AddProduct(Product product)
        {
            if (this.Money >= product.Cost)
            {
                this.BagOfProducts.Add(product);
                this.Money -= product.Cost;
                Console.WriteLine($"{this.Name} bought {product.Name}");
                return;
            }

            Console.WriteLine($"{this.Name} can't afford {product.Name}");
        }
    }
}
