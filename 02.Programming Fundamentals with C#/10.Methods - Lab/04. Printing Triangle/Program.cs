using System;
namespace _04._Printing_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int heigth = int.Parse(Console.ReadLine());

            for (int i = 1; i < heigth; i++)
            {
                PrintLine(1, i);
            }
            for (int i = heigth; i > 0; i--)
            {
                PrintLine(1, i);
            }

        }

        static void PrintLine(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
        }
    }
}