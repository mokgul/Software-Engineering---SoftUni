using System;

namespace Circle_Area_and_Perimeter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter circle radius. r = ");
            var r = double.Parse(Console.ReadLine());
            var area = r * r * Math.PI;
            var perimeter = 2 * r * Math.PI;
            Console.WriteLine($"Area = {area:f2}");
            Console.WriteLine($"Perimeter = {perimeter:f2}");
        }
    }
}
