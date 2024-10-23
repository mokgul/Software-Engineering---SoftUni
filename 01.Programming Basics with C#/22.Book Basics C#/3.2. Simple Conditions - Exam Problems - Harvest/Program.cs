using System;

namespace _3._2._Simple_Conditions___Exam_Problems___Harvest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double grapePerLiterWine = 2.5;

            int vineArea = int.Parse(Console.ReadLine());
            double grapePerSquareVine = double.Parse(Console.ReadLine());
            int neededAmountWine = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double grapesForWine = (vineArea * grapePerSquareVine) * 0.40;
            double wineProduced = grapesForWine / grapePerLiterWine;

            if (wineProduced < neededAmountWine)
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(neededAmountWine - wineProduced)} liters wine needed.");
            }
            else if (wineProduced >= neededAmountWine)
            {
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(wineProduced)} liters.");
                double wineLeft = Math.Ceiling(wineProduced - neededAmountWine);
                double winePerWorker = Math.Ceiling(wineLeft / workers);
                Console.WriteLine($"{wineLeft} liters left -> {winePerWorker} liters per person.");
            }
        }
    }
}
