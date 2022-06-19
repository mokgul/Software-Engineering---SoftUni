using System;
using System.Linq;
using System.Threading.Channels;

namespace _11._Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input = String.Empty;
            while (input != "end")
            {
                input = Console.ReadLine();
                string[] command = input.Split(" ");
                switch (command[0])
                {
                    case "exchange":
                        numbers = Exchange(command, numbers);
                        break;
                    case "max":
                        MaxEvenOdd(command, numbers);
                        break;
                    case "min":
                        MinEvenOdd(command, numbers);
                        break;
                    case "first":
                        FirstEvenOddElements(command, numbers);
                        break;
                    case "last":
                        LastEvenOddElements(command, numbers);
                        break;
                    case "end":
                        Print(numbers);
                        break;
                }
            }
        }

        private static void Print(int[] nums)
        {
            Console.WriteLine($"[{string.Join(", ", nums)}]");
        }

        private static int[] Exchange(string[] command, int[] numbers)
        {
            int exchangeIndex = int.Parse(command[1]);
            if (exchangeIndex < 0 || exchangeIndex > numbers.Length - 1)
            {
                Console.WriteLine("Invalid index");
                return numbers;
            }
            int index = 0;
            int[] subArr1 = new int[exchangeIndex + 1];
            int[] subArr2 = new int[numbers.Length - exchangeIndex - 1];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i >= 0 && i <= exchangeIndex)
                    subArr1[i] = numbers[i];
                else
                {

                    subArr2[index] = numbers[i];
                    index++;
                }
            }

            int[] exchanged = new int[numbers.Length];
            exchanged = subArr2.Concat(subArr1).ToArray();

            return exchanged;
        }

        private static void MaxEvenOdd(string[] command, int[] numbers)
        {
            int maxOddIndex = -1; //if 0, if the max/min element is the 0 element it will print no matches
            int maxEvenIndex = -1;
            int maxOdd = 0;
            int maxEven = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 != 0)
                {
                    if (numbers[i] >= maxOdd)
                    {
                        maxOdd = numbers[i];
                        maxOddIndex = i;
                    }
                }
                else
                {
                    if (numbers[i] >= maxEven)
                    {
                        maxEven = numbers[i];
                        maxEvenIndex = i;
                    }

                }
            }

            if (command[1] == "odd")
            {
                if (maxOddIndex < 0)
                    Console.WriteLine("No matches");
                else
                    Console.WriteLine(maxOddIndex);
            }
            if (command[1] == "even")
            {
                if (maxEvenIndex < 0)
                    Console.WriteLine("No matches");
                else
                    Console.WriteLine(maxEvenIndex);
            }
        }

        private static void MinEvenOdd(string[] command, int[] numbers)
        {
            int minOddIndex = -1;
            int minEvenIndex = -1;
            int minOdd = int.MaxValue;
            int minEven = int.MaxValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 != 0)
                {
                    if (numbers[i] <= minOdd)
                    {
                        minOdd = numbers[i];
                        minOddIndex = i;
                    }
                }
                else
                {
                    if (numbers[i] <= minEven)
                    {
                        minEven = numbers[i];
                        minEvenIndex = i;
                    }
                }
            }

            if (command[1] == "odd")
            {
                if (minOddIndex < 0)
                    Console.WriteLine("No matches");
                else
                    Console.WriteLine(minOddIndex);
            }
            if (command[1] == "even")
            {
                if (minEvenIndex < 0)
                    Console.WriteLine("No matches");
                else
                    Console.WriteLine(minEvenIndex);
            }

        }

        private static void FirstEvenOddElements(string[] command, int[] numbers)
        {
            int countElements = int.Parse(command[1]);
            int evenCount = 0;
            int oddCount = 0;
            int[] evens = new int[numbers.Length];
            int[] odds = new int[numbers.Length];
            if (countElements > numbers.Length || countElements < 1)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0 && evenCount < countElements)
                {
                    evens[evenCount] = numbers[i];
                    evenCount++;

                }
                else if (numbers[i] % 2 == 1 && oddCount < countElements)
                {
                    odds[oddCount] = numbers[i];
                    oddCount++;

                }
            }

            odds = odds.Where(T => T != 0).ToArray(); // removes 0s from array
            int[] evensFinal = new int[evenCount];
            for (int i = 0; i < evensFinal.Length; i++)
            {
                evensFinal[i] = evens[i];
            }


            if (command[2] == "odd")
                Print(odds);
            else
            {
                Print(evensFinal);
            }
        }

        private static void LastEvenOddElements(string[] command, int[] numbers)
        {
            int countElements = int.Parse(command[1]);
            int evenCount = 0;
            int oddCount = 0;
            int[] evens = new int[numbers.Length];
            int[] odds = new int[numbers.Length];
            if (countElements > numbers.Length || countElements < 1)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (numbers[i] % 2 == 0 && evenCount < countElements)
                {
                    evens[evenCount] = numbers[i];
                    evenCount++;

                }
                else if (numbers[i] % 2 == 1 && oddCount < countElements)
                {
                    odds[oddCount] = numbers[i];
                    oddCount++;

                }
            }

            odds = odds.Where(T => T != 0).ToArray();

            int[] evensFinal = new int[evenCount];
            for (int i = 0; i < evensFinal.Length; i++)
            {
                evensFinal[i] = evens[i];
            }

            Array.Reverse(evensFinal);
            Array.Reverse(odds);

            if (command[2] == "odd")
                Print(odds);
            else
            {
                Print(evensFinal);
            }
        }
    }
}