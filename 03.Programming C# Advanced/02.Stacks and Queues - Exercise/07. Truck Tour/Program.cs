using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    internal class TruckTour
    {
        private static Queue<int[]> pumps = new Queue<int[]>();
        private static int bestRoute;
        static void Main(string[] args)
        {
            Inputs();
            GetBestRoute();
            Console.WriteLine(TruckTour.bestRoute);
        }

        private static void GetBestRoute()
        {
            for (int i = 0; i < TruckTour.pumps.Count; i++)
            {
                int fuel = 0;
                bool routeFull = true;
                for (int j = 0; j < TruckTour.pumps.Count; j++)
                {
                    int[] info = TruckTour.pumps.Peek();
                    fuel += info[0];
                    int distance = info[1];
                    fuel -= distance;
                    if (fuel < 0)
                        routeFull = false;
                    TruckTour.pumps.Enqueue(TruckTour.pumps.Dequeue());
                }

                if (routeFull)
                {
                    TruckTour.bestRoute = i;
                    break;
                }
                TruckTour.pumps.Enqueue(TruckTour.pumps.Dequeue());
            }
        }

        private static void Inputs()
        {
            int pumpsQty = int.Parse(Console.ReadLine());
            for(int i = 0; i < pumpsQty; i++)
                pumps.Enqueue(Console.ReadLine().Split().Select(int.Parse).ToArray());
        }
    }
}
