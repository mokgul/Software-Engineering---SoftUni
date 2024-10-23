using System;

namespace Name_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int points = 0;
            int winner = 0;
            string winnerName = "";
            string name = Console.ReadLine();
            while (name != "Stop")
            {
                for (int i = 0; i < name.Length; i++)
                {
                    int guess = int.Parse(Console.ReadLine());
                    if (guess == name[i]) points += 10;
                    else
                        points += 2;
                }
                if (points >= winner)
                {
                    winner = points;
                    winnerName = name;
                }
                points = 0;
                name = Console.ReadLine();
            }
            Console.WriteLine($"The winner is {winnerName} with {winner} points!");
        }
    }
}
