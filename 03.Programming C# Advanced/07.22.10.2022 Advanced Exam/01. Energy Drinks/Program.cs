using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Energy_Drinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stamatsCaffeine = 0;
            Stack<int> caffeine = new Stack<int>(Console.ReadLine()
                .Split(", ").Select(int.Parse).ToArray());
            Queue<int> energyDrinks = new Queue<int>(Console.ReadLine()
                .Split(", ").Select(int.Parse).ToArray());

            while (true)
            {
                if (energyDrinks.Count == 0 || caffeine.Count == 0) break;
                int currentCaffeine = caffeine.Peek() * energyDrinks.Peek();
                if (currentCaffeine + stamatsCaffeine <= 300)
                {
                    stamatsCaffeine += currentCaffeine;
                    caffeine.Pop();
                    energyDrinks.Dequeue();
                }
                else
                {
                    caffeine.Pop();
                    energyDrinks.Enqueue(energyDrinks.Dequeue());
                    stamatsCaffeine -= 30;
                    if (stamatsCaffeine < 0) stamatsCaffeine = 0;
                }
            }

            if (energyDrinks.Count > 0)
            {
                Console.WriteLine($"Drinks left: {string.Join(", ",energyDrinks)}");
            }

            if (energyDrinks.Count == 0)
            {
                Console.WriteLine($"At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {stamatsCaffeine} mg caffeine.");
        }
    }
}
