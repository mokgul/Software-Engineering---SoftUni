using System;

namespace Sum_of_Two_Numbers
{
    class SumOfTwoNumbers
    {
        static void Main(string[] args)
        {
            int combinationN = 0;
            bool combinationFound = false;
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());

            for (int i = startNum; i <= endNum; i++)
            {
                for (int j = startNum; j <= endNum; j++)
                {
                    combinationN++;
                    if (i + j == magicNum)
                    {
                        combinationFound = true;
                        Console.WriteLine($"Combination N:{combinationN} ({i} + {j} = {magicNum})");
                        break;
                    }
                }
                if (combinationFound) break;
            }
            if (!combinationFound)
                Console.WriteLine($"{combinationN} combinations - neither equals {magicNum}");
        }
    }
}
