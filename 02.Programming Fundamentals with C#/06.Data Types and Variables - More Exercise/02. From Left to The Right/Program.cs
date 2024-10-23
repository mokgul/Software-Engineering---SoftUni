using System;
using System.Numerics;

namespace _02._From_Left_to_The_Right
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbersAmount = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbersAmount; i++)
            {
                string left = "";
                string right = "";
                bool whitespace = false;
                string numberLine = Console.ReadLine();
                for (int j = 0; j < numberLine.Length; j++)
                {
                    if (numberLine[j] == ' ') whitespace = true;

                    if (!whitespace)
                        left += numberLine[j];
                    else
                    {
                        right += numberLine[j];
                    }
                }

                long leftSum = 0;
                long rightSum = 0;
                long leftNum = long.Parse(left);
                long rightNum = long.Parse(right);
                long leftTemp = leftNum;
                long rightTemp = rightNum;
                while (leftNum != 0)
                {
                    leftSum += leftNum % 10;
                    leftNum /= 10;
                }

                while (rightNum != 0)
                {
                    rightSum += rightNum % 10;
                    rightNum /= 10;
                }

                if (leftTemp > rightTemp)
                    Console.WriteLine(Math.Abs(leftSum));
                else
                {
                    Console.WriteLine(Math.Abs(rightSum));
                }
            }
        }
    }
}