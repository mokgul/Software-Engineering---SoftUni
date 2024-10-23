using System;

namespace Hotel_Room
{
    class HotelRoom
    {
        static void Main(string[] args)
        {
            //string[] months = {"May", "October", "June", "September", "July", "August"};
            string[] studio = { "50.00", "75.20", "76.00" };
            string[] apartment = { "65.00", "68.70", "77.00" };
            double studioPrice = 0;
            double apartmentPrice = 0;

            string month = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());

            switch(month)
            {
                case "May":
                case "October":
                    studioPrice = days * double.Parse(studio[0]);
                    apartmentPrice = days * double.Parse(apartment[0]);
                    if (days > 7 && days <= 14)
                        studioPrice *= 0.95;
                    else if (days > 14)
                    {
                        studioPrice *= 0.70;
                        apartmentPrice *= 0.90;
                    }
                    break;
                case "June":
                case "September":
                    studioPrice = days * double.Parse(studio[1]);
                    apartmentPrice = days * double.Parse(apartment[1]);
                    if (days > 14)
                    {
                        studioPrice *= 0.80;
                        apartmentPrice *= 0.90;
                    }
                    break;
                case "July":
                case "August":
                    studioPrice = days * double.Parse(studio[2]);
                    apartmentPrice = days * double.Parse(apartment[2]);
                    if (days > 14)
                        apartmentPrice *= 0.90;
                    break;
            }
            Console.WriteLine($"Apartment: {apartmentPrice:f2} lv.");
            Console.WriteLine($"Studio: {studioPrice:f2} lv.");
        }
    }
}
