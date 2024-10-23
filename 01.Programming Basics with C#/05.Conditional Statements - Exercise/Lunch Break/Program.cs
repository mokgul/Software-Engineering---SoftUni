using System;

namespace Lunch_Break
{
    class Program
    {
        static void Main(string[] args)
        {
            string series    = Console.ReadLine();
            int seriesLenght = int.Parse(Console.ReadLine());
            int breakTime    = int.Parse(Console.ReadLine());
            double lunchTime = breakTime * 0.125;
            double restTime  = breakTime * 0.25;
            double timeLeft  = breakTime - (lunchTime + restTime);
            if (timeLeft >= seriesLenght)
            {
                Console.WriteLine($"You have enough time to watch {series} and left with {Math.Ceiling(timeLeft - seriesLenght)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {series}, you need {Math.Ceiling(Math.Abs(timeLeft - seriesLenght))} more minutes.");
            }
        }
    }
}
