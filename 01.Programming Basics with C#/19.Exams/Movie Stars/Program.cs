using System;

namespace Movie_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            double payment = 0;
            double budget = double.Parse(Console.ReadLine());
            string name = Console.ReadLine();
            while (name != "ACTION")
            {
                if (name.Length <= 15)
                {
                    payment = double.Parse(Console.ReadLine());
                }
                else
                {
                    payment = 0.20 * budget;
                }
                budget -= payment;
                if (budget <= 0) break;
                name = Console.ReadLine();
            }
            if (budget < 0)
                Console.WriteLine($"We need {Math.Abs(budget):f2} leva for our actors.");
            else
                Console.WriteLine($"We are left with {budget:f2} leva.");
        }
    }
}
