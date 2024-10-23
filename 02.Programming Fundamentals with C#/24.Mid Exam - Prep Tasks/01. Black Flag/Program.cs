using System;

namespace _01._Black_Flag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int plunderDays = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());

            double totalPlunder = 0;
            for (int i = 1; i <= plunderDays; i++)
            {
                totalPlunder += dailyPlunder;
                if (i % 3 == 0)
                    totalPlunder += dailyPlunder / 2.0;
                if (i % 5 == 0)
                    totalPlunder *= 0.70;
            }

            bool succes = totalPlunder >= expectedPlunder;
            Console.WriteLine(succes
                ? $"Ahoy! {totalPlunder:f2} plunder gained."
                : $"Collected only {(totalPlunder / expectedPlunder) * 100:f2}% of the plunder.");
        }
    }
}
