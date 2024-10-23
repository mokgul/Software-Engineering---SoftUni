using System;

namespace _09._Spice_Must_Flow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int storage = 0;
            int days = 0;
            const int WORKERS_CONSUME = 26;
            while (startingYield >= 100)
            {
                storage += startingYield;
                storage = (storage >= WORKERS_CONSUME) ? (storage - WORKERS_CONSUME) : storage;
                days++;
                startingYield -= 10;
            }

            storage = (storage >= WORKERS_CONSUME) ? (storage - WORKERS_CONSUME) : storage;
            Console.WriteLine(days);
            Console.WriteLine(storage);
        }
    }
}