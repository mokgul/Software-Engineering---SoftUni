using System;
using System.Linq;

namespace _03._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] cols = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < cols.Length; col++)
                    matrix[row, col] = cols[col];

            }

            int sum = 0;
            for (int row = 0; row < size; row++)
                for (int col = 0; col < size; col++)
                {
                    if (row == col)
                        sum += matrix[row, col];
                }

            Console.WriteLine(sum);
        }
    }
}
