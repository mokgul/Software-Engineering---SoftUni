using System;

namespace Logistics
{
    class Logistics
    {
        static void Main(string[] args)
        {
            int microbusPrice = 200; // per ton
            int truckPrice = 175; // per ton
            int trainPrice = 120; // per ton
            int microbusTons = 0;
            int truckTons = 0;
            int trainTons = 0;
            int totalTons = 0;
            double averagePrice = 0;
            double microbusPerc = 0, truckPerc = 0, trainPerc = 0;

            int loadsQty = int.Parse(Console.ReadLine());
            for (int i = 0; i < loadsQty; i++)
            {
                int tonsPerLoad = int.Parse(Console.ReadLine());
                if (tonsPerLoad <= 3)
                    microbusTons += tonsPerLoad;
                else if (tonsPerLoad <= 11)
                    truckTons += tonsPerLoad;
                else if (tonsPerLoad > 11)
                    trainTons += tonsPerLoad;
                totalTons += tonsPerLoad;
            }
            averagePrice = (microbusTons * microbusPrice + truckTons * truckPrice + trainTons * trainPrice) / (double)totalTons;
            microbusPerc = (microbusTons / (double)totalTons) * 100;
            truckPerc = (truckTons / (double)totalTons) * 100;
            trainPerc = (trainTons / (double)totalTons) * 100;

            Console.WriteLine("{0:0.00}", averagePrice);
            Console.WriteLine($"{microbusPerc:f2}%");
            Console.WriteLine($"{truckPerc:f2}%");
            Console.WriteLine($"{trainPerc:f2}%");
        }
    }
}
