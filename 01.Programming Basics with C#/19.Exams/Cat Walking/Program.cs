using System;

namespace Cat_Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutesPerWalk = int.Parse(Console.ReadLine());
            int walksQty = int.Parse(Console.ReadLine());
            int caloriesConsumed = int.Parse(Console.ReadLine());

            int caloriesBurned = (minutesPerWalk * 5) * walksQty;
            if (caloriesBurned >= 0.5 * caloriesConsumed)
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {caloriesBurned}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {caloriesBurned}.");
            }
        }
    }
}
