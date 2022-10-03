using System;

namespace _10._Multiply_Evens_by_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));
            int result = GetMultipleEvenOddSum(
                GetSumEvenDigits(number),
                GetSumOddDigits(number)
                );
            Console.WriteLine(result);
        }

        private static int GetSumEvenDigits(int num)
        {
            int evenSum = 0;
            int currentDigit = 0;
            while (num > 0)
            {
                currentDigit = num % 10;
                if (currentDigit % 2 == 0)
                    evenSum += currentDigit;
                num /= 10;
            }
            return evenSum;
        }

        private static int GetSumOddDigits(int num)
        {
            int oddSum = 0;
            int currentDigit = 0;
            while (num > 0)
            {
                currentDigit = num % 10;
                if (currentDigit % 2 != 0)
                    oddSum += currentDigit;
                num /= 10;
            }
            return oddSum;
        }

        private static int GetMultipleEvenOddSum(int even, int odd)
        {
            int result = even * odd;
            return result;
        }
    }
}