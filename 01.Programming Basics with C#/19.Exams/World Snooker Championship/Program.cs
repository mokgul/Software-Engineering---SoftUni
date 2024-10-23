using System;

namespace World_Snooker_Championship
{
    class Program
    {
        static void Main(string[] args)
        {
            string stage = Console.ReadLine();
            string type = Console.ReadLine();
            int tickets = int.Parse(Console.ReadLine());
            char picture = char.Parse(Console.ReadLine());

            double price = 0;
            int picturePrice = 40;

            switch (stage)
            {
                case "Quarter final":
                    switch (type)
                    {
                        case "Standard":
                            price = tickets * 55.50;
                            break;
                        case "Premium":
                            price = tickets * 105.20;
                            break;
                        case "VIP":
                            price = tickets * 118.90;
                            break;
                    }
                    break;
                case "Semi final":
                    switch (type)
                    {
                        case "Standard":
                            price = tickets * 75.88;
                            break;
                        case "Premium":
                            price = tickets * 125.22;
                            break;
                        case "VIP":
                            price = tickets * 300.40;
                            break;
                    }
                    break;
                case "Final":
                    switch (type)
                    {
                        case "Standard":
                            price = tickets * 110.10;
                            break;
                        case "Premium":
                            price = tickets * 160.66;
                            break;
                        case "VIP":
                            price = tickets * 400;
                            break;
                    }
                    break;
            }
            if (price >= 2500 && price <= 4000) price *= 0.90;
            if (price > 4000)
            {
                picturePrice = 0;
                price *= 0.75;
            }
            if (picture == 'Y') price += tickets * picturePrice;
            Console.WriteLine("{0:0.00}", price);
        }
    }
}
