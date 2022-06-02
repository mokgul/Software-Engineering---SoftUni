using System;

namespace Ski_Trip
{
    class SkiTrip
    {
        static void Main(string[] args)
        {
            double roomPrice = 18.00;
            double apartmentPrice = 25.00;
            double presidentApPrice = 35.00;
            // [] = { less < 10 days, 10-15 days , 15+ days}
            string[] apPriceDisc = { "0.70", "0.65", "0.50" };
            string[] prApPriceDisc = { "0.90", "0.85", "0.80" };
            double price = 0.00;

            int days = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string review = Console.ReadLine();

            switch (room)
            {
                case "room for one person":
                    price = (days - 1) * roomPrice;
                    break;
                case "apartment":
                    if (days < 10)
                        price = (days - 1) * double.Parse(apPriceDisc[0]) * apartmentPrice;
                    else if (days <= 15)
                        price = (days - 1) * double.Parse(apPriceDisc[1]) * apartmentPrice;
                    else if (days > 15)
                        price = (days - 1) * double.Parse(apPriceDisc[2]) * apartmentPrice;
                    break;
                case "president apartment":
                    if (days < 10)
                        price = (days - 1) * double.Parse(prApPriceDisc[0]) * presidentApPrice;
                    else if (days <= 15)
                        price = (days - 1) * double.Parse(prApPriceDisc[1]) * presidentApPrice;
                    else if (days > 15)
                        price = (days - 1) * double.Parse(prApPriceDisc[2]) * presidentApPrice;
                    break;
            }
            if (review == "positive")
                price *= 1.25;
            else
                price *= 0.90;

            Console.WriteLine("{0:0.00}", price);
        }
    }
}
