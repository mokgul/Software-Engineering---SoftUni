using System;

namespace _04._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,]  matrix = new char[size,size];

            for (int i = 0; i < size; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < size; j++)
                    matrix[i, j] = line[j];
            }

            char symbol = char.Parse(Console.ReadLine());
            bool isInMatrix = false;
            for(int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] == symbol)
                    {
                        Console.WriteLine($"({i}, {j})");
                        isInMatrix = true;
                        break;
                    }
                }

                if (isInMatrix) break;
            }


            if (!isInMatrix)
                Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}
