using System;

namespace Even_or_Odd
{
    class EvenOrOdd
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            if (num % 2 == 0)
            {
                Console.WriteLine("even");
            }
            else { Console.WriteLine("odd"); }
        }
    }
}
