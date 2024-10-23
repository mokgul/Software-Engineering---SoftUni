using System;

namespace Clock
{
    class Clock
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    Console.Write(i);
                    Console.Write(" : ");
                    Console.WriteLine(j);
                }
            }
        }
    }
}
