using System;

namespace House_Painting
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine()); // x - височина на къща
            double y = double.Parse(Console.ReadLine()); // y - дължина на странична стена
            double h = double.Parse(Console.ReadLine()); // h - височина на триъгълна стена на покрив
            double AreaHouse  = x * x + (x * x - 2.4) + 2 * (x * y - 2.25);
            double AreaRoof   = 2 * (x * h * 0.5) + 2 * (x * y);
            double paintHouse = AreaHouse / 3.4;
            double paintRoof  = AreaRoof / 4.3;
            Console.WriteLine($"{paintHouse:f2}");
            Console.WriteLine($"{paintRoof:f2}");
        }
    }
}
