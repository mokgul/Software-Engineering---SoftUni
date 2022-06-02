using System;

namespace Flowers
{
    class Flowers
    {
        static void Main(string[] args)
        {
            //declaration
            // .. prices = {"chrysanthemums", "roses", "tulips"}
            string[] warmSeasons = { "2.00", "4.10", "2.50" };
            string[] coldSeasons = { "3.75", "4.50", "4.15" };
            double chrysanthemumsPrice = 0.00;
            double rosesPrice = 0.00;
            double tulipsPrice = 0.00;
            double price = 0.00;
            int arranging = 2;
            double holidaysGain = 0.15;
            double tulipsDisc = 0.05; // more than 7 tullips in the spring
            double rosesDisc = 0.10; // more than 10 roses in the winter
            double flowerDisc = 0.20; //more than 20 total flowers all year

            //input
            int chrysanthemums = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int tulips = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string holiday = Console.ReadLine();

            //calculation
            switch (season)
            {
                case "Spring":
                case "Summer":
                    chrysanthemumsPrice = double.Parse(warmSeasons[0]);
                    rosesPrice = double.Parse(warmSeasons[1]);
                    tulipsPrice = double.Parse(warmSeasons[2]);
                    break;
                case "Autumn":
                case "Winter":
                    chrysanthemumsPrice = double.Parse(coldSeasons[0]);
                    rosesPrice = double.Parse(coldSeasons[1]);
                    tulipsPrice = double.Parse(coldSeasons[2]);
                    break;
            }
            if (holiday == "Y")
            {
                chrysanthemumsPrice *= (1 + holidaysGain);
                rosesPrice *= (1 + holidaysGain);
                tulipsPrice *= (1 + holidaysGain);
            }
            price = chrysanthemums * chrysanthemumsPrice + roses * rosesPrice + tulips * tulipsPrice;
            if (tulips > 7 && season == "Spring")
                price -= price * tulipsDisc;
            else if (roses >= 10 && season == "Winter")
                price -= price * rosesDisc;
            if ((chrysanthemums + roses + tulips) > 20)
                price -= price * flowerDisc;
            price += arranging;

            //Output
            Console.WriteLine("{0:0.00}", price);
        }
    }
}
