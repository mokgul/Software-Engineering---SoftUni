using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new Car(120, 20);
            car.Drive(2);
            Console.WriteLine(car.Fuel);
        }
    }
}
