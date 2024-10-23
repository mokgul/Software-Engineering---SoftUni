using System;

namespace Excursion
{
    class Excursion
    {
        static void Main(string[] args)
        {
            int pricePerNight = 20;
            int museum = 6;
            double transportCard = 1.60;
            double unexpectedCosts = 0.25;
            double total = 0;

            int peopleInGroup = int.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            int transportCardsQty = int.Parse(Console.ReadLine());
            int museumQty = int.Parse(Console.ReadLine());

            int nightsPrice = nights * pricePerNight;
            double transportCardPrice = transportCardsQty * transportCard;
            int museumPrice = museumQty * museum;
            double pricePerPerson = nightsPrice + transportCardPrice + museumPrice;
            double pricePerGroup = pricePerPerson * peopleInGroup;
            total = pricePerGroup + (pricePerGroup * unexpectedCosts);
            Console.WriteLine("{0:0.00}", total);
        }
    }
}
