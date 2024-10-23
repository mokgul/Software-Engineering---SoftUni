using System;

namespace Cinema_Ticket
{
    class CinemaTicket
    {
        static void Main(string[] args)
        {
            var day = Console.ReadLine().ToLower();
            double price = 0;

            switch (day)
            {
                case "monday":
                case "tuesday":
                case "friday":
                    { price = 12; Console.WriteLine(price); }
                    break;
                case "wednesday":
                case "thursday":
                    { price = 14; Console.WriteLine(price); }
                    break;
                case "saturday":
                case "sunday":
                    { price = 16; Console.WriteLine(price); }
                    break;
            }
        }
    }
}
