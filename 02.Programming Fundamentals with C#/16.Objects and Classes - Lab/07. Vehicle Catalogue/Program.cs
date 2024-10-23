using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace _07._Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();

            string line = Console.ReadLine();
            while (line != "end")
            {
                string[] tokens = line.Split("/");
                if (tokens[0] == "Car")
                {
                    Car car = new Car()
                    {
                        Brand = tokens[1],
                        Model = tokens[2],
                        HorsePower = int.Parse(tokens[3])
                    };
                    catalog.Cars.Add(car);
                }
                else
                {
                    Truck truck = new Truck()
                    {
                        Brand = tokens[1],
                        Model = tokens[2],
                        Weight = int.Parse(tokens[3])
                    };
                    catalog.Trucks.Add(truck);
                }
                line = Console.ReadLine();
            }

            List<Car> carsOrderedByBrand = new List<Car>();
            List<Truck> trucksOrderedByBrand = new List<Truck>();
            carsOrderedByBrand = catalog.Cars.OrderBy(s => s.Brand).ToList();
            trucksOrderedByBrand = catalog.Trucks.OrderBy(s => s.Brand).ToList();

            Print(carsOrderedByBrand, trucksOrderedByBrand);
        }

        private static void Print(List<Car> orderedCars, List<Truck> orderedTrucks)
        {
            if (orderedCars.Count != 0)
            {
                Console.WriteLine($"Cars:");
                foreach (Car car in orderedCars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (orderedTrucks.Count != 0)
            {
                Console.WriteLine($"Trucks:");
                foreach (Truck truck in orderedTrucks)
                {
                    {
                        Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                    }
                }
            }

        }
    }
    class Truck
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public int Weight { get; set; }
    }

    class Car
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public int HorsePower { get; set; }
    }

    class Catalog
    {
        public Catalog()
        {
            Cars = new List<Car>();
            Trucks = new List<Truck>();
        }
        public List<Car> Cars { get; set; }

        public List<Truck> Trucks { get; set; }

    }
}
