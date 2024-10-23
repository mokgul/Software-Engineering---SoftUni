using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        private static int[] arguments;
        private static int[] elements;
        static void Main(string[] args)
        {
            Queue<int> integers = new Queue<int>();
            GetArguments();
            PushToStack(arguments[0],integers,elements);
            PopElements(arguments[1], integers);
            if (integers.Count == 0) StackIsEmpty();
            else IsElementInStack(arguments[2], integers);
        }

        static void StackIsEmpty() => Console.WriteLine("0");
        static void IsElementInStack(int element, Queue<int> integers)
            =>Console.WriteLine(integers.Contains(element) ? $"true" : $"{integers.Min()}");
        static void PopElements(int count, Queue<int> integers)
        {
            for (int i = 0; i < count; i++)
                integers.Dequeue();
        }

        static void GetArguments()
        {
            Program.arguments = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Program.elements = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
        }

        static void PushToStack(int count, Queue<int> integers,int[] elements)
        {
            for(int i = 0; i < count; i++)
                integers.Enqueue(elements[i]);
        }
    }
}