using System;

namespace Sum_of_Odd_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;
            int n = 1;
            while (num > 0)
            {
                if( n % 2 == 1)
                {
                    Console.WriteLine(n);
                    sum += n;
                    num--;
                }
                n += 2;
            }
            Console.WriteLine($"Sum: {sum}");
            
        }
    }
}

