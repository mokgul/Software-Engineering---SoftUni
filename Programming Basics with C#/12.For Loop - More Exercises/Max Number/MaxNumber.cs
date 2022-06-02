using System;

namespace Max_Number
{
    class MaxNumber
    {
        static void Main(string[] args)
        {
            int max = int.MinValue;
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num > max)
                    max = num;
            }
            Console.WriteLine(max);
        }
    }
}
