using System;

namespace Clock___part_2
{
    class ClockPart2
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    for (int k = 0; k < 60; k++)
                    {
                        Console.Write(i);
                        Console.Write(" : ");
                        Console.Write(j);
                        Console.Write(" : ");
                        Console.WriteLine(k);
                    }
                }
            }
        }
    }
}
