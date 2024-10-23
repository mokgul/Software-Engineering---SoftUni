using System;

namespace Account_Balance
{
    class AccountBalance
    {
        static void Main(string[] args)
        {
            double total = 0;
            string input = "";

            while (input != "NoMoreMoney")
            {
                input = Console.ReadLine();
                if (input == "NoMoreMoney") continue;
                double money = double.Parse(input);
                if (money > 0)
                {
                    total += money;
                    Console.WriteLine($"Increase: {money:f2}");
                }
                else
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
            }
            Console.WriteLine($"Total: {total:f2}");
        }
    }
}
