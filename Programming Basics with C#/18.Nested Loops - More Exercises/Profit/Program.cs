using System;

namespace Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int ones = int.Parse(Console.ReadLine());
            int twos = int.Parse(Console.ReadLine());
            int fives = int.Parse(Console.ReadLine());
            int change = int.Parse(Console.ReadLine());

            int onesTotal = ones * 1;
            int twosTotal = twos * 2;
            int fivesTotal = fives * 5; ;
            int oneCounter = 0;
            int twoCounter = 0;
            int fiveCounter = 0;

            for (int one = 0; one <= onesTotal; one++)
            {
                for (int two = 0; two <= twosTotal; two += 2)
                {
                    for (int five = 0; five <= fivesTotal; five += 5)
                    {
                        if (one + two + five == change)
                        {
                            if (one != 0) oneCounter = one / 1;
                            if (two != 0) twoCounter = two / 2;
                            if (five != 0) fiveCounter = five / 5;
                            Console.WriteLine($"{oneCounter} * 1 lv. + {twoCounter} * 2 lv. + {fiveCounter} * 5 lv. = {change} lv.");
                            oneCounter = 0;
                            twoCounter = 0;
                            fiveCounter = 0;
                        }
                    }
                }
            }
        }
    }
}
