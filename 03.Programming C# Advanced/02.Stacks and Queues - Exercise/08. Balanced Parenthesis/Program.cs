using System;
using System.Collections;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<char> left = c => c == '(' || c == '[' || c == '{';
            Predicate<char> right = c => c == ')' || c == ']' || c == '}';
            Stack<char> brackets = new Stack<char>();
            string input = Console.ReadLine();
            bool balanced = true;
            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];
                if (left(current))
                    brackets.Push(current);
                else if (right(current))
                {
                    // in ascii table ( has index 41 and ) 42,
                    //so the one in the stack + the index would return the other
                    int index = current == ')' ? 1 : 2;
                    if (brackets.Count > 0 && current == brackets.Peek() + index)
                        brackets.Pop();
                    else
                        balanced = false;
                }
            }

            Console.WriteLine(balanced ? $"YES" : "NO");
        }
    }
}
