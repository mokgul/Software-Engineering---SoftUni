using System;

namespace _07._Water_Overflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int CAPACITY = 255;
            int tankFilled = 0;
            int fillingTimes = int.Parse(Console.ReadLine());
            for (int i = 1; i <= fillingTimes; i++)
            {
                int quntity = int.Parse(Console.ReadLine());
                if ((CAPACITY - tankFilled) >= quntity)
                {
                    tankFilled += quntity;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(tankFilled);
        }
    }
}