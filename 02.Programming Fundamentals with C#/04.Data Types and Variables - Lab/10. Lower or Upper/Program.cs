using System;

namespace _10._Lower_or_Upper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char input = char.Parse(Console.ReadLine());
            bool upper = (char.IsUpper(input)) ? true : false;
            if (upper)
                Console.WriteLine("upper-case");
            else
                Console.WriteLine("lower-case");
        }
    }
}