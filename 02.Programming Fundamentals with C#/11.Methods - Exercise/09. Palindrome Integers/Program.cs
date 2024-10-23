using System;

namespace _09._Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;
            int number;

            while (input != "END")
            {
                input = Console.ReadLine();
                if (input == "END") break;
                number = int.Parse(input);
                CheckPalindrome(number);
            }
        }

        private static void CheckPalindrome(int a)
        {
            int originalValue = a;
            string reversedToString = String.Empty;
            while (a > 0)
            {
                reversedToString += a % 10;
                a /= 10;
            }
            int reversed = int.Parse(reversedToString);
            if (reversed == originalValue)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}