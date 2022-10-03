using System;

namespace Coffee_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            //                    No sugar  Normal  Extra
            string[] espresso = { "0.90", "1.00", "1.20" };
            string[] cappuccino = { "1.00", "1.20", "1.60" };
            string[] tea = { "0.50", "0.60", "0.70" };
            double price = 0;

            string drink = Console.ReadLine();
            string sugar = Console.ReadLine();
            int amount = int.Parse(Console.ReadLine());

            switch (drink)
            {
                case "Espresso":
                    switch (sugar)
                    {
                        case "Without": price = double.Parse(espresso[0]); break;
                        case "Normal": price = double.Parse(espresso[1]); break;
                        case "Extra": price = double.Parse(espresso[2]); break;
                    }
                    break;
                case "Cappuccino":
                    switch (sugar)
                    {
                        case "Without": price = double.Parse(cappuccino[0]); break;
                        case "Normal": price = double.Parse(cappuccino[1]); break;
                        case "Extra": price = double.Parse(cappuccino[2]); break;
                    }
                    break;
                case "Tea":
                    switch (sugar)
                    {
                        case "Without": price = double.Parse(tea[0]); break;
                        case "Normal": price = double.Parse(tea[1]); break;
                        case "Extra": price = double.Parse(tea[2]); break;
                    }
                    break;
            }
            price *= amount;
            if (sugar == "Without") price *= 0.65;
            if (drink == "Espresso" && amount >= 5) price *= 0.75;
            if (price > 15.00) price *= 0.80;

            Console.WriteLine($"You bought {amount} cups of {drink} for {price:f2} lv.");
        }
    }
}
