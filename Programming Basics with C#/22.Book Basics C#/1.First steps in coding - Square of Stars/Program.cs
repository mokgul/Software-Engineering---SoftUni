using System;

namespace _1.First_steps_in_coding___Square_of_Stars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if(i == 1) Console.Write("*");
                    else if(i == n) Console.Write("*");
                    else if((j == 1 || j == n) && (i != 1 || i != n))
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }

                Console.WriteLine();
            }
        }
    }
}
