using System;
using System.Reflection;

namespace _02._Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int result = VowelsCount(input);
            Console.WriteLine(result);
        }

        private static int VowelsCount(string str)
        {
            string vowels = "aeiouAEIOU";
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (vowels.Contains(str[i]))
                    counter++;
            }

            return counter;
        }
    }
}