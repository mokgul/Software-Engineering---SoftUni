using System;

namespace Trapeziod_Area
{
    class TrapezoidArea
    {
        static void Main(string[] args)
        {
            var sideA  = double.Parse(Console.ReadLine());
            var sideB  = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            var area   = ((sideA + sideB) * height) / 2.0;
            Console.WriteLine($"Trapezoid area = {area:f2}");
        }
    }
}
