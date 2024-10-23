using System;

namespace Football_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = "";
            int points = 0;
            int wins = 0;
            int draws = 0;
            int losses = 0;
            double winrate = 0;

            string team = Console.ReadLine();
            int games = int.Parse(Console.ReadLine());
            if (games > 0)
            {
                for (int i = 1; i <= games; i++)
                {
                    result = Console.ReadLine();
                    switch (result)
                    {
                        case "W":
                            points += 3;
                            wins++;
                            break;
                        case "D":
                            points += 1;
                            draws++;
                            break;
                        case "L":
                            losses++;
                            break;
                    }
                }
                winrate = ((double)wins / games) * 100.0;
                Console.WriteLine($"{team} has won {points} points during this season.");
                Console.WriteLine("Total stats:");
                Console.WriteLine($"## W: {wins}");
                Console.WriteLine($"## D: {draws}");
                Console.WriteLine($"## L: {losses}");
                Console.WriteLine($"Win rate: {winrate:f2}%");
            }
            else
                Console.WriteLine($"{team} hasn't played any games during this season.");
        }
    }
}
