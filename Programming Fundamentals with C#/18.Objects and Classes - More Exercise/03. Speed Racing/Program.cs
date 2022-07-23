using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Speed_Racing
{
    class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumption = fuelConsumption;
            Distance = 0;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }

        public double FuelConsumption { get; set; }
        //per km

        public int Distance { get; set; }

        public void Drive(int amountOfKm)
        {
            double fuelNeeded = amountOfKm * this.FuelConsumption;
            if (fuelNeeded <= this.FuelAmount)
            {
                this.FuelAmount -= fuelNeeded;
                this.Distance += amountOfKm;
            }
            else
            {
                Console.WriteLine($"Insufficient fuel for the drive");
            }
        }

        public void Print(Car car)
        {
            Console.WriteLine($"{this.Model} {this.FuelAmount:f2} {this.Distance}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = GetInfo();
            cars = Action(cars);
            cars.ForEach(c => c.Print(c));
        }

        private static List<Car> GetInfo()
        {
            List<Car> cars = new List<Car>();

            int carsAmount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carsAmount; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                string model = line[0];
                double fuelAmount = int.Parse(line[1]);
                double fuelConsumption = double.Parse(line[2]);

                Car car = new Car(model, fuelAmount, fuelConsumption);
                cars.Add(car);
            }
            return cars;
        }

        private static List<Car> Action(List<Car> cars)
        {
            string action = Console.ReadLine();
            while (action != "End")
            {
                string[] tokens = action.Split(' ');
                string model = tokens[1];
                int amountOfKm = int.Parse(tokens[2]);

                foreach (Car car in cars.Where(c => c.Model == model))
                {
                    car.Drive(amountOfKm);
                }
                action = Console.ReadLine();
            }

            return cars;
        }
    }
}
