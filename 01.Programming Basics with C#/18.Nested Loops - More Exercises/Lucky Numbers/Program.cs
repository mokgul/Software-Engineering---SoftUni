using System;

namespace Lucky_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            bool checkSum = false;
            bool checkDivision = false;
            bool digitIsNull = false;
            int num = int.Parse(Console.ReadLine());

            for (int i = 1111; i <= 9999; i++)
            {
                string digits = i.ToString();
                int leftSum = 0;
                int rightSum = 0;
                for (int j = 0; j < digits.Length; j++)
                {
                    int currentDigit = int.Parse(digits[j].ToString());
                    if (currentDigit == 0)
                    {
                        digitIsNull = true;
                        break;
                    }
                    if (j == 0 || j == 1)
                        leftSum += currentDigit;
                    if (j == 2 || j == 3)
                        rightSum += currentDigit;
                }
                if (leftSum == rightSum)
                    checkSum = true;
                if (num % leftSum == 0)
                    checkDivision = true;
                if (checkSum && checkDivision && !digitIsNull)
                {
                    Console.Write(i + " ");
                }
                checkSum = false;
                checkDivision = false;
                digitIsNull = false;
            }
        }
    }
}
