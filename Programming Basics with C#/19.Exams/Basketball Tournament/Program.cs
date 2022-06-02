using System;

namespace Basketball_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            string name = "";
            int games = 0;
            int pointsFirstTeam = 0;
            int pointsSecondTeam = 0;
            int totalgames = 0;
            double wins = 0;
            double losses = 0;

            input = Console.ReadLine();
            while (input != "End of tournaments")
            {

                name = input;
                games = int.Parse(Console.ReadLine());
                totalgames += games;
                for (int i = 1; i <= games; i++)
                {
                    pointsFirstTeam = int.Parse(Console.ReadLine());
                    pointsSecondTeam = int.Parse(Console.ReadLine());
                    if (pointsFirstTeam > pointsSecondTeam)
                    {
                        wins++;
                        Console.WriteLine($"Game {i} of tournament {name}: win with {pointsFirstTeam - pointsSecondTeam} points.");
                    }
                    else
                    {
                        losses++;
                        Console.WriteLine($"Game {i} of tournament {name}: lost with {pointsSecondTeam - pointsFirstTeam} points.");
                    }
                }
                input = Console.ReadLine();
            }
            wins = (wins / totalgames) * 100;
            losses = (losses / totalgames) * 100;
            Console.WriteLine($"{wins:f2}% matches win");
            Console.WriteLine($"{losses:f2}% matches lost");
        }
    }
}
