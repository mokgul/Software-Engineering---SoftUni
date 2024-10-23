using System;

namespace _06._Oscars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nameOfActor = Console.ReadLine();
            double pointsOfAcademy = double.Parse(Console.ReadLine());
            int countEvaluators = int.Parse(Console.ReadLine());

            double totalPoints = 0;
            double pointsFromJury = 0;

            for (int counter = 1; counter <= countEvaluators; counter++)
            {
                string nameOfEvaluator = Console.ReadLine();
                double pointsOfEvaluator = double.Parse(Console.ReadLine());

                pointsFromJury += (nameOfEvaluator.Length * pointsOfEvaluator) / 2;
                totalPoints = pointsFromJury + pointsOfAcademy;
                if (totalPoints > 1250.5)
                {
                    break;
                }

            }
            if (totalPoints > 1250.5)
            {
                Console.WriteLine($"Congratulations, {nameOfActor} got a nominee for leading role with {totalPoints:f1}!");
            }
            else
            {
                Console.WriteLine($"Sorry, {nameOfActor} you need {(1250.5 - totalPoints):f1} more!");
            }
        }
    }
}