using System;

namespace PC_Game_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int hearthstone = 0;
            int fornite = 0;
            int overwatch = 0;
            int others = 0;
            string game = "";
            int gamesQty = int.Parse(Console.ReadLine());

            for (int i = 1; i <= gamesQty; i++)
            {
                game = Console.ReadLine();
                switch (game)
                {
                    case "Hearthstone": hearthstone++; break;
                    case "Fornite": fornite++; break;
                    case "Overwatch": overwatch++; break;
                    default: others++; break;
                }
            }
            double gameOne = ((double)hearthstone / gamesQty) * 100.00;
            double gameTwo = ((double)fornite / gamesQty) * 100.00;
            double gameThree = ((double)overwatch / gamesQty) * 100.00;
            double gameOthers = ((double)others / gamesQty) * 100.00;

            Console.WriteLine($"Hearthstone - {gameOne:f2}%");
            Console.WriteLine($"Fornite - {gameTwo:f2}%");
            Console.WriteLine($"Overwatch - {gameThree:f2}%");
            Console.WriteLine($"Others - {gameOthers:f2}%");
        }
    }
}
