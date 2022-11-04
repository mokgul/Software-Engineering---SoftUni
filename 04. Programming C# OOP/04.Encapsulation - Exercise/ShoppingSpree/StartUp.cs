


namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] peopleInfo = Console.ReadLine().Split(';',StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < peopleInfo.Length; i++)
            {
                string[] tokens = peopleInfo[i].Split('=');
                string name = tokens[0];
                double money = double.Parse(tokens[1]);
                try
                {
                    Person person = new Person(name, money);
                    if (!people.Any(n => n.Name == name))
                        people.Add(person);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            string[] productInfo = Console.ReadLine().Split(';',StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < productInfo.Length; i++)
            {
                string[] tokens = productInfo[i].Split('=');
                string name = tokens[0];
                double cost = double.Parse(tokens[1]);
                try
                {
                    Product product = new Product(name, cost);
                    if (!products.Any(p => p.Name == name))
                        products.Add(product);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] tokens = command.Split();
                Person person = people.First(n => n.Name == tokens[0]);
                Product product = products.First(p => p.Name == tokens[1]);
                person.AddProduct(product);
                command = Console.ReadLine();
            }

            foreach (var person in people)
            {
                if (person.BagOfProducts.Count == 0)
                    Console.WriteLine($"{person.Name} - Nothing bought");
                else
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.BagOfProducts.Select(p => p.Name))}");
            }
        }
    }
}

