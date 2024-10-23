using System;

namespace Easter_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int guests = int.Parse(Console.ReadLine());
            double pricePerGuest = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            if (guests >= 10 && guests <= 15) pricePerGuest *= 0.85;
            else if (guests > 15 && guests <= 20) pricePerGuest *= 0.80;
            else if (guests > 20) pricePerGuest *= 0.75;

            double cake = 0.10 * budget;
            budget -= (guests * pricePerGuest + cake);

            if (budget >= 0)
                Console.WriteLine($"It is party time! {budget:f2} leva left.");
            else
                Console.WriteLine($"No party! {Math.Abs(budget):f2} leva needed.");
        }
    }
}
