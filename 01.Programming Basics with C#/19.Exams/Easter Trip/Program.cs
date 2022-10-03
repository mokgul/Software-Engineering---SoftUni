using System;

namespace Easter_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string dates = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double price = 0;

            switch (destination)
            {
                case "France":
                    switch (dates)
                    {
                        case "21-23":
                            price = 30.00;
                            break;
                        case "24-27":
                            price = 35.00;
                            break;
                        case "28-31":
                            price = 40.00;
                            break;
                    }
                    break;
                case "Italy":
                    switch (dates)
                    {
                        case "21-23":
                            price = 28.00;
                            break;
                        case "24-27":
                            price = 32.00;
                            break;
                        case "28-31":
                            price = 39.00;
                            break;
                    }
                    break;
                case "Germany":
                    switch (dates)
                    {
                        case "21-23":
                            price = 32.00;
                            break;
                        case "24-27":
                            price = 37.00;
                            break;
                        case "28-31":
                            price = 43.00;
                            break;
                    }
                    break;
            }
            price *= nights;
            Console.WriteLine($"Easter trip to {destination} : {price:f2} leva.");
        }
    }
}
