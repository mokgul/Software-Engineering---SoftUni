using System;

namespace English_Name_of_the_last_digit
{
    class Program
    {
        static void Main(string[] args)
        {
            int integer = int.Parse(Console.ReadLine());
            
            Console.WriteLine(Name(integer));
        }

         static string Name(int x)
        {
            x = x % 10;
            string word = "";
            string[] nums = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            word = nums[x];
            return word;
        }
    }
}