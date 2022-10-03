using System;

namespace Division_Without_Remainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int total = 0;
            double p1 = 0, p2 = 0, p3 = 0;
            for (int i = 0; i < numbers; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num % 2 == 0) p1++;
                if (num % 3 == 0) p2++;
                if (num % 4 == 0) p3++;
            }
            p1 = (p1 / numbers) * 100;
            p2 = (p2 / numbers) * 100;
            p3 = (p3 / numbers) * 100;
            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
        }
    }
}
