using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] command = input.Split(" ").ToArray();
                switch (command[0])
                {
                    case "Delete":
                        integers = Delete(command, integers);
                        break;
                    case "Insert":
                        integers = Insert(command, integers);
                        break;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", integers));
        }

        private static List<int> Delete(string[] command, List<int> elements)
        {
            int value = int.Parse(command[1]);
            elements = elements.Where(element => element != value).ToList();
            //goes through each element in the list, if a current element meets the
            //condition, keep it in the list

            return elements;
        }

        private static List<int> Insert(string[] command, List<int> elements)
        {
            int value = int.Parse(command[1]);
            int index = int.Parse(command[2]);
            elements.Insert(index, value);
            return elements;
        }
    }
}
