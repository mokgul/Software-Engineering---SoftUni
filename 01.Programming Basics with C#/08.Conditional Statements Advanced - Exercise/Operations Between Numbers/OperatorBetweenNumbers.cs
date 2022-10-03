using System;

namespace Operations_Between_Numbers
{
    class OperatorBetweenNumbers
    {
        static void Main(string[] args)
        {
            double result = 0;
            string[] oddOrEven = { "odd", "even" };
            string oddEven = "";

            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            string operators = Console.ReadLine();

            switch (operators)
            {
                case "+":
                    result = num1 + num2;
                    if (result % 2 == 0)
                        oddEven = oddOrEven[1];
                    else
                        oddEven = oddOrEven[0];
                    Console.WriteLine($"{num1} {operators} {num2} = {result} - {oddEven}");
                    break;
                case "-":
                    result = num1 - num2;
                    if (result % 2 == 0)
                        oddEven = oddOrEven[1];
                    else
                        oddEven = oddOrEven[0];
                    Console.WriteLine($"{num1} {operators} {num2} = {result} - {oddEven}");
                    break;
                case "*":
                    result = num1 * num2;
                    if (result % 2 == 0)
                        oddEven = oddOrEven[1];
                    else
                        oddEven = oddOrEven[0];
                    Console.WriteLine($"{num1} {operators} {num2} = {result} - {oddEven}");
                    break;
                case "/":
                    {
                        result = num1 / num2;
                        if (num2 == 0)
                            Console.WriteLine($"Cannot divide {num1} by zero");
                        else
                            Console.WriteLine($"{num1} {operators} {num2} = {result:f2}");
                    }
                    break;
                case "%":
                    result = num1 % num2;
                    if (num2 == 0)
                        Console.WriteLine($"Cannot divide {num1} by zero");
                    else
                        Console.WriteLine($"{num1} {operators} {num2} = {result}");
                    break;
            }

        }
    }
}
