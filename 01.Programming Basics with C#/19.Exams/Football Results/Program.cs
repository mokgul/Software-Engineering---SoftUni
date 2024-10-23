using System;

namespace Football_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            int win = 0;
            int loses = 0;
            int draws = 0;

            for (int i = 1; i <= 3; i++)
            {
                string result = Console.ReadLine();
                char score1 = result[0];
                char score2 = result[2];
                if (score1 > score2) win++;
                else if (score1 < score2) loses++;
                else
                    draws++;
            }
            Console.WriteLine($"Team won {win} games.");
            Console.WriteLine($"Team lost {loses} games.");
            Console.WriteLine($"Drawn games: {draws}");
        }
    }
}
