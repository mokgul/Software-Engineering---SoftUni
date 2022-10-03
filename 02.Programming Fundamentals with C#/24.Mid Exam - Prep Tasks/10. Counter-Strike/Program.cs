using System;

namespace _10._Counter_Strike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            int battlesWon = 0;

            string input = Console.ReadLine();
            while (input != "End of battle")
            {
                int distance = int.Parse(input);
                if(distance <= energy)
                {
                    energy -= distance;
                    battlesWon++;
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {battlesWon} won battles and {energy} energy");
                    return;
                }
                energy = battlesWon % 3 == 0 ? energy += battlesWon : energy;
                input = Console.ReadLine();
            }

            Console.WriteLine($"Won battles: {battlesWon}. Energy left: {energy}");
        }
    }
}
