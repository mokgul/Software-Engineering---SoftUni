using System;

namespace _04._Tribonacci_Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int elements = int.Parse(Console.ReadLine());
            GetTribonacciSeq(elements);
        }

        private static void GetTribonacciSeq(int elements)
        {
            //Tribonacci Sequence
            // 1 1 2 4 7 13 24 44..
            int a = 0;
            int b = 0;
            int c = 0;
            int d = 1;
            Console.Write(1); // printing first element
            for (int i = 1; i < elements; i++)
            {

                //parameters taking next values
                a = b; // 0 0 1 1
                b = c; // 0 1 1 2
                c = d; // 1 1 2 4
                d = a + b + c; // 1 2 4 7
                Console.Write(" "+ d);
            }
        }
    }
}