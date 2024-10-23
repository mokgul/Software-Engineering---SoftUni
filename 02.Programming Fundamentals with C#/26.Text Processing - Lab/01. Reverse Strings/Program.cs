using System;
using System.Linq;

namespace _01._Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            while (line != "end")
            {
                char[] reversed = line.ToCharArray();
                var resultString = reversed.Reverse();
                Console.WriteLine($"{line} = {string.Join("", resultString)}");
                line = Console.ReadLine();
            }
        }
    }
}
