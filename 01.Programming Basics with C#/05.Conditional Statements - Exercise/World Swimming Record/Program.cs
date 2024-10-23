using System;

namespace World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double record       = double.Parse(Console.ReadLine());
            double distance     = double.Parse(Console.ReadLine());
            double timePerMeter = double.Parse(Console.ReadLine());

            double ivanTime = distance * timePerMeter;
            double slowdownDistance = 15.00; //meters
            double slowdownRate = 12.5;      //seconds
            double slowdown  = Math.Floor(distance / slowdownDistance) * slowdownRate;  //seconds
            double totalTime = ivanTime + slowdown;
            if (totalTime < record)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {(totalTime - record):f2} seconds slower.");
            }

        }
    }
}
