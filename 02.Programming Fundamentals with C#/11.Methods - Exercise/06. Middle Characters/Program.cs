using System;

namespace _06._Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(GetMiddleElement(input));
        }

        private static string GetMiddleElement(string str)
        {
            string middle = String.Empty;
            if (str.Length % 2 == 0)
            {
                middle = str[str.Length / 2 - 1].ToString() + str[str.Length / 2].ToString();
            }
            else
            {
                middle = str[str.Length / 2].ToString();
            }

            return middle;
        }
    }
}