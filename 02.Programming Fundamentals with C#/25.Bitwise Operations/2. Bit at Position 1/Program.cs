using System;

namespace _2._Bit_at_Position_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int bitAtPosition = 1;
            int bit = (n >> bitAtPosition) & 1;
            Console.WriteLine(bit);
        }
    }
}
