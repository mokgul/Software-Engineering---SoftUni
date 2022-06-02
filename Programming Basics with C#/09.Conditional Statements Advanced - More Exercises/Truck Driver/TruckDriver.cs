using System;

namespace Truck_Driver
{
    class TruckDriver
    {
        static void Main(string[] args)
        {
            //declaration
            // .. = {spring/autumn , summer, winter }
            string[] distanceOne = { "0.75", "0.90", "1.05" }; // for <=5000 km travelled per month
            string[] distanceTwo = { "0.95", "1.10", "1.25" }; // for 5000<..<=10 000 km travelled per month
            double distanceThree = 1.45; // for 10 000<...<=20 000 km travelled per month 
            double taxes = 0.10;
            double money = 0.00;

            //input
            string season = Console.ReadLine();
            double distanceTravelled = double.Parse(Console.ReadLine());

            //calculation
            if (distanceTravelled > 10000 && distanceTravelled <= 20000)
                money = 4 * (distanceTravelled * distanceThree);
            else if (distanceTravelled <= 10000)
            {
                switch (season)
                {
                    case "Spring":
                    case "Autumn":
                        if (distanceTravelled <= 5000)
                            money = 4 * (distanceTravelled * double.Parse(distanceOne[0]));
                        else if (distanceTravelled <= 10000)
                            money = 4 * (distanceTravelled * double.Parse(distanceTwo[0]));
                        break;
                    case "Summer":
                        if (distanceTravelled <= 5000)
                            money = 4 * (distanceTravelled * double.Parse(distanceOne[1]));
                        else if (distanceTravelled <= 10000)
                            money = 4 * (distanceTravelled * double.Parse(distanceTwo[1])); break;
                    case "Winter":
                        if (distanceTravelled <= 5000)
                            money = 4 * (distanceTravelled * double.Parse(distanceOne[2]));
                        else if (distanceTravelled <= 10000)
                            money = 4 * (distanceTravelled * double.Parse(distanceTwo[2])); break;
                }
            }
            money -= money * taxes;

            //output
            Console.WriteLine("{0:0.00}", money);
        }
    }
}
