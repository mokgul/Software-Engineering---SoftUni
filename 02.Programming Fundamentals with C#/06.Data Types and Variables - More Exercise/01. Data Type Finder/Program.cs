using System;

namespace _01._Data_Type_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool correctType = false;
            int integer = 0;
            float floatingPoint = 0f;
            char characters = ' ';
            bool boolean;

            string input = Console.ReadLine();
            while (input != "END")
            {
                if (correctType = int.TryParse(input, out integer))
                    Console.WriteLine($"{input} is integer type");

                else if (correctType = float.TryParse(input, out floatingPoint))
                    Console.WriteLine($"{input} is floating point type");

                else if (correctType = char.TryParse(input, out characters))
                    Console.WriteLine($"{input} is character type");

                else if (correctType = bool.TryParse(input, out boolean))
                    Console.WriteLine($"{input} is boolean type");

                else
                {
                    Console.WriteLine($"{input} is string type");
                }
                input = Console.ReadLine();
            }
        }
    }
}