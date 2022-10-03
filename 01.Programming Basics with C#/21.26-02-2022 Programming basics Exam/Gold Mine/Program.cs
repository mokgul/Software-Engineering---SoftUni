using System;

namespace Gold_Mine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double expected_yield = 0;
            double gold_mined = 0;
            double average = 0;
            int days = 0;
            int locations = int.Parse(Console.ReadLine());

            for (int i = 1; i <= locations; i++)
            {
                expected_yield = double.Parse(Console.ReadLine());
                days = int.Parse(Console.ReadLine());
                for (int j = 1; j <= days; j++)
                {
                    gold_mined = double.Parse(Console.ReadLine());
                    average += gold_mined;
                }
                average /= days;
                if (average >= expected_yield)
                    Console.WriteLine($"Good job! Average gold per day: {average:f2}.");
                else
                    Console.WriteLine($"You need {(expected_yield - average):f2} gold.");
                average = 0;
            }
        }
    }
}
