using System;

namespace New_House
{
    class NewHouse
    {
        static void Main(string[] args)
        {
            double roses = 5.00;
            double dahlias = 3.80;
            double tulips = 2.80;
            double narcissus = 3.00;
            double gladiolus = 2.50;
            double price = 0;

            string flower = Console.ReadLine();
            int flowerQty = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            switch (flower)
            {
                case "Roses":
                    price = roses;
                    if (flowerQty > 80)
                        price *= 0.9; 
                    break;
                case "Dahlias":
                    price = dahlias;
                    if (flowerQty > 90)
                        price *= 0.85;
                    break;
                case "Tulips":
                    price = tulips;
                    if (flowerQty > 80)
                        price *= 0.85;
                    break;
                case "Narcissus":
                    price = narcissus;
                    if (flowerQty < 120)
                        price *= 1.15;
                    break;
                case "Gladiolus":
                    price = gladiolus;
                    if (flowerQty < 80)
                        price *= 1.20;
                    break;

            }
            double totalPrice = price * flowerQty;
            if (budget >= totalPrice)
                Console.WriteLine($"Hey, you have a great garden with {flowerQty} {flower} and " +
                    $"{(budget - totalPrice):f2} leva left.");
            else
                Console.WriteLine($"Not enough money, you need {(totalPrice - budget):f2} leva more.");
        }
    }
}
