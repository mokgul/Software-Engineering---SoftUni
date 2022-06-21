using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            integers = Commands(integers);
            PrintList(integers);
        }

        private static void PrintList(List<int> integers)
        {
            Console.WriteLine(string.Join(" ", integers));
        }

        private static List<int> Commands(List<int> integers)
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] command = input.Split(" ").ToArray();
                switch (command[0])
                {
                    case "Add":
                        integers = AddToList(command, integers);
                        break;
                    case "Insert":
                        integers = InsertToList(command, integers);
                        break;
                    case "Remove":
                        integers = RemoveFromList(command, integers);
                        break;
                    case "Shift":
                        if (command[1] == "left")
                            integers = ShiftLeft(command, integers);
                        else
                        {
                            integers = ShiftRight(command, integers);
                        }
                        break;
                }
                input = Console.ReadLine();
            }
            return integers;
        }

        private static List<int> AddToList(string[] command, List<int> integers)
        {
            int value = int.Parse(command[1]);
            integers.Add(value);
            return integers;
        }

        private static List<int> InsertToList(string[] command, List<int> integers)
        {
            int value = int.Parse(command[1]);
            int index = int.Parse(command[2]);
            if (index < 0 || index > integers.Count - 1)
            {
                Console.WriteLine("Invalid index");
                return integers;
            }

            integers.Insert(index, value);
            return integers;
        }

        private static List<int> RemoveFromList(string[] command, List<int> integers)
        {
            int index = int.Parse(command[1]);
            if (index < 0 || index > integers.Count - 1)
            {
                Console.WriteLine("Invalid index");
                return integers;
            }

            integers.RemoveAt(index);
            return integers;
        }

        private static List<int> ShiftLeft(string[] command, List<int> integers)
        {
            int count = int.Parse(command[2]);
            for (int i = 0; i < count; i++)
            {
                int temp = integers[0];
                integers.Add(temp);
                integers.RemoveAt(0);

            }

            return integers;
        }

        private static List<int> ShiftRight(string[] command, List<int> integers)
        {
            int count = int.Parse(command[2]);
            for (int i = 0; i < count; i++)
            {
                int temp = integers[integers.Count - 1];
                integers.Insert(0, temp); // adds value at index 0 and moves the list
                // 1 position to the right
                integers.RemoveAt(integers.Count - 1);
                
            }

            return integers;
        }
    }
}
