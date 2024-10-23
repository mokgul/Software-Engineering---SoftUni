using System;
using System.Linq;

namespace _09._Heart_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] neighborhood = Console.ReadLine().Split('@').Select(int.Parse).ToArray();

            int currentPlace = 0;
            string input = Console.ReadLine();
            while (input != "Love!")
            {
                string[] tokens = input.Split();
                int jumpLength = int.Parse(tokens[1]);
                currentPlace += jumpLength;

                if (currentPlace >= neighborhood.Length)
                    currentPlace = 0;
                if (neighborhood[currentPlace] == 0)
                {
                    Console.WriteLine($"Place {currentPlace} already had Valentine's day.");
                    input = Console.ReadLine();
                    continue;
                }
                else
                {
                    neighborhood[currentPlace] -= 2;
                    if (neighborhood[currentPlace] == 0)
                        Console.WriteLine($"Place {currentPlace} has Valentine's day.");
                }
                input = Console.ReadLine();
            }

            int emptyHouse = neighborhood.Count(x => x != 0);
            Console.WriteLine($"Cupid's last position was {currentPlace}.");
            Console.WriteLine(emptyHouse == 0
            ? $"Mission was successful."
            : $"Cupid has failed {emptyHouse} places.");
        }
    }
}
