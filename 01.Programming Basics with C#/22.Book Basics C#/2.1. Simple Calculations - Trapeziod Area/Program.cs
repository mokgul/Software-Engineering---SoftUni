using System;

namespace _2._1._Simple_Calculations___Trapeziod_Area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var b1 = double.Parse(Console.ReadLine());
            var b2 = double.Parse(Console.ReadLine());
            var h = double.Parse(Console.ReadLine());
            var area = (b1 + b2) * h / 2.0;
            Console.WriteLine($"Trapezoid area = {area}");
        }
    }
}
