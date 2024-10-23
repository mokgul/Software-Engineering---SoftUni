using System;

namespace Deposit_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double deposit  = double.Parse(Console.ReadLine());
            int term        = int.Parse(Console.ReadLine());
            double rate     = double.Parse(Console.ReadLine());
            double earnings = ((deposit * rate/100) / 12) * term + deposit;
            Console.WriteLine(earnings);
        }
    }
}
