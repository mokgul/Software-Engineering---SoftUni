using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Reverse_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stack = new Stack<char>(Console.ReadLine());
            while (stack.Count > 0) Console.Write(stack.Pop());
        }
    }
}
