using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double,int> values = new Dictionary<double,int>();
            double[] input = Console.ReadLine().Split().Select(double.Parse).ToArray();
            for (int i = 0; i < input.Length; i++)
            {
                if (!values.ContainsKey(input[i]))
                {
                    values.Add(input[i], 0);
                }
                values[input[i]]++;
            }

            foreach (var value in values)
            {
                Console.WriteLine($"{value.Key} - {value.Value} times");
            }
        }
    }
}
