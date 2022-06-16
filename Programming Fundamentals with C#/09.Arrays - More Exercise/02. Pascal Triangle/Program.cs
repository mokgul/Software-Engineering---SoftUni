using System;
using System.Linq;

namespace _02._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int element = 1;

            for (int i = 0; i < lines; i++)
            {
                int[] sequence = new int[i + 1];
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0 || i == 0)
                    {
                        element = 1;
                        sequence[j] = element;
                    }
                    else
                    {
                        element = element * (i - j + 1) / j;
                        sequence[j] = element;
                    }
                }

                foreach (int item in sequence)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }
    }
}