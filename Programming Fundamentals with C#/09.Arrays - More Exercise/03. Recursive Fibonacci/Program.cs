using System;
using System.Linq;

namespace _03._Recursive_Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, ……..
            //a, b, c
            //Fibonacci recursive
            //a and b are 0 and 1
            //every next element is calculated from the sum of the previous two elements
            // c(1) => a(0) + b(1) = 1
            // c(5) => a(2) + b(3) = 5

            int element = int.Parse(Console.ReadLine());
            Console.WriteLine(Fib(element));
        }

        static int Fib(int n)
        {
            int a = 0; // first fib element
            int b = 1; // second fib element
            int c = 0; // third fib element, to be calculated

            if (n <= 1) return n;

            for (int i = 2; i <= n; i++)
            {
                c = a + b; 
                //calculating the current element
                // for a(2) and b(3) => c = 5
                //we want to move to the next element so a becomes 3 and b becomes 5
                a = b;
                b = c;

            }

            return b;
        }
    }
}