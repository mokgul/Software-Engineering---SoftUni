using System;

namespace _2._1._Simple_Calculations___Radians_to_Degrees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double radians = double.Parse(Console.ReadLine());
            double degrees = Math.Round(radians * (180 / Math.PI));
            Console.WriteLine(degrees);
        }
    }
}
