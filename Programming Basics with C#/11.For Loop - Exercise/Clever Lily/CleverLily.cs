using System;

namespace Clever_Lily
{
    class CleverLily
    {
        static void Main(string[] args)
        {
            //declaration
            int years = 0, toys = 0, toysPrice = 0;
            double money = 0.00, moneyFromToys = 0.00;
            double moneySaved = 0.00, washingMachinePrice = 0.00;
            int moneyGrowth = 10, moneyPerYear; // 2nd year=10, 4th year=20, 6th year = 30,..

            //input
            years = int.Parse(Console.ReadLine());
            washingMachinePrice = double.Parse(Console.ReadLine());
            toysPrice = int.Parse(Console.ReadLine());

            //calculation        
            for (int i = 1; i <= years; i++)
            {
                bool even = i % 2 == 0;
                if (even)
                {
                    moneyPerYear = (i / 2) * moneyGrowth;
                    money += moneyPerYear;
                    money -= 1.00;
                }
                else if (!even)
                {
                    toys++;
                    moneyFromToys = toys * toysPrice;
                }
                moneySaved = money + moneyFromToys;
            }
            bool enoughMoney = moneySaved >= washingMachinePrice;
            double diff = Math.Abs(moneySaved - washingMachinePrice);

            //output
            if (enoughMoney)
                Console.WriteLine($"Yes! {diff:f2}");
            else
                Console.WriteLine($"No! {diff:f2}");
        }
    }
}
