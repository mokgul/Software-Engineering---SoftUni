using System;

namespace Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int integer = int.Parse(Console.ReadLine());
            if (integer % 10 == 0)
                Console.WriteLine("The number is divisible by 10");
            else if (integer % 7 == 0)
                Console.WriteLine("The number is divisible by 7");
            else if (integer % 6 == 0)
                Console.WriteLine("The number is divisible by 6");
            else if (integer % 3 == 0)
                Console.WriteLine("The number is divisible by 3");
            else if (integer % 2 == 0)
                Console.WriteLine("The number is divisible by 2");
            else
                Console.WriteLine("Not divisible");
        }
    }
}