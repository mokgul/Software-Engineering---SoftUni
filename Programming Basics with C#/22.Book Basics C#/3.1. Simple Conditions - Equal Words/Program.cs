using System;

namespace _3._1._Simple_Conditions___Equal_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word1 = Console.ReadLine().ToLower();
            string word2 = Console.ReadLine().ToLower();

            if (word1 == word2)
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");
        }
    }
}
