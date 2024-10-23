using System;

namespace Min_Number
{
    class MinNumber
    {
        static void Main(string[] args)
        {


            int min = int.MaxValue;
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num < min)
                    min = num;
            }
            Console.WriteLine(min);
        }
    }
}