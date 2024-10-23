using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _08._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];


            for (int i = 0; i < size; i++)
            {
                int[] column = Console.ReadLine()
                    .Split().Select(int.Parse).ToArray();
                for (int j = 0; j < column.Length; j++)
                {
                    matrix[i, j] = column[j];
                }
            }

            Queue<int> coordinates = new Queue<int>(
                Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray());
            int bombRow = 0;
            int bombCol = 0;
            while (coordinates.Count > 0)
            {
                bombRow = coordinates.Dequeue();
                bombCol = coordinates.Dequeue();
                if(matrix[bombRow,bombCol] > 0)
                    ExplodeCell(matrix, bombRow, bombCol);
            }

            int aliveCells = 0;
            int sumAliveCells = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        aliveCells++;
                        sumAliveCells += matrix[i, j];
                    }
                }
            }

            Print(aliveCells, sumAliveCells, size, matrix);
        }

        private static void Print(int aliveCells, int sumAliveCells, int size, int[,] matrix)
        {
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumAliveCells}");

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void ExplodeCell(int[,] matrix, int bombRow, int bombCol)
        {
            int bombValue = matrix[bombRow, bombCol];
            int size = matrix.GetLength(0);
            matrix[bombRow, bombCol] = 0;

            if (ValidIndex(bombRow - 1, bombCol - 1, size))
                if (matrix[bombRow - 1, bombCol - 1] > 0)
                    matrix[bombRow - 1, bombCol - 1] -= bombValue;

            if (ValidIndex(bombRow - 1, bombCol, size))
                if (matrix[bombRow - 1, bombCol] > 0)
                    matrix[bombRow - 1, bombCol] -= bombValue;

            if (ValidIndex(bombRow - 1, bombCol + 1, size))
                if (matrix[bombRow - 1, bombCol + 1] > 0)
                    matrix[bombRow - 1, bombCol + 1] -= bombValue;

            if (ValidIndex(bombRow, bombCol - 1, size))
                if (matrix[bombRow, bombCol - 1] > 0)
                    matrix[bombRow, bombCol - 1] -= bombValue;

            if (ValidIndex(bombRow, bombCol + 1, size))
                if (matrix[bombRow, bombCol + 1] > 0)
                    matrix[bombRow, bombCol + 1] -= bombValue;

            if (ValidIndex(bombRow + 1, bombCol - 1, size))
                if (matrix[bombRow + 1, bombCol - 1] > 0)
                    matrix[bombRow + 1, bombCol - 1] -= bombValue;

            if (ValidIndex(bombRow + 1, bombCol, size))
                if (matrix[bombRow + 1, bombCol] > 0)
                    matrix[bombRow + 1, bombCol] -= bombValue;

            if (ValidIndex(bombRow + 1, bombCol + 1, size))
                if (matrix[bombRow + 1, bombCol + 1] > 0)
                    matrix[bombRow + 1, bombCol + 1] -= bombValue;
        }

        private static bool ValidIndex(int row, int col, int size)
            => row >= 0 && row < size && col >= 0 && col < size;
    }
}
