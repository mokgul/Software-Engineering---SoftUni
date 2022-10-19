using System;
using System.Collections.Generic;

namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] tokens = input.Split(", ");
                string command = tokens[0];
                string car = tokens[1];
                if(command == "IN")
                    cars.Add(car);
                if (command == "OUT")
                {
                    if (cars.Contains(car))
                        cars.Remove(car);
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(cars.Count > 0 ?
                $"{string.Join(Environment.NewLine, cars)}"
                : $"Parking Lot is Empty");
        }
    }
}
