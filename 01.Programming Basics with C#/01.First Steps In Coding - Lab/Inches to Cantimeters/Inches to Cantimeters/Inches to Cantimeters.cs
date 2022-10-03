using System;

namespace Inches_to_Cantimeters
{
    class InchToCm
    {
        static void Main(string[] args)
        {
            Console.Write("Inches = ");
            var inches      = double.Parse(Console.ReadLine());
            var centimeters = 2.54 * inches;
            Console.Write("Centimeters = ");
            Console.WriteLine(centimeters);
        }
    }
}
