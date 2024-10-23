using System;

namespace Vacation
{
    class Vacation
    {
        static void Main(string[] args)
        {
            //declaration
            string[] location = { "Alaska", "Morocco" };
            string[] accomodation = { "Hotel", "Hut", "Camp" };
            string[] alaska = { "0.65", "0.80", "0.90" };
            string[] morocco = { "0.45", "0.60", "0.90" };
            string locationChoice = "";
            string accomodationChoice = "";
            double price = 0.00;

            //input
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            //calculation
            switch (season)
            {
                case "Summer":
                    if (budget <= 1000)
                    {
                        accomodationChoice = accomodation[2];
                        locationChoice = location[0];
                        price = budget * double.Parse(alaska[0]);
                    }
                    else if (budget <= 3000)
                    {
                        accomodationChoice = accomodation[1];
                        locationChoice = location[0];
                        price = budget * double.Parse(alaska[1]);
                    }
                    else if (budget > 3000)
                    {
                        accomodationChoice = accomodation[0];
                        locationChoice = location[0];
                        price = budget * double.Parse(alaska[2]);
                    }
                    break;
                case "Winter":
                    if (budget <= 1000)
                    {
                        accomodationChoice = accomodation[2];
                        locationChoice = location[1];
                        price = budget * double.Parse(morocco[0]);
                    }
                    else if (budget <= 3000)
                    {
                        accomodationChoice = accomodation[1];
                        locationChoice = location[1];
                        price = budget * double.Parse(morocco[1]);
                    }
                    else if (budget > 3000)
                    {
                        accomodationChoice = accomodation[0];
                        locationChoice = location[1];
                        price = budget * double.Parse(morocco[2]);
                    }
                    break;
            }
            //output
            Console.WriteLine($"{locationChoice} - {accomodationChoice} - {price:f2}");
        }
    }
}
