using System;

namespace Barcode_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            int start1000s = start / 1000;
            int end1000s = end / 1000;
            int start100s = (start / 100) % 10;
            int end100s = (end / 100) % 10;
            int start10s = (start % 100) / 10;
            int end10s = (end % 100) / 10;
            int start1s = (start % 100) % 10;
            int end1s = (end % 100) % 10;

            for (int i = start1000s; i <= end1000s; i++)
            {
                for (int j = start100s; j <= end100s; j++)
                {
                    for (int k = start10s; k <= end10s; k++)
                    {
                        for (int m = start1s; m <= end1s; m++)
                        {
                            if (i % 2 != 0 && j % 2 != 0 & k % 2 != 0 && m % 2 != 0)
                                Console.Write($"{i}{j}{k}{m} ");
                        }
                    }
                }
            }
        }
    }
}
