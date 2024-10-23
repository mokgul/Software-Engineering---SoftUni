using System;

namespace Number_in_Range
{
    class NumberInRange
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            if (num >= -100 && num <= 100 && num != 0)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
        }
    }
}
