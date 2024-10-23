using System;

namespace N_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            decimal num = 0;
            decimal sum = 0;
            int n = int.Parse(Console.ReadLine());
            for (i = 1; i <= n ;i++)
            {
                num = decimal.Parse(Console.ReadLine());
                sum += num;
            }
            Console.WriteLine(sum);
        }
    }
}
