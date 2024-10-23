using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Shopping_Spree
{
    class Person
    {
        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.BagOfProducts = new List<Product>();
        }
        public string Name { get; set; }
        public double Money { get; set; }
        public List<Product> BagOfProducts { get; set; }

        public void Buy(Product product)
        {
            if (product.Cost <= this.Money)
            {
                this.BagOfProducts.Add(product);
                this.Money -= product.Cost;
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }

        public void Print(Person person)
        {
            if (person.BagOfProducts.Count == 0)
            {
                Console.WriteLine($"{person.Name} - Nothing bought");
            }
            else
            {
                Console.Write($"{person.Name} - ");
                Console.Write(string.Join(", ", person.BagOfProducts.Select(p => p.Name)));
                Console.WriteLine();
            }
        }
    }

    class Product
    {
        public Product(string name, double cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name { get; set; }
        public double Cost { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = GetInfo();
            List<Product> products = GetProductInfo();
            Actions(people, products);
            people.ForEach(p => p.Print(p));
        }

        private static List<Person> GetInfo()
        {
            List<Person> people = new List<Person>();
            string[] peopleInput = Console.ReadLine().Split(";");
            for (int i = 0; i < peopleInput.Length; i++)
            {
                string[] tokens = peopleInput[i].Split("=");

                string name = tokens[0];
                double money = double.Parse(tokens[1]);
                Person person = new Person(name, money);

                people.Add(person);
            }

            return people;
        }

        private static List<Product> GetProductInfo()
        {
            List<Product> products = new List<Product>();
            string[] productsInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < productsInput.Length; i++)
            {
                string[] tokens = productsInput[i].Split("=");

                string name = tokens[0];
                double price = double.Parse(tokens[1]);
                Product product = new Product(name, price);

                products.Add(product);
            }
            return products;
        }

        private static List<Person> Actions(List<Person> people, List<Product> products)
        {
            string purchase = Console.ReadLine();
            while (purchase != "END")
            {
                string[] info = purchase.Split(" ");

                string person = info[0];
                string productName = info[1];

                foreach (Person p in people.Where(p => p.Name == person))
                {
                    p.Buy(products.Find(p => p.Name == productName));
                }
                purchase = Console.ReadLine();
            }
            return people;
        }
    }
}
