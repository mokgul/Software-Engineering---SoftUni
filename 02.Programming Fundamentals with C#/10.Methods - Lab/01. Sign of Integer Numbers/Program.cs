using System;

namespace _01._Sign_of_Integer_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int integer = int.Parse(Console.ReadLine());
            CheckNumber(integer);
        }

        static void CheckNumber(int a)
        {
            if (a > 0)
                Console.WriteLine($"The number {a} is positive.");
            else if (a < 0)
                Console.WriteLine($"The number {a} is negative.");
            else
            {
                Console.WriteLine($"The number {a} is zero.");
            }
        }
    }
}