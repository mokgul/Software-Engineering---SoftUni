using System;

namespace High_Jump
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingHeight = int.Parse(Console.ReadLine());
            int currentHeight = startingHeight - 30;
            int jumps = 0;
            int totalJumps = 0;
            int successful = 0;
            int unsuccessful = 0;

            while (unsuccessful < 3)
            {
                if (currentHeight > startingHeight) break;
                jumps = int.Parse(Console.ReadLine());
                totalJumps++;
                if (jumps > currentHeight)
                {
                    successful++;
                    currentHeight += 5;
                    unsuccessful = 0;
                }
                else
                {
                    unsuccessful++;
                }

            }
            if (unsuccessful < 3)
                Console.WriteLine($"Tihomir succeeded, he jumped over {startingHeight}cm after {totalJumps} jumps.");
            else
                Console.WriteLine($"Tihomir failed at {currentHeight}cm after {totalJumps} jumps.");
        }
    }
}
