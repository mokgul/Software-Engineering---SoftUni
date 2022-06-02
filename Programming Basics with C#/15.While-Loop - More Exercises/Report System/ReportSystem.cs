using System;

namespace Report_System
{
    class ReportSystem
    {
        static void Main(string[] args)
        {
            int charityMoney = 0;
            int moneyGathered = 0;
            int productCounter = 0;
            int payment = 0;
            int cashPaymentCount = 0;
            int cardPaymentCount = 0;
            double averageCash = 0;
            double averageCard = 0;
            string input = "";

            charityMoney = int.Parse(Console.ReadLine());

            while (moneyGathered < charityMoney)
            {
                productCounter++;
                if (moneyGathered >= charityMoney)
                    break;
                input = Console.ReadLine();

                if (input == "End")
                    break;

                payment = int.Parse(input);
                if (productCounter % 2 == 1)
                {
                    if (payment > 100)
                        Console.WriteLine("Error in transaction!");
                    else
                    {
                        moneyGathered += payment;
                        averageCash += payment;
                        cashPaymentCount++;
                        Console.WriteLine("Product sold!");
                    }
                }
                if (productCounter % 2 == 0)
                {
                    if (payment < 10)
                        Console.WriteLine("Error in transaction!");
                    else
                    {
                        moneyGathered += payment;
                        averageCard += payment;
                        cardPaymentCount++;
                        Console.WriteLine("Product sold!");
                    }
                }
            }
            averageCash /= cashPaymentCount;
            averageCard /= cardPaymentCount;

            if (moneyGathered >= charityMoney)
            {
                Console.WriteLine($"Average CS: {averageCash:f2}");
                Console.WriteLine($"Average CC: {averageCard:f2}");
            }
            else
                Console.WriteLine("Failed to collect required money for charity.");
        }
    }
}
