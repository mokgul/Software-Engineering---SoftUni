using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> evens = new List<int>();
            Queue<int> queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            while (queue.Count > 0)
            {
                if(queue.Peek() % 2 == 0)
                    evens.Add(queue.Peek());
                queue.Dequeue();
            }

            Console.WriteLine(string.Join(", ",evens));
        }
    }
}
