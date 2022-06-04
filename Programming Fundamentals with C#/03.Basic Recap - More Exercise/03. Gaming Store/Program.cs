using System;

namespace Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            //                   Outfall  CS:OG  Zplint Honored Rover Rover OG
            double[] prices    = { 39.99, 15.99, 19.99, 59.99, 29.99, 39.99 };
            double game_price  = 0;
            double total_spent = 0;
            string command     = "";
            double balance = double.Parse(Console.ReadLine());

            while (command != "Game Time")
            {
                command = Console.ReadLine();
                switch (command)
                {
                    case "OutFall 4":                  game_price = prices[0]; break;
                    case "CS: OG":                     game_price = prices[1]; break;
                    case "Zplinter Zell":              game_price = prices[2]; break;
                    case "Honored 2":                  game_price = prices[3]; break;
                    case "RoverWatch":                 game_price = prices[4]; break;
                    case "RoverWatch Origins Edition": game_price = prices[5]; break;
                    case "Game Time":                                       continue;
                    default:
                        Console.WriteLine("Not found");
                        continue;
                }
                if (balance >= game_price)
                {
                    balance -= game_price;
                    total_spent += game_price;
                    Console.WriteLine($"Bought {command}");
                }
                else if (balance < game_price)
                {
                    Console.WriteLine("Too Expensive");
                    continue;
                }

                if(balance <= 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }
            }

            Console.WriteLine($"Total spent: ${total_spent:f2}. Remaining: ${balance:f2}");
        }
    }
}