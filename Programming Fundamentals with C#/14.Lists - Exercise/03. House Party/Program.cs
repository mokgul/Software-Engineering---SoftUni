using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            List<string> guests = new List<string>();
            string guest = String.Empty;

            for (int i = 1; i <= lines; i++)
            {
                guest = Console.ReadLine();
                string[] current = guest.Split(" ").ToArray();
                if (current.Contains("not"))
                {
                    if (guests.Contains(current[0]))
                    {
                        guests.Remove(current[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{current[0]} is not in the list!");
                    }
                }
                else
                {
                    if (guests.Contains(current[0]))
                    {
                        Console.WriteLine($"{current[0]} is already in the list!");
                    }
                    else
                    {
                        guests.Add(current[0]);
                    }
                }
            }

            foreach (string name in guests)
            {
                Console.WriteLine(name);
            }
        }
    }
}
