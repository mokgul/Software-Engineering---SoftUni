using System;

namespace _06._Triples_of_Latin_Letters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int integer = int.Parse(Console.ReadLine());
            for (int i = 0; i < integer; i++)
            {
                for (int j = 0; j < integer; j++)
                {
                    for (int k = 0; k < integer; k++)
                    {
                        Console.WriteLine($"{(char)(97 + i)}{(char)(97 + j)}{(char)(97 + k)}");
                    }
                }
            }
        }
    }
}