using System;

namespace Game_Number_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstPlayer = Console.ReadLine();
            string secondPlayer = Console.ReadLine();

            string playerOne = Console.ReadLine();
            string playerTwo = Console.ReadLine();
            bool war = false;
            int scoreFirst = 0;
            int scoreSecond = 0;
            while (playerOne != "End of game" && playerTwo != "End of game")
            {
                int cardFirst = int.Parse(playerOne);
                int cardSecond = int.Parse(playerTwo);
                if (cardFirst > cardSecond) scoreFirst += (cardFirst - cardSecond);
                else if (cardFirst < cardSecond) scoreSecond += (cardSecond - cardFirst);
                else
                {
                    war = true;
                    Console.WriteLine("Number wars!");
                    cardFirst = int.Parse(Console.ReadLine());
                    cardSecond = int.Parse(Console.ReadLine());
                    if (cardFirst > cardSecond)
                    {
                        Console.WriteLine($"{firstPlayer} is winner with {scoreFirst} points");
                    }
                    else if (cardSecond > cardFirst)
                    {
                        Console.WriteLine($"{secondPlayer} is winner with {scoreSecond} points");
                    }
                    break;
                }
                if (!war)
                {
                    playerOne = Console.ReadLine();
                    if (playerOne != "End of game")
                        playerTwo = Console.ReadLine();
                }
            }
            if (playerOne == "End of game" || playerTwo == "End of game")
            {
                Console.WriteLine($"{firstPlayer} has {scoreFirst} points");
                Console.WriteLine($"{secondPlayer} has {scoreSecond} points");
            }
        }
    }
}
