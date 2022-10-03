using System;

namespace _03._Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());

            PrintChars(start, end);
        }

        private static void PrintChars(char a, char b)
        {
            char start;
            char end;
            if (a < b)
            {
                start = a;
                end = b;
            }
            else
            {
                start = b;
                end = a;
            }

            for (int i = start + 1; i < end; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}