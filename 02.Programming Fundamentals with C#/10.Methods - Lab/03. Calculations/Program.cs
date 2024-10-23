using System;

namespace _03._Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            switch (operation)
            {
                case "add":
                    AddNumbers(firstNum, secondNum);
                    break;
                case "multiply":
                    MultiplyNumbers(firstNum, secondNum);
                    break;
                case "subtract":
                    SubtractNumbers(firstNum, secondNum);
                    break;
                case "divide":
                    DivideNumbers(firstNum, secondNum);
                    break;
            }
        }

        static void AddNumbers(int a, int b)
        {
            int result = a + b;
            Console.WriteLine(result);
        }

        static void MultiplyNumbers(int a, int b)
        {
            int result = a * b;
            Console.WriteLine(result);
        }

        static void SubtractNumbers(int a, int b)
        {
            int result = a - b;
            Console.WriteLine(result);
        }

        static void DivideNumbers(int a, int b)
        {
            int result = a / b;
            Console.WriteLine(result);
        }
    }
}