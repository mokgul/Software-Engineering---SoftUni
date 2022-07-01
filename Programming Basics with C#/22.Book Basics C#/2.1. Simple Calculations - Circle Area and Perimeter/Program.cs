using System;

namespace _2._1._Simple_Calculations___Circle_Area_and_Perimeter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter circle radius. r = ");
            double radius = double.Parse(Console.ReadLine());
            double area = Math.PI * radius * radius;
            double perimeter = 2 * Math.PI * radius;
            Console.WriteLine($"Area = {area}");
            Console.WriteLine($"Petimeter = {perimeter}");
        }
    }
}
