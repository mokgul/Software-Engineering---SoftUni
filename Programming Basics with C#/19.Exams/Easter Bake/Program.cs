using System;

namespace Easter_Bake
{
    class Program
    {
        static void Main(string[] args)
        {
            int flour = 0;
            int sugar = 0;
            int maxFlour = 0;
            int maxSugar = 0;
            double flourTotal = 0;
            double sugarTotal = 0;

            int bread = int.Parse(Console.ReadLine());
            for (int i = 1; i <= bread; i++)
            {
                sugar = int.Parse(Console.ReadLine());
                flour = int.Parse(Console.ReadLine());
                if (flour > maxFlour) maxFlour = flour;
                if (sugar > maxSugar) maxSugar = sugar;
                flourTotal += flour;
                sugarTotal += sugar;
            }
            flourTotal = Math.Ceiling(flourTotal / 750);
            sugarTotal = Math.Ceiling(sugarTotal / 950);

            Console.WriteLine($"Sugar: {sugarTotal}");
            Console.WriteLine($"Flour: {flourTotal}");
            Console.WriteLine($"Max used flour is {maxFlour} grams, max used sugar is {maxSugar} grams.");
        }
    }
}
