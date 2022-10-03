using System;

namespace Challenge_the_Wedding
{
    class Program
    {
        static void Main(string[] args)
        {
            int tableCounter = 0;
            int males = int.Parse(Console.ReadLine());
            int females = int.Parse(Console.ReadLine());
            int totalTables = int.Parse(Console.ReadLine());

            for (int male = 1; male <= males; male++)
            {
                for (int female = 1; female <= females; female++)
                {
                    Console.Write($"({male} <-> {female})");
                    Console.Write(" ");
                    tableCounter++;
                    if (tableCounter >= totalTables) return;
                }
            }
        }
    }
}
