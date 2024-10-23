using System;

namespace _07._NxN_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            PrintMatrix(number);
        }

        private static void PrintMatrix(int filler)
        {
            for (int i = 0; i < filler; i++)
            {
                for (int j = 0; j < filler; j++)
                {
                    Console.Write(filler + " ");
                }
                Console.WriteLine();
            }
        }
    }
}