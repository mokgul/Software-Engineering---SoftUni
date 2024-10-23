using System;
using System.Linq;

namespace _02._Sum_Matrix_Columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            int[,] matrix = new int[rows,cols];

            for (int i = 0; i < rows; i++)
            {
                int[] elements = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int j = 0; j < elements.Length; j++)
                {
                    matrix[i,j] = elements[j];
                }
            }

            for (int j = 0; j < cols; j++)
            {
                int sum = 0;
                for (int i = 0; i < rows; i++)
                {
                    sum += matrix[i,j];
                }
                Console.WriteLine(sum);
            }
        }
    }
}
