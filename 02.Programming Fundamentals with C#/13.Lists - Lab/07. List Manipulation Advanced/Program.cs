using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace _07._List_Manipulation_Advanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            List<int> originalValues = new List<int>(integers);

            Command(integers);

            bool areEqual = CheckIfEquals(integers, originalValues);
            if (!areEqual)
                PrintList(integers);
        }

        private static void PrintList(List<int> numbers)
        {
            foreach (int item in numbers)
            {
                Console.Write(item + " ");
            }
        }

        private static bool CheckIfEquals(List<int> original, List<int> changed)
        {
            var result = original.SequenceEqual(changed);
            return result;
        }
        private static List<int> Command(List<int> integers)
        {
            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] command = input.Split(" ");
                switch (command[0])
                {
                    case "Add":
                        integers = AddToList(command, integers);
                        break;
                    case "Remove":
                        integers = RemoveFromList(command, integers);
                        break;
                    case "RemoveAt":
                        integers = RemoveAtIndex(command, integers);
                        break;
                    case "Insert":
                        integers = InsertAtIndex(command, integers);
                        break;
                    case "Contains":
                        ContainsNumber(command, integers);
                        break;
                    case "PrintEven":
                        PrintEven(integers);
                        break;
                    case "PrintOdd":
                        PrintOdd(integers);
                        break;
                    case "GetSum":
                        PrintSum(integers);
                        break;
                    case "Filter":
                        Filter(command, integers);
                        break;
                }
                input = Console.ReadLine();
            }
            return integers;
        }

        private static List<int> AddToList(string[] command, List<int> integers)
        {
            integers.Add(int.Parse(command[1]));
            return integers;
        }

        private static List<int> RemoveFromList(string[] command, List<int> integers)
        {
            integers.Remove(int.Parse(command[1]));
            return integers;
        }

        private static List<int> RemoveAtIndex(string[] command, List<int> integers)
        {
            int index = int.Parse(command[1]);
            integers.RemoveAt(index);
            return integers;
        }

        private static List<int> InsertAtIndex(string[] command, List<int> integers)
        {
            int number = int.Parse(command[1]);
            int index = int.Parse(command[2]);
            integers.Insert(index, number);
            return integers;
        }

        private static void ContainsNumber(string[] command, List<int> integers)
        {
            int number = int.Parse(command[1]);
            if (integers.Contains(number))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }
        }

        private static void PrintEven(List<int> integers)
        {
            for (int i = 0; i < integers.Count; i++)
            {
                if (integers[i] % 2 == 0)
                    Console.Write(integers[i] + " ");
            }

            Console.WriteLine();
        }

        private static void PrintOdd(List<int> integers)
        {
            for (int i = 0; i < integers.Count; i++)
            {
                if (integers[i] % 2 != 0)
                    Console.Write(integers[i] + " ");
            }

            Console.WriteLine();
        }

        private static void PrintSum(List<int> integers)
        {
            int sum = 0;
            for (int i = 0; i < integers.Count; i++)
            {
                sum += integers[i];
            }

            Console.WriteLine(sum);
        }

        private static void Filter(string[] command, List<int> integers)
        {
            //Filters through elements
            // 1 2 3 4 5
            // Filter > 2
            // print every number with that condition
            // 3 4 5

            List<int> filtered = new List<int>();
            string condition = command[1];
            int number = int.Parse(command[2]);

            switch (condition)
            {
                case "<":
                    filtered = integers.Where(item => item < number).ToList();
                    break;
                case ">":
                    filtered = integers.Where(item => item > number).ToList();
                    break;
                case ">=":
                    filtered = integers.Where(item => item >= number).ToList();
                    break;
                case "<=":
                    filtered = integers.Where(item => item <= number).ToList();
                    break;

            }
            PrintList(filtered);
            Console.WriteLine();
        }
    }
}
