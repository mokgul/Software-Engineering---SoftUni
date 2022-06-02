using System;

namespace Even_Powers_of_2
{
    class EvenPowersOf2
    {
        static void Main(string[] args)
        {
            int num = 1;
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i <= n; i += 2)
            {
                Console.WriteLine(num);
                num *= 4;
            }
        }
    }
}
