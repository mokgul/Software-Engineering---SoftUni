using System;
using System.Linq;

namespace _06._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rows][];

            CreateMatrix(rows, matrix);
            Commands(matrix);
            PrintMatrix(matrix);
        }

        private static void CreateMatrix(int rows, int[][] matrix)
        {
            for (int i = 0; i < rows; i++)
            {
                int[] cols = Console.ReadLine().Split().Select(int.Parse).ToArray();
                matrix[i] = new int[cols.Length];
                for (int j = 0; j < cols.Length; j++)
                {
                    matrix[i][j] = cols[j];
                }
            }
        }

        private static void Commands(int[][] matrix)
        {
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] tokens = command.Split();
                switch (tokens[0])
                {
                    case "Add":
                        AddValueToElement(matrix, tokens);
                        break;
                    case "Subtract":
                        SubtractValue(matrix, tokens);
                        break;
                }

                command = Console.ReadLine();
            }
        }

        private static void PrintMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
        private static void SubtractValue(int[][] matrix, string[] tokens)
        {
            int row = int.Parse(tokens[1]);
            int col = int.Parse(tokens[2]);
            int value = int.Parse(tokens[3]);
            if (ValidIndex(matrix.GetLength(0), row)
                && ValidIndex(matrix[row].Length, col))
            {
                matrix[row][col] -= value;
                return;
            }

            Console.WriteLine("Invalid coordinates");
        }

        private static void AddValueToElement(int[][] matrix, string[] tokens)
        {
            int row = int.Parse(tokens[1]);
            int col = int.Parse(tokens[2]);
            int value = int.Parse(tokens[3]);

            
            if (ValidIndex(matrix.GetLength(0), row)
                && ValidIndex(matrix[row].Length, col))
            {
                matrix[row][col] += value;
                return;
            }

            Console.WriteLine("Invalid coordinates");
        }

        private static bool ValidIndex(int length, int index)
        => index >= 0 && index < length;
    }
}
