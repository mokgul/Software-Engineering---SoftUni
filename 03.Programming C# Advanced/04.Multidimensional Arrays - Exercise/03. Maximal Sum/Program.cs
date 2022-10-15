using System;
using System.Linq;

namespace _03._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int square = 3;
            int rows = dimensions[0];
            int cols = dimensions[1];
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                int[] columns = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = columns[j];
                }
            }

            int maxSum = 0;
            int bestRow = 0;
            int bestCol = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row + square - 1 < rows && col + square - 1 < cols)
                    {
                        int currentSum = 0;
                        for (int currRow = row; currRow < row + square; currRow++)
                        {
                            for (int currCol = col; currCol < col + square; currCol++)
                            {
                                currentSum += matrix[currRow, currCol];
                            }
                        }

                        if (currentSum > maxSum)
                        {
                            maxSum = currentSum;
                            bestRow = row;
                            bestCol = col;
                        }
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int i = bestRow; i < bestRow + square; i++)
            {
                for (int j = bestCol; j < bestCol + square; j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
