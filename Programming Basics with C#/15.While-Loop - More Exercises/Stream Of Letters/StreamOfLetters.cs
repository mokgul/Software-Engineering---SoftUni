using System;

namespace Stream_Of_Letters
{
    class StreamOfLetters
    {
        static void Main(string[] args)
        {
            bool letterC = false;
            bool letterO = false;
            bool letterN = false;
            int letterCcount = 0;
            int letterOcount = 0;
            int letterNcount = 0;

            string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string message = "";
            string input = "";

            while (input != "End")
            {
                if (letterC && letterO && letterN)
                {
                    Console.Write(message);
                    Console.Write(" ");
                    letterC = false;
                    letterO = false;
                    letterN = false;
                    letterCcount = 0;
                    letterOcount = 0;
                    letterNcount = 0;
                    message = "";
                }

                input = Console.ReadLine();
                if (input == "End")
                    break;
                if (!alphabet.Contains(input))
                    continue;

                if (input == "c" && letterCcount == 0)
                {
                    letterC = true;
                    letterCcount = 1;
                    continue;
                }
                else if (input == "o" && letterOcount == 0)
                {
                    letterO = true;
                    letterOcount = 1;
                    continue;
                }
                else if (input == "n" && letterNcount == 0)
                {
                    letterN = true;
                    letterNcount = 1;
                    continue;
                }
                message += input;
            }
        }
    }
}
