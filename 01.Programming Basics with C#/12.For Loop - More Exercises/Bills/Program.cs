using System;

namespace Bills
{
    class Program
    {
        static void Main(string[] args)
        {
            double bills = 0;
            double averageBills = 0;
            double electricity = 0;
            double electricityTotal = 0;
            double water = 20;
            double internet = 15;
            double otherBills = 0;
            double otherBillsTotal = 0;

            int period = int.Parse(Console.ReadLine());
            for (int i = 1; i <= period; i++)
            {
                electricity = double.Parse(Console.ReadLine());
                electricityTotal += electricity;
                otherBills = (electricity + water + internet) * 1.20;
                bills += electricity + water + internet + otherBills;
                otherBillsTotal += otherBills;
            }
            averageBills = bills / period;

            Console.WriteLine($"Electricity: {electricityTotal:f2} lv");
            Console.WriteLine($"Water: {(water * period):f2} lv");
            Console.WriteLine($"Internet: {(internet * period):f2} lv");
            Console.WriteLine($"Other: {otherBillsTotal:f2} lv");
            Console.WriteLine($"Average: {averageBills:f2} lv");
        }
    }
}
