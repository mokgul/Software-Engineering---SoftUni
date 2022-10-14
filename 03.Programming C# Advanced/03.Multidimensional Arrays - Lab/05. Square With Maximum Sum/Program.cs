using System;
using System.Linq;

namespace _05._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(", ").Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i,j] = input[j];
                }
            }

            int maxSum = 0;
            int[,] best = new int[2, 2];
            for(int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int currentSum = 0;
                    if(row + 1 == rows || col + 1 == cols) continue;
                    for (int subRow = row; subRow < row + 2; subRow++)
                    {
                        for (int subCol = col; subCol < col + 2; subCol++)
                        {
                            currentSum += matrix[subRow,subCol];
                        }
                    }
                    if (currentSum > maxSum)
                    {
                        best[0, 0] = matrix[row,col];
                        best[0, 1] = matrix[row, col + 1];
                        best[1, 0] = matrix[row + 1, col];
                        best[1, 1] = matrix[row + 1, col + 1];
                        maxSum = currentSum;
                    }
                }
            }
            for(int i = 0; i < best.GetLength(0);i++)
            {
                for (int j = 0; j < best.GetLength(1); j++)
                {
                    Console.Write($"{best[i,j]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }
    }
}
