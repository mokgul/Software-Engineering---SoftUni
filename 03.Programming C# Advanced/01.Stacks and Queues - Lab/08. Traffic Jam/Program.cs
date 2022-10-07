using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            int carsAbleToPass = int.Parse(Console.ReadLine());
            int carsPassed = 0;

            string line = Console.ReadLine();
            while (line != "end")
            {
                if(line != "end" && line != "green")
                    queue.Enqueue(line);
                else if (line == "green")
                {
                    for (int i = 0; i < carsAbleToPass; i++)
                    {
                        if(queue.Count > 0)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            carsPassed++;
                        }
                    }
                }
                line = Console.ReadLine();
            }

            Console.WriteLine($"{carsPassed} cars passed the crossroads.");
        }
    }
}
