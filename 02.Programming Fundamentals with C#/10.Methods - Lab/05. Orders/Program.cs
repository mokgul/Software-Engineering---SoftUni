using System;

namespace _05._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string drink = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            CalculatePrice(drink, quantity);
        }

        static void CalculatePrice(string drink, int quantity)
        {
            double price = 0;
            switch (drink)
            {
                case "coffee":
                    price = quantity * 1.50;
                    break;
                case "water":
                    price = quantity * 1.00;
                    break;
                case "coke":
                    price = quantity * 1.40;
                    break;
                case "snacks":
                    price = quantity * 2.00;
                    break;
            }

            Console.WriteLine($"{price:f2}");
        }
    }
}