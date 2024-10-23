using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var input = Console.ReadLine().Split().Select(x => x.ToLower()).ToArray();

            while (input[0] != "end")
            {
                if (input[0] == "add")
                    AddItems(input, stack);
                else
                    RemoveItems(input, stack);

                input = Console.ReadLine().Split().Select(x => x.ToLower()).ToArray();
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }

        private static void RemoveItems(string[] input, Stack<int> stack)
        {
            var count = int.Parse(input[1]);
            if (stack.Count <= count) return;
            while (count > 0)
            {
                stack.Pop();
                count--;
            }
        }

        private static void AddItems(string[] input, Stack<int> stack)
        {
            stack.Push(int.Parse(input[1]));
            stack.Push(int.Parse(input[2]));
        }
    }
}