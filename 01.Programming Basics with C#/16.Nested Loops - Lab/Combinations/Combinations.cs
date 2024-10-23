using System;

namespace Combinations
{
    class Combinations
    {
        static void Main(string[] args)
        {
            int count = 0;
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    for (int k = 0; k <= n; k++)
                    {
                        if (i + j + k == n)
                            count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
