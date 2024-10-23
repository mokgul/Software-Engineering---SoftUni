using System;

namespace Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int index = 0;
            int main_digit = 0;
            int offset = 0;
            int word_length = int.Parse(Console.ReadLine());
            string message = "";
            for(int i = 0 ; i < word_length; i++)
            {
                string digit = Console.ReadLine();
                if(digit == "0")
                {
                    message += " ";
                    continue;
                }
                main_digit = int.Parse(digit) % 10;
                if(main_digit == 8 || main_digit == 9)
                {
                    offset = (main_digit - 2) * 3 + 1;
                }
                else
                {
                    offset = (main_digit - 2) * 3;
                }
                index = (offset + digit.Length - 1);
                char letter = (char)(index + 97);
                message += letter;
            }
            Console.WriteLine(message);
        }
    }
}