using System;

namespace Flower_Shop
{
    class FlowerShop
    {
        static void Main(string[] args)
        {
            double magnolia = 3.25;
            double hyacinth = 4.00;
            double rose     = 3.50;
            double cactus   = 8.00;
            double tax      = 0.05;

            int magnoliaAmount = int.Parse(Console.ReadLine());
            int hyacinthAmount = int.Parse(Console.ReadLine());
            int roseAmount     = int.Parse(Console.ReadLine());
            int cactusAmount   = int.Parse(Console.ReadLine());
            double giftPrice   = double.Parse(Console.ReadLine());

            double income = magnoliaAmount * magnolia + hyacinthAmount * hyacinth + roseAmount * rose + cactusAmount * cactus;
            income -= income * tax;

            if (income >= giftPrice)
            {
                Console.WriteLine($"She is left with {Math.Floor(income - giftPrice)} leva.");
            }
            else
            {
                Console.WriteLine($"She will have to borrow {Math.Ceiling(giftPrice - income)} leva.");
            }
        }
    }
}
