using System;

namespace _02._Ascii_Sumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            string line = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i < line.Length; i++)
            {
                char current = line[i];
                if (current > start && current < end)
                    sum += current;
            }

            Console.WriteLine(sum);
        }
    }
}
