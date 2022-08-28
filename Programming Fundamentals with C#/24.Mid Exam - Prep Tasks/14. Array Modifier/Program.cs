using System;
using System.Linq;

namespace _14._Array_Modifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] tokens = input.Split();
                switch (tokens[0])
                {
                    case "swap":
                        Swap(tokens, integers);
                        break;
                    case "multiply":
                        Multiply(tokens, integers);
                        break;
                    case "decrease":
                        Decrease(integers);
                        break;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", integers));
        }

        private static void Decrease(int[] integers)
        {
            for (int i = 0; i < integers.Length; i++)
                integers[i] -= 1;
        }

        private static void Multiply(string[] tokens, int[] integers)
        {
            var index1 = int.Parse(tokens[1]);
            var index2 = int.Parse(tokens[2]);
            integers[index1] *= integers[index2];
        }

        private static void Swap(string[] tokens, int[] integers)
        {
            var index1 = int.Parse(tokens[1]);
            var index2 = int.Parse(tokens[2]);

            //var temp = integers[index1];
            //integers[index1] = integers[index2];
            //integers[index2] = temp;

            (integers[index1], integers[index2]) = (integers[index2], integers[index1]);
        }
    }
}
