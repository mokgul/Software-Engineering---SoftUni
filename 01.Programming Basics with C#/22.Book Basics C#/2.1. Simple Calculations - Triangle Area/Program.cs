using System;

namespace Trapeziod_Area
{
    class TriangleArea
    {
        static void Main(string[] args)
        {
            double sideA = double.Parse(Console.ReadLine());           
            double height = double.Parse(Console.ReadLine());
            double area = (sideA* height) / 2;
            Console.WriteLine($"Triangle are = {area:f2}");
        }
    }
}