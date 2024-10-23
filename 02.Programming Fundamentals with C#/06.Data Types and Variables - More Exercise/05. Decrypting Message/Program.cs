using System;

namespace _05._Decrypting_Message
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int numberLines = int.Parse(Console.ReadLine());

            string message = "";
            for (int i = 0; i < numberLines; i++)
            {
                char character = char.Parse(Console.ReadLine());
                int newAsciiIndex = (int)character + key;
                char newChar = (char)newAsciiIndex;
                message += newChar;
            }

            Console.WriteLine(message);
        }
    }
}