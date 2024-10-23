using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace _06._Vehicle_Catalogue
{
    class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsepower)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.Horsepower = horsepower;
        }
        public string Type { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int Horsepower { get; set; }

        public void ToSting()
        {
            Console.WriteLine($"Type: {char.ToUpper(this.Type[0]) + this.Type.Substring(1)}");
            Console.WriteLine($"Model: {this.Model}");
            Console.WriteLine($"Color: {this.Color}");
            Console.WriteLine($"Horsepower: {this.Horsepower}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> catalog = GetInfo();
            ReadInfo(catalog);
            GetAverage(catalog);
        }

        private static List<Vehicle> GetInfo()
        {
            List<Vehicle> catalog = new List<Vehicle>();
            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] tokens = line.Split(' ');
                Vehicle vehicle = new Vehicle
                    (tokens[0], tokens[1], tokens[2], int.Parse(tokens[3]));
                catalog.Add(vehicle);
                line = Console.ReadLine();
            }
            return catalog;
        }

        private static void ReadInfo(List<Vehicle> catalog)
        {
            string info = Console.ReadLine();
            while (info != "Close the Catalogue")
            {
                Print(info, catalog);
                info = Console.ReadLine();
            }
        }

        private static void Print(string info, List<Vehicle> catalog)
        {
            Vehicle temp = catalog.Find(x => x.Model == info);
            if (temp != null)
                temp.ToSting();
        }

        private static void GetAverage(List<Vehicle> catalog)
        {
            List<Vehicle> trucks = catalog.Where(x => x.Type == "truck").ToList();
            List<Vehicle> cars = catalog.Where(x => x.Type == "car").ToList();

            if (cars.Count > 0)
            {
                double carsAvrHp = cars.Sum(x => x.Horsepower) / (double)cars.Count;
                Console.WriteLine($"Cars have average horsepower of: {carsAvrHp:f2}.");
            }
            else
                Console.WriteLine("Cars have average horsepower of: 0.00.");

            if (trucks.Count > 0)
            {
                double trucksAvrHp = trucks.Sum(x => x.Horsepower) / (double)trucks.Count;
                Console.WriteLine($"Trucks have average horsepower of: {trucksAvrHp:f2}.");
            }
            else
                Console.WriteLine("Trucks have average horsepower of: 0.00.");
        }
    }
}
