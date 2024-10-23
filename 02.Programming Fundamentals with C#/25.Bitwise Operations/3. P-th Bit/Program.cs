using System;

namespace _3._P_th_Bit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int position = int.Parse(Console.ReadLine());
            int bitAtPosition = (num >> position) & 1;
            Console.WriteLine(bitAtPosition);
        }
    }
}
