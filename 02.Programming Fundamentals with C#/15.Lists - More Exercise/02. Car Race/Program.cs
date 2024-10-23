using System;
using System.Linq;

namespace _02._Car_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] racersTimes = Console.ReadLine().Split(" ")
                .Select(int.Parse).ToArray();
            double leftRacerTime = 0;
            double rightRacerTime = 0;

            for (int i = 0; i < racersTimes.Length / 2; i++)
            {

                leftRacerTime = (racersTimes[i] != 0)
                    ? leftRacerTime += racersTimes[i]
                    : leftRacerTime *= 0.8;
            }

            for (int i = racersTimes.Length - 1; i > racersTimes.Length / 2; i--)
            {
                rightRacerTime = (racersTimes[i] != 0)
                    ? rightRacerTime += racersTimes[i]
                    : rightRacerTime *= 0.8;


            }
            int integer = 0;
            bool leftIsInt = int.TryParse(leftRacerTime.ToString(), out integer);
            bool rightIsInt = int.TryParse(rightRacerTime.ToString(), out integer);

            if (leftRacerTime < rightRacerTime)
            {
                Console.WriteLine(leftIsInt
                    ? $"The winner is left with total time: {leftRacerTime}"
                    : $"The winner is left with total time: {leftRacerTime:f1}");
            }
            else
            {
                Console.WriteLine(rightIsInt
                    ? $"The winner is right with total time: {rightRacerTime}"
                    : $"The winner is right with total time: {rightRacerTime:f1}");
            }
        }
    }
}
