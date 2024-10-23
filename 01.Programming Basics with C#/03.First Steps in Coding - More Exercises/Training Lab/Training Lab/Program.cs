using System;

namespace Training_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double h = Math.Floor((lenght * 100) / 120);
            double w = Math.Floor((height * 100 - 100) / 70);
            var seats = h * w - 3;
            Console.WriteLine($"{seats:f0}");
        }
    }
}
