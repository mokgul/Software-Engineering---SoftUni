using System;

namespace Celsius_to_Fahrenheit
{
    class CelsToFahr
    {
        static void Main(string[] args)
        {
           var celsius    = double.Parse(Console.ReadLine());
           var fahrenheit = celsius * 1.8 + 32;
            Console.WriteLine($"{fahrenheit:f2}");
        }
    }
}
