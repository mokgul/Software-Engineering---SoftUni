using System;
using System.Linq;

namespace _01._Randomize_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(" ")
                .ToArray();

            Random random = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                int randomIndex = random.Next(0, words.Length);
                string temp = words[i];
                words[i] = words[randomIndex];
                words[randomIndex] = temp;
            }

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
