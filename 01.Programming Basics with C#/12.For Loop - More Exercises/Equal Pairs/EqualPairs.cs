using System;

namespace Equal_Pairs
{
    class EqualPairs
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int sumCheck = 0;
            int diff = int.MinValue;
            int maxDiff = 0;
            bool check = false;
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int numOne = int.Parse(Console.ReadLine());
                int numTwo = int.Parse(Console.ReadLine());
                if (i == 0)
                {
                    sum = numOne + numTwo;
                    sumCheck = sum;
                }
                else if (i > 0)
                {
                    maxDiff = Math.Abs(sum - (numOne + numTwo));
                    if (maxDiff > diff) diff = maxDiff;
                    sum = numOne + numTwo;
                    if (sum == sumCheck) check = true;
                }
            }
            if (check || n == 1)
                Console.WriteLine($"Yes, value={sum}");
            else
                Console.WriteLine($"No, maxdiff={diff}");
        }
    }
}
