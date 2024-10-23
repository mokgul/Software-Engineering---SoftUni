using System;

namespace _07._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            long[][] matrix = new long[rows][];
            matrix[0] = new long[] { 1 };

            for (int i = 1; i < rows; i++)
            {
                matrix[i] = new long[i + 1];
                for (int j = 0; j < i + 1; j++)
                {
                    long upper = j >= matrix[i - 1].Length ? 0 : matrix[i - 1][j];
                    long upperLeft = j - 1 < 0 ? 0 : matrix[i - 1][j - 1];
                    matrix[i][j] = upper + upperLeft;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
