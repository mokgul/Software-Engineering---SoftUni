using System;

namespace Building
{
    class Building
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int apartmentsPerFloor = int.Parse(Console.ReadLine());

            for (int floor = floors; floor > 0; floor--)
            {
                for (int apartment = 0; apartment < apartmentsPerFloor; apartment++)
                {
                    if (floor == floors)
                    {
                        Console.Write($"L{floor}{apartment} ");
                    }
                    if (floor % 2 == 1 && floor != floors)
                    {
                        Console.Write($"A{floor}{apartment} ");
                    }
                    if (floor % 2 == 0 && floor != floors)
                    {
                        Console.Write($"O{floor}{apartment} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
