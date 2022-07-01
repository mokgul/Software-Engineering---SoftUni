using System;

namespace _3._1._Simple_Conditions___Number_0_9_to_Text
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //simple way

            int num = int.Parse(Console.ReadLine());
            if (num == 1) { Console.WriteLine("one"); }
            else if (num == 2) { Console.WriteLine("two"); }
            else if (num == 3) { Console.WriteLine("three"); }
            else if (num == 4) { Console.WriteLine("four"); }
            else if (num == 5) { Console.WriteLine("five"); }
            else if (num == 6) { Console.WriteLine("six"); }
            else if (num == 7) { Console.WriteLine("seven"); }
            else if (num == 8) { Console.WriteLine("eight"); }
            else if (num == 9) { Console.WriteLine("nine"); }
            else Console.WriteLine("Number too big");

            //smarter way
            //int number = int.Parse(Console.ReadLine());
            //string[] nums =
            //{
            //    "one", "two", "three", "four", "five",
            //    "six", "seven", "eight", "nine",
            //    "Number too big"
            //};
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if (number == i + 1)
            //    {
            //        Console.WriteLine(nums[i]);
            //        return;
            //    }
            //}
            //Console.WriteLine(nums[nums.Length - 1]);
        }
    }
}
