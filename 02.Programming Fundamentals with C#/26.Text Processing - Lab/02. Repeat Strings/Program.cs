using System;

namespace _02._Repeat_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            string result = String.Empty;

            foreach (string word in words)
            {
                int length = word.Length;
                
                for (int i = 0; i < length; i++)
                {
                    result += word;
                }
            }
            Console.WriteLine(result);
        }
    }
}
