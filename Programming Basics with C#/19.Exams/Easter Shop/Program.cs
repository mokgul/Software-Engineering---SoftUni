using System;

namespace Easter_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int eggs = int.Parse(Console.ReadLine());
            string input = "";
            int amount = 0;
            int sold = 0;

            while (input != "Close")
            {
                input = Console.ReadLine();
                if (input == "Close") break;
                amount = int.Parse(Console.ReadLine());
                if (input == "Buy")
                {
                    if (amount > eggs)
                    {
                        Console.WriteLine($"Not enough eggs in store!");
                        Console.WriteLine($"You can buy only {eggs}.");
                        break;
                    }
                    else
                    {
                        eggs -= amount;
                        sold += amount;
                    }
                }
                else if (input == "Fill")
                {
                    eggs += amount;
                }
            }
            if (input == "Close")
            {
                Console.WriteLine($"Store is closed!");
                Console.WriteLine($"{sold} eggs sold.");
            }
        }
    }
}
