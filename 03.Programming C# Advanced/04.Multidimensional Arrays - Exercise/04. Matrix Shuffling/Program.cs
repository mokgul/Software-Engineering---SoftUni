using System;
using System.Drawing;
using System.Linq;

namespace _04._Matrix_Shuffling
{
    internal class Matrix
    {
        private static string[,] _matrix;
        static void Main(string[] args)
        {
            Input();
            Commands();
        }

        private static void Commands()
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "END") break;
                string[] commands = line.Split(' ');
                if (!IsCommandValid(commands))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                if (!ValidCoordinates(commands[1], commands[2], commands[3], commands[4]))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                SwapElements(commands);
                PrintMatrix();
            }
        }

        private static void PrintMatrix()
        {
            for (int i = 0; i < Matrix._matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix._matrix.GetLength(1); j++)
                {
                    Console.Write(Matrix._matrix[i,j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void SwapElements(string[] commands)
        {
            int row1 = int.Parse(commands[1]);
            int col1 = int.Parse(commands[2]);
            int row2 = int.Parse(commands[3]);
            int col2 = int.Parse(commands[4]);

            (Matrix._matrix[row1, col1], Matrix._matrix[row2, col2]) 
                = (Matrix._matrix[row2, col2], Matrix._matrix[row1, col1]);
        }

        private static bool ValidCoordinates(string rowOld, string colOld, string rowNew, string colNew)
        {
            int row1 = int.Parse(rowOld);
            int col1 = int.Parse(colOld);
            int row2 = int.Parse(rowNew);
            int col2 = int.Parse(colNew);
            bool valid = true;
            valid = (row1 >= 0 && row1 < Matrix._matrix.GetLength(0))
                    && (col1 >= 0 && col1 < Matrix._matrix.GetLength(1))
                    && (row2 >= 0 && row2 < Matrix._matrix.GetLength(0))
                    && (col2 >= 0 && col2 < Matrix._matrix.GetLength(1))
                ? true
                : false;
            return valid;
        }
        

        private static bool IsCommandValid(string[] commands)
        {
            bool valid = true;
            valid = commands[0] == "swap" ? true : false;
            valid = commands.Length == 5 ? true : false;
            return valid;
        }

        private static void Input()
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            Matrix._matrix = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] column = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                for (int j = 0; j < cols; j++)
                {
                    Matrix._matrix[i, j] = column[j];
                }
            }
        }
    }
}
