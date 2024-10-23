using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading;

namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        private static Stack<int> stack = new Stack<int>();

        private static Predicate<Stack<int>> NotEmpty = c => c.Count > 0;
        static void Main(string[] args)
        {
            Input();
            PrintStack();
        }

        static void PrintStack()
        {
            if (Program.NotEmpty(Program.stack))
                Console.WriteLine(string.Join(", ", Program.stack.ToList()));
        }
        
        static void Input()
        {
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] cmnds = Console.ReadLine().Split();
                SwitchCommands(cmnds);
            }
        }
        static void SwitchCommands(string[] cmnds)
        {
            switch (cmnds[0])
            {
                case "1": Push(int.Parse(cmnds[1])); break;
                case "2": if (Program.NotEmpty(Program.stack)) PopElement(); break;
                case "3": if (Program.NotEmpty(Program.stack)) PrintMax(); break;
                case "4": if (Program.NotEmpty(Program.stack)) PrintMin(); break;
            }
        }
        static void Push(int element) => Program.stack.Push(element);
        static void PopElement() => Program.stack.Pop();
        static void PrintMax() => Console.WriteLine($"{Program.stack.Max()}");
        static void PrintMin() => Console.WriteLine($"{Program.stack.Min()}");

    }
}
