using System;

namespace Sleepy_Tom_Cat
{
    class SleepyTomCat
    {
        static void Main(string[] args)
        {
            int sleepingNorm     = 30000;
            int workdaysPlaytime = 63;
            int dayoffsPlaytime  = 127;

            int dayoffs = int.Parse(Console.ReadLine());

            int workdays   = 365 - dayoffs;
            int playtime   = workdays * workdaysPlaytime + dayoffs * dayoffsPlaytime;
            int difference = Math.Abs(sleepingNorm - playtime);

            if (playtime > sleepingNorm)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{difference / 60} hours and {difference % 60} minutes more for play");
            }
            else if (playtime <= sleepingNorm)
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{difference / 60} hours and {difference % 60} minutes less for play");
            }
        }
    }
}
