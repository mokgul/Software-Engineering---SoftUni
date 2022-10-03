using System;

namespace Movie_Destination
{
    class Program
    {
        static void Main(string[] args)
        {
            //...                Dubai    Sofia    London
            string[] winter = { "45000", "17000", "24000" };
            string[] summer = { "40000", "12500", "20250" };
            double price = 0;

            double budget = double.Parse(Console.ReadLine());
            string destination = Console.ReadLine();
            string season = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());

            switch (season)
            {
                case "Winter":
                    switch (destination)
                    {
                        case "Dubai": price = double.Parse(winter[0]); break;
                        case "Sofia": price = double.Parse(winter[1]); break;
                        case "London": price = double.Parse(winter[2]); break;
                    }
                    break;
                case "Summer":
                    switch (destination)
                    {
                        case "Dubai": price = double.Parse(summer[0]); break;
                        case "Sofia": price = double.Parse(summer[1]); break;
                        case "London": price = double.Parse(summer[2]); break;
                    }
                    break;
            }
            price *= days;
            if (destination == "Dubai") price *= 0.70;
            if (destination == "Sofia") price *= 1.25;

            if (budget >= price)
                Console.WriteLine($"The budget for the movie is enough! We have {(budget - price):f2} leva left!");
            else
                Console.WriteLine($"The director needs {(price - budget):f2} leva more!");
        }
    }
}
