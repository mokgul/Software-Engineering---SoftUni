using System;

namespace _07._Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int times = int.Parse(Console.ReadLine());
            Console.WriteLine(RepeatString(input, times));
        }

        private static string RepeatString(string str, int times)
        {
            string result = String.Empty;
            for (int i = 0; i < times; i++)
            {
                result += str;
            }
            return result;
        }
    }
}