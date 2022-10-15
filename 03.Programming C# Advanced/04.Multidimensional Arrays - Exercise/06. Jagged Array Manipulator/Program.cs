using System;
using System.Linq;

namespace _06._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] column = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                matrix[i] = new int[column.Length];
                for (int j = 0; j < column.Length; j++)
                {
                    matrix[i][j] = column[j];
                }
            }

            for (int row = 0; row < rows - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int col = 0; col <= matrix[row].Length - 1; col++)
                    {
                        matrix[row][col] *= 2;
                        matrix[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col <= matrix[row].Length - 1; col++)
                    {
                        matrix[row][col] /= 2;
                    }

                    for (int col = 0; col < matrix[row + 1].Length; col++)
                    {
                        matrix[row + 1][col] /= 2;
                    }
                }
            }
            string line = Console.ReadLine();
            while (line != "End")
            {
                string[] tokens = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);
                if (tokens[0] == "Add")
                {
                    if (ValidIndex(row, col, matrix))
                    {
                        matrix[row][col] += value;
                    }
                }

                if (tokens[0] == "Subtract")
                {
                    if (ValidIndex(row, col, matrix))
                    {
                        matrix[row][col] -= value;
                    }
                }
                line = Console.ReadLine();
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static bool ValidIndex(int row, int col, int[][] matrix)
            => row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
    }
}
