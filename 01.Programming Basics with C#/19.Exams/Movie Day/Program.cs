using System;

namespace Movie_Day
{
    class Program
    {
        static void Main(string[] args)
        {
            double timeAvailable = double.Parse(Console.ReadLine());
            int scenes = int.Parse(Console.ReadLine());
            int timePerScene = int.Parse(Console.ReadLine());

            timeAvailable -= (timeAvailable * 0.15 + scenes * timePerScene);
            if (timeAvailable >= 0)
                Console.WriteLine($"You managed to finish the movie on time! You have {Math.Round(timeAvailable)} minutes left!");
            else
                Console.WriteLine($"Time is up! To complete the movie you need {Math.Round(timeAvailable) * (-1)} minutes.");
        }
    }
}
