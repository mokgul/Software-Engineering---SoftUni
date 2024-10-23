using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Raw_Data
{
    internal class Program
    {
        class Car
        {
            public Car(string[] info)
            {
                this.Model = info[0];
                this.Engine = new Engine(int.Parse(info[1]), int.Parse(info[2]));
                this.Cargo = new Cargo(int.Parse(info[3]), info[4]);
            }
            public string Model { get; set; }
            public Engine Engine { get; set; }
            public Cargo Cargo { get; set; }

            public void Print(Car car)
            {
                Console.WriteLine($"{this.Model}");
            }
        }

        class Engine
        {
            public Engine(int speed, int power)
            {
                this.EngineSpeed = speed;
                this.EnginePower = power;
            }
            public int EngineSpeed { get; set; }
            public int EnginePower { get; set; }
        }

        class Cargo
        {
            public Cargo(int weight, string type)
            {
                this.CargoWeight = weight;
                this.CargoType = type;
            }
            public int CargoWeight { get; set; }
            public string CargoType { get; set; }
        }
        static void Main(string[] args)
        {
            List<Car> cars = GetInfo();
            string command = Console.ReadLine();
            List<Car> request = (command == "fragile") ? GetFragile(cars) : GetFlamable(cars);
            request.ForEach(car => car.Print(car));
        }

        private static List<Car> GetInfo()
        {
            List<Car> cars = new List<Car>();

            int carsAmount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carsAmount; i++)
            {
                string[] info = Console.ReadLine().Split(' ');
                Car car = new Car(info);
                cars.Add(car);
            }
            return cars;
        }

        private static List<Car> GetFragile(List<Car> cars)
        {
            List<Car> fragile = new List<Car>();
            foreach (Car car in cars.Where(c => c.Cargo.CargoType == "fragile"))
            {
                if (car.Cargo.CargoWeight < 1000)
                    fragile.Add(car);
            }

            return fragile;
        }

        private static List<Car> GetFlamable(List<Car> cars)
        {
            List<Car> flamable = new List<Car>();
            foreach (Car car in cars.Where(c => c.Cargo.CargoType == "flamable"))
            {
                if (car.Engine.EnginePower > 250)
                    flamable.Add(car);
            }
            return flamable;
        }
    }
}
