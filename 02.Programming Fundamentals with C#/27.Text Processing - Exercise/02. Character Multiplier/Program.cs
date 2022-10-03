using System;

namespace _02._Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int sum = 0;
            string shorterString = input[0].Length <= input[1].Length ? input[0] : input[1];
            string longerString = input[0].Length >= input[1].Length ? input[0] : input[1];
            for (int i = 0; i < longerString.Length; i++)
            {
                if(i < shorterString.Length)
                {
                    char first = input[0][i];
                    char second = input[1][i];
                    sum += first * second;
                    continue;
                }

                sum += longerString[i];
            }

            Console.WriteLine(sum);
        }
    }
}
