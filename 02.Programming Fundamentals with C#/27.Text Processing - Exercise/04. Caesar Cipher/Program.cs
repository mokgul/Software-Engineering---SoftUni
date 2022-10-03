using System;
using System.Linq;

namespace _04._Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string output = input.Aggregate(String.Empty, (current, nextValue) => current + (char)(nextValue + 3));
            //Aggregate applies an accumulator function over a sequence
            //first argument is the seed, the initial value - its optional parameter
            //current - a string with the current state of the string ( the result )
            //nextValue - the next value in the sequence
            //the function takes the 2 parameter and applies the function after  the lambda
            Console.WriteLine(output);
        }
    }
}
