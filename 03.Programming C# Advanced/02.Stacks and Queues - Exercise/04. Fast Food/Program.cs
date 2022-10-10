using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    internal class FastFood
    {
        private static Queue<int> queue;
        private static int availableFood;
        private static Predicate<Queue<int>> isEmpty = c => c.Count == 0;
        private static Predicate<Queue<int>> isNotEmpty = c => c.Count > 0;
        private static Predicate<int> enoughFood = c => c <= FastFood.availableFood;
        static void Main(string[] args)
        {
            Inputs();
            GetBiggestOrder();
            ServiceClients();
            PrintResult();
        }

        private static void PrintResult() => Console.WriteLine(FastFood.isEmpty(FastFood.queue)
                ? $"Orders complete"
                : $"Orders left: {(string.Join(" ", FastFood.queue))}");
        private static void ServiceClients()
        {
            while (FastFood.isNotEmpty(FastFood.queue))
            {
                if (FastFood.enoughFood(FastFood.queue.Peek()))
                {
                    FastFood.availableFood -= FastFood.queue.Peek();
                    FastFood.queue.Dequeue();
                }
                if(FastFood.isNotEmpty(FastFood.queue))
                    if (FastFood.availableFood - FastFood.queue.Peek() < 0) break;
            }
        }
        private static void Inputs()
        {
            FastFood.availableFood = int.Parse(Console.ReadLine());
            FastFood.queue = new Queue<int>( Console.ReadLine().Split().Select(int.Parse).ToArray());
        }
        private static void GetBiggestOrder() => Console.WriteLine(FastFood.queue.Max());
    }
}
