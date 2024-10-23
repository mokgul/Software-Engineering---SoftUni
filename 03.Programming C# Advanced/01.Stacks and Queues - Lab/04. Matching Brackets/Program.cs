using System;
using System.Collections;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> indices = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if(input[i] == '(')
                    indices.Push(i);
                if (input[i] == ')')
                {
                    int start = indices.Pop();
                    string sub = input.Substring(start, i - start + 1);
                    Console.WriteLine(sub);
                }
            }
        }
    }
}
