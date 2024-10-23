using System;

namespace Left_and_Right_Sum
{
    class LeftAndRightSum
    {
        static void Main(string[] args)
        {
            int leftSum = 0;
            int RightSum = 0;
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < 2 * n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (i < n)
                    leftSum += num;
                else if (i >= n && i < 2 * n)
                    RightSum += num;
            }
            if (leftSum == RightSum)
                Console.WriteLine("Yes, sum = " + RightSum);
            else
                Console.Write("No, diff = " + (Math.Abs(leftSum - RightSum)));
        }
    }
}
