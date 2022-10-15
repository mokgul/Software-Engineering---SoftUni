using System;
using System.Diagnostics.Tracing;
using System.Linq;

namespace _02._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];

            char[,] matrix = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                char[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                    matrix[i, j] = input[j];
            }

            int found = 0;
            bool isEqual = false;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row + 2 - 1 < rows && col + 2 - 1 < cols)
                    {
                        isEqual = false;

                        for (int currentRow = row; currentRow < row + 2 - 1; currentRow++)
                        {
                            for (int currentCol = col; currentCol < col + 2 - 1; currentCol++)
                            {
                                if (matrix[currentRow, currentCol] == matrix[currentRow, currentCol + 1]
                                    && matrix[currentRow, currentCol] == matrix[currentRow + 1, currentCol]
                                    && matrix[currentRow, currentCol] == matrix[currentRow + 1, currentCol + 1])
                                {
                                    isEqual = true;
                                }
                                else
                                {
                                    isEqual = false;
                                    break;
                                }
                            }

                            if (!isEqual)
                            {
                                break;
                            }
                        }
                        if (isEqual)
                        {
                            found++;
                        }
                    }

                }
            }

            Console.WriteLine(found);
        }
    }
}