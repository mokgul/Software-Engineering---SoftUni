using System;

namespace Even_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isEven = false;
            int integer = 0;
            while (!isEven)
            {
                integer = int.Parse(Console.ReadLine());
                isEven = (integer % 2 == 0) ? true : false;
                if (!isEven)
                    Console.WriteLine("Please write an even number.");
            }
            Console.WriteLine($"The number is: {Math.Abs(integer)}");
        }
    }
}