using System;

namespace Fuel_Tank___Part_2
{
    class FuelTank2
    {
        static void Main(string[] args)
        {
            double gasoline = 2.22;
            double diesel   = 2.33;
            double gas      = 0.93;
            double discount = 0;

            string fuelType   = Console.ReadLine();
            double fuelAmount = double.Parse(Console.ReadLine());
            string clubCard   = Console.ReadLine();

            if (clubCard == "Yes")
            {
                gasoline -= 0.18;
                diesel   -= 0.12;
                gas      -= 0.08;
            }

            if (fuelAmount >= 20 && fuelAmount <= 25)
                discount = 0.08;
            else if (fuelAmount > 25)
                discount = 0.10;

            if (fuelType == "Gasoline")
            {
                double total = fuelAmount * gasoline;
                total -= total * discount;
                Console.WriteLine($"{total:f2} lv.");
            }
            else if (fuelType == "Diesel")
            {
                double total = fuelAmount * diesel;
                total -= total * discount;
                Console.WriteLine($"{total:f2} lv.");
            }
            else if (fuelType == "Gas")
            {
                double total = fuelAmount * gas;
                total -= total * discount;
                Console.WriteLine($"{total:f2} lv.");
            }
        }
    }
}
