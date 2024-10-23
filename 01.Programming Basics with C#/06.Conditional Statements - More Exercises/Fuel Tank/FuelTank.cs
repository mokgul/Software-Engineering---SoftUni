using System;


namespace Fuel_Tank
{
    class FuelTank
    {
        static void Main(string[] args)
        {
            string fuelType = "Diesel, Gasoline, Gas";
            string fuel     = Console.ReadLine();
            double liters   = double.Parse(Console.ReadLine());
            if (fuelType.Contains(fuel))
            {
                fuel = fuel.ToLower();
                if (liters >= 25)
                {
                    Console.WriteLine($"You have enough {fuel}.");
                }
                else if (liters < 25)
                {
                    Console.WriteLine($"Fill your tank with {fuel}!");
                }
            }
            else
            {
                Console.WriteLine("Invalid fuel!");
            }    
        }
    }
}
