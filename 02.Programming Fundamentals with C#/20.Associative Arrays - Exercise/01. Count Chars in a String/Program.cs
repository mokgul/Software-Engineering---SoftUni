using System;
using System.Collections.Generic;

namespace _01._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();

            string text = Console.ReadLine();
            for (int n = 0; n < text.Length; n++)
            {
                if (text[n] == ' ') continue;
                if (!charCount.ContainsKey(text[n]))
                {
                    charCount.Add(text[n], 0);
                }

                charCount[text[n]]++;
            }

            foreach (var item in charCount)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
