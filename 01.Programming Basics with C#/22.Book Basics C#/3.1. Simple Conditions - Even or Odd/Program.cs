using System;

namespace _3._1._Simple_Conditions___Even_or_Odd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            if (num % 2 == 0)
                Console.WriteLine("even");
            else
                Console.WriteLine("odd");
        }
    }
}
