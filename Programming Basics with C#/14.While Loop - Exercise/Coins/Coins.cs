using System;

namespace Coins
{
    class Coins
    {
        static void Main(string[] args)
        {
            decimal change = 0;
            int coinCount = 0;

            change = decimal.Parse(Console.ReadLine());

            while (change > 0)
            {
                while (change >= (decimal)2.0)
                {
                    change -= (decimal)2.0;
                    coinCount++;
                }
                while (change >= (decimal)1.0)
                {
                    change -= (decimal)1.0;
                    coinCount++;
                }
                while (change >= (decimal)0.50)
                {
                    change -= (decimal)0.50;
                    coinCount++;
                }
                while (change >= (decimal)0.20)
                {
                    change -= (decimal)0.20;
                    coinCount++;
                }
                while (change >= (decimal)0.10)
                {
                    change -= (decimal)0.10;
                    coinCount++;
                }
                while (change >= (decimal)0.05)
                {
                    change -= (decimal)0.05;
                    coinCount++;
                }
                while (change >= (decimal)0.02)
                {
                    change -= (decimal)0.02;
                    coinCount++;
                }
                while (change >= (decimal)0.01)
                {
                    change -= (decimal)0.01;
                    coinCount++;
                }
            }
            Console.WriteLine(coinCount);
        }
    }
}
