using System;

namespace _4._Bit_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int position = int.Parse(Console.ReadLine());
            int mask = ~(1 << position);
            int newNumber = mask & num;
            Console.WriteLine(newNumber);
        }
    }
}
