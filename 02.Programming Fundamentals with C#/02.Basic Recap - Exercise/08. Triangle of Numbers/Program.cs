using System;

namespace Triangle_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int n = 1;
            while (n <= num)
            {
                for (int i = 1; i <= n; i++)
                {
                    Console.Write($"{n} ");
                }
                n++;
                Console.WriteLine();
            }
        }
    }
}