using System;

namespace Travel_Agency
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string type = Console.ReadLine();
            string VIP = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            double price = 0;
            bool invalid = false;

            switch (destination)
            {
                case "Bansko":
                case "Borovets":
                    if (type == "noEquipment")
                    {
                        price = 80;
                        if (VIP == "yes") price *= 0.95;
                    }
                    else if (type == "withEquipment")
                    {
                        price = 100;
                        if (VIP == "yes") price *= 0.90;
                    }
                    else
                        invalid = true;
                    break;
                case "Varna":
                case "Burgas":
                    if (type == "noBreakfast")
                    {
                        price = 100;
                        if (VIP == "yes") price *= 0.93;
                    }
                    else if (type == "withBreakfast")
                    {
                        price = 130;
                        if (VIP == "yes") price *= 0.88;
                    }
                    else
                        invalid = true;
                    break;
                default:
                    invalid = true;
                    break;

            }
            if (days > 7) days--;
            price *= days;
            if (days < 1)
                Console.WriteLine("Days must be positive number!");
            if (invalid)
                Console.WriteLine("Invalid input!");
            if (!invalid && days >= 1)
                Console.WriteLine($"The price is {price:f2}lv! Have a nice time!");
        }
    }
}
