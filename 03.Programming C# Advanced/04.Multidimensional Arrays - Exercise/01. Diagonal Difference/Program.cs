using System;
using System.Linq;

namespace _01._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            int left = 0;
            int right = 0;
            for (int i = 0; i < size; i++)
            {
                int[] cols = Console.ReadLine()
                    .Split().Select(int.Parse).ToArray();
                for(int j = 0; j < cols.Length; j++)
                {
                    matrix[i, j] = cols[j];
                    if (i == j)
                        left += matrix[i, j];
                }
                right += matrix[i, size - 1 - i];
            }

            Console.WriteLine(Math.Abs(left - right));
        }
    }
}
