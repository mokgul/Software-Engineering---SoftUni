using System;

namespace Pets
{
    class Pets
    {
        static void Main(string[] args)
        {
            int days       = int.Parse(Console.ReadLine());
            int foodLeft   = int.Parse(Console.ReadLine());
            double dogFood = double.Parse(Console.ReadLine());
            double catFood = double.Parse(Console.ReadLine());
            double turtleFood = double.Parse(Console.ReadLine()) * 0.001; //въвежда се в грамове, преобразуваме в кг

            double foodNeeded = days * (dogFood + catFood + turtleFood);

            if (foodNeeded <= foodLeft)
                Console.WriteLine($"{Math.Floor(foodLeft - foodNeeded)} kilos of food left.");
            else
                Console.WriteLine($"{Math.Ceiling(foodNeeded - foodLeft)} more kilos of food are needed.");
        }
    }
}
