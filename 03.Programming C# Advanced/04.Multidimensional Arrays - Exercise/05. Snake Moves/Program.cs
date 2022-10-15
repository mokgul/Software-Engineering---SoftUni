using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _05._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            string snake = Console.ReadLine();
            Queue<char> symbols = new Queue<char>();
            int rows = dimensions[0];
            int cols = dimensions[1];
            char[,] matrix = new char[rows,cols];

            int snakeIndex = 0;
            for (int i = 0; i < rows * cols; i++)
            {
                symbols.Enqueue(snake[snakeIndex]);
                snakeIndex++;
                if (snakeIndex == snake.Length)
                    snakeIndex = 0;
            }

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row,col] = symbols.Dequeue();
                    }
                }

                if (row % 2 != 0)
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row,col] = symbols.Dequeue();
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row,col]);
                }

                Console.WriteLine();
            }
        }
    }
}
