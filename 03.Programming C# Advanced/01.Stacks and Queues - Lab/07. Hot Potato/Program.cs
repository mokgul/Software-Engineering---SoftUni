using System;
using System.Collections;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var people = new Queue<string>(Console.ReadLine().Split());
            int eliminationPass = int.Parse(Console.ReadLine());
            int pass = 1;

            while (people.Count > 1)
            {
                if (pass == eliminationPass)
                {
                    Console.WriteLine($"Removed {people.Dequeue()}");
                    pass = 1;
                    continue;
                }
                people.Enqueue(people.Dequeue());
                pass++;
            }

            Console.WriteLine($"Last is {people.Peek()}");
        }
    }
}
