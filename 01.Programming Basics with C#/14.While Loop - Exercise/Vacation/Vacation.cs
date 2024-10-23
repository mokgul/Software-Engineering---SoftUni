using System;

namespace Vacation
{
    class Vacation
    {
        static void Main(string[] args)
        {
            double tripMoney = double.Parse(Console.ReadLine());
            double availableMoney = double.Parse(Console.ReadLine());
            double save = 0;
            double spend = 0;
            int saveDays = 0;
            int spendDays = 0;
            double left = 0;
            int daysCnt = 0;
            while (availableMoney < tripMoney)
            {
                string text = Console.ReadLine();
                double saveOrSpendMoney = double.Parse(Console.ReadLine());
                if (text == "spend")
                {
                    spendDays++;
                    spend = 0;
                    spend += saveOrSpendMoney;
                }
                else if (text == "save")
                {
                    saveDays++;
                    spendDays = 0;
                    save += saveOrSpendMoney;
                    save += availableMoney;
                }
                availableMoney -= spend;
                left = availableMoney - spend;
                if (left < 0)
                {
                    availableMoney = 0;
                }
                daysCnt++;
                if (save == tripMoney)
                {
                    break;
                }
                if (spendDays >= 5)
                {
                    break;
                }
            }
            if (spendDays >= 5)
            {
                Console.WriteLine($"You can't save the money.");
                Console.WriteLine($"{daysCnt}");
            }
            else
            {
                Console.WriteLine($"You saved the money for {daysCnt} days.");
            }
        }
    }
}
