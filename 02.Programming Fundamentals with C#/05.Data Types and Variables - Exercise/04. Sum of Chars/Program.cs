using System;

namespace _04._Sum_of_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int charSum = 0;
            for (int i = 0; i < numbers; i++)
            {
                char symbol = char.Parse(Console.ReadLine());
                charSum += (int)symbol;
            }
            Console.WriteLine($"The sum equals: {charSum}");
        }
    }
}