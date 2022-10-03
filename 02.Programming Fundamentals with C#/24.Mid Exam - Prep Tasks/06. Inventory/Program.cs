using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> inventory = Console.ReadLine().Split(", ").ToList();

            string input = Console.ReadLine();
            while (input != "Craft!")
            {
                string[] tokens = input.Split(" - ");
                switch (tokens[0])
                {
                    case "Collect":
                        if (!inventory.Contains(tokens[1]))
                            inventory.Add(tokens[1]);
                        break;
                    case "Drop":
                        if (inventory.Contains(tokens[1]))
                            inventory.Remove(tokens[1]);
                        break;
                    case "Combine Items":
                        string[] items = tokens[1].Split(':');
                        string old = items[0];
                        string newItem = items[1];

                        if (inventory.Contains(old))
                        {
                            int index = inventory.IndexOf(old);
                            inventory.Insert(index + 1, newItem);
                        }
                        break;
                    case "Renew":
                        if (inventory.Contains(tokens[1]))
                        {
                            string temp = tokens[1];
                            inventory.Remove(tokens[1]);
                            inventory.Add(temp);
                        }
                        break;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", inventory));
        }
    }
}
