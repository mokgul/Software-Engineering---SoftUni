using System;

namespace _04._Reverse_Array_of_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine().Split(" ");
            Array.Reverse(elements);
            Console.WriteLine(string.Join(" ", elements));
        }
    }
}