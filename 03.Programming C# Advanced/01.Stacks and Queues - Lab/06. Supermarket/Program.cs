using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> peopleInLine = new Queue<string>();
            string command = Console.ReadLine();
            while (command != "End")
            {
                if (command != "Paid" && command != "End")
                {
                    peopleInLine.Enqueue(command);
                }
                else if (command == "Paid")
                {
                    while (peopleInLine.Count > 0)
                    {
                        Console.WriteLine(peopleInLine.Dequeue());
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"{peopleInLine.Count} people remaining.");
        }
    }
}
