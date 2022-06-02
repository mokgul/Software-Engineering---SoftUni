using System;

namespace Tennis_Ranklist
{
    class TennisRanklist
    {
        static void Main(string[] args)
        {
            //declaration
            int winner = 2000;
            int finalist = 1200;
            int semiFin = 720;
            string tournament = "";
            int tournamentPoints = 0;
            int totalPoints = 0;
            double average = 0;
            double tournamentsWon = 0;

            //input, calculation
            int tournamentsQty = int.Parse(Console.ReadLine());
            int startingPoints = int.Parse(Console.ReadLine());

            for (int i = 0; i < tournamentsQty; i++)
            {
                tournament = Console.ReadLine();
                switch (tournament)
                {
                    case "W":
                        tournamentPoints += winner;
                        tournamentsWon++;
                        break;
                    case "F":
                        tournamentPoints += finalist;
                        break;
                    case "SF":
                        tournamentPoints += semiFin;
                        break;
                }
            }
            tournamentsWon = (tournamentsWon / tournamentsQty) * 100;
            average = tournamentPoints / (double)tournamentsQty;
            totalPoints = tournamentPoints + startingPoints;

            //output
            Console.WriteLine($"Final points: {totalPoints}");
            Console.WriteLine($"Average points: {Math.Floor(average)}");
            Console.WriteLine($"{tournamentsWon:f2}%");
        }
    }
}
