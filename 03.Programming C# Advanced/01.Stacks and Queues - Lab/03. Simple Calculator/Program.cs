using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calculation = new Stack<string>(Console.ReadLine().Split().Reverse());
            while (calculation.Count > 2)
            {
                int first = int.Parse(calculation.Pop());
                string operation = calculation.Pop();
                int second = int.Parse(calculation.Pop());
                bool sign = operation == "+" ? true : false;
                if (sign == true)
                    calculation.Push((first + second).ToString());
                else calculation.Push((first - second).ToString());
            }
            Console.WriteLine(calculation.Pop());
        }
    }
}
