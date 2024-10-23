using System;

namespace Puppy_Care
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            int foodPerDay = 0;
            int foodBought = int.Parse(Console.ReadLine()) * 1000;

            while (input != "Adopted")
            {
                input = Console.ReadLine();
                if (input == "Adopted") break;

                foodPerDay = int.Parse(input);
                foodBought -= foodPerDay;
            }
            if (foodBought >= 0)
            {
                Console.WriteLine($"Food is enough! Leftovers: {foodBought} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {Math.Abs(foodBought)} grams more.");
            }
        }
    }
}
