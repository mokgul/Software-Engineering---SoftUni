using System;

namespace _2._2._Simple_Calculations___Exam_Problems___Daily_Earnings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double taxes = 0.25;

            int workDays = int.Parse(Console.ReadLine());
            double moneyPerDay = double.Parse(Console.ReadLine());
            double rate = double.Parse(Console.ReadLine());

            double moneyPerMonth = moneyPerDay * workDays;
            double yearlyBonus = 2.5 * moneyPerMonth;
            double moneyPerYear = 12 * moneyPerMonth + yearlyBonus;
            moneyPerYear -= moneyPerYear * taxes; // money after taxes
            double annualMoneyToBGN = moneyPerYear * rate;
            double earningsPerDay = annualMoneyToBGN / 365;

            Console.WriteLine("{0:0.00}", earningsPerDay);
        }
    }
}
