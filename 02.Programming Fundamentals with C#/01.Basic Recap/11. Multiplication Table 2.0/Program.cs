using System;

namespace Multiplication_Table_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int integer = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());

            for (int i = multiplier; i <= 10; i++)
            {
                Console.WriteLine($"{integer} X {i} = {integer * i}");
            }
            if(multiplier > 10)
                Console.WriteLine($"{integer} X {multiplier} = {integer * multiplier}");
        }
    }
}