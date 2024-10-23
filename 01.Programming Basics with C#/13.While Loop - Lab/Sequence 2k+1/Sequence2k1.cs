using System;

namespace Sequence_2k_1
{
    class Sequence2k1
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = 1;
            while (k <= n)
            {
                Console.WriteLine(k);
                k = 2 * k + 1;
            }
        }
    }
}
