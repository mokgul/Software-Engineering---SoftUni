using System;

namespace _3._1._Simple_Conditions___Number_0_100_to_Text
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] units = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen",
                "seventeen", "eighteen", "nineteen"};
            string[] tens = { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
             
            int num = int.Parse(Console.ReadLine());

            if (num >=0 && num < 20)
            {
                Console.WriteLine(units[num]);
            }
            else if (num >= 20 && num < 100)
            {
                var a = tens[num / 10];
                var b = units[num % 10];
                if (num % 10 > 0)
                    Console.WriteLine(a + " " + b);
                else
                    Console.WriteLine(a);
            }
            else if (num == 100)
                Console.WriteLine("one hundred");
            else
                Console.WriteLine("invalid number");
        }
    }
}
