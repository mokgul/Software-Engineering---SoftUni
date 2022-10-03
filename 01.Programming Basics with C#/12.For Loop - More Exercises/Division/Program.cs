using System;

namespace Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            int countP1 = 0, countP2 = 0, countP3 = 0;

            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num % 2 == 0) countP1++;
                if (num % 3 == 0) countP2++;
                if (num % 4 == 0) countP3++;
            }
            p1 = (countP1 / (double)n) * 100;
            p2 = (countP2 / (double)n) * 100;
            p3 = (countP3 / (double)n) * 100;

            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");

        }
    }
}
