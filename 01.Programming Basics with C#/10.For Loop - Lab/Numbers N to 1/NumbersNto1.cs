using System;

namespace Numbers_N_to_1
{
    class NumbersNto1
    {
        static void Main(string[] args)
        {
            int i = 0;
            int num = int.Parse(Console.ReadLine());
            for (i = num; i >= 1; i--)
            {
                Console.WriteLine(i);
            }
        }
    }
}
