using System;

namespace Aluminum_Joinery
{
    class Program
    {
        static void Main(string[] args)
        {
            double price = 0;
            double totalPrice = 0;
            int joineryQty = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string delivery = Console.ReadLine();
            if (joineryQty < 10)
                Console.WriteLine("Invalid order");
            else
            {
                switch (type)
                {
                    case "90X130":
                        price = 110;
                        if (joineryQty > 30 && joineryQty <= 60) price *= 0.95;
                        else if (joineryQty > 60) price *= 0.92;
                        break;
                    case "100X150":
                        price = 140;
                        if (joineryQty > 40 && joineryQty <= 80) price *= 0.94;
                        else if (joineryQty > 80) price *= 0.90;
                        break;
                    case "130X180":
                        price = 190;
                        if (joineryQty > 20 && joineryQty <= 50) price *= 0.93;
                        else if (joineryQty > 50) price *= 0.88;
                        break;
                    case "200X300":
                        price = 250;
                        if (joineryQty > 25 && joineryQty <= 50) price *= 0.91;
                        else if (joineryQty > 50) price *= 0.86;
                        break;
                }
                totalPrice = joineryQty * price;
                if (delivery == "With delivery") totalPrice += 60;
                if (joineryQty >= 100) totalPrice *= 0.96;
                Console.WriteLine($"{totalPrice:f2} BGN");
            }
        }
    }
}
