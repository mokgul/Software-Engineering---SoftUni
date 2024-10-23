using System;

namespace Add_Bags
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceAbove = double.Parse(Console.ReadLine());
            double weight = double.Parse(Console.ReadLine());
            int daysTill = int.Parse(Console.ReadLine());
            int luggageAmount = int.Parse(Console.ReadLine());

            double priceBetween = 0.50 * priceAbove;
            double under = 0.20 * priceAbove;
            double price = 0;
            switch (weight)
            {
                case double n when (n < 10):
                    if (daysTill > 30) price = under * 1.10;
                    else if (daysTill < 7) price = under * 1.40;
                    else price = under * 1.15;
                    break;
                case double n when (n >= 10 && n <= 20):

                    if (daysTill > 30) price = priceBetween * 1.10;
                    else if (daysTill < 7) price = priceBetween * 1.40;
                    else price = priceBetween * 1.15;
                    break;
                case double n when (n > 20):
                    if (daysTill > 30) price = priceAbove * 1.10;
                    else if (daysTill < 7) price = priceAbove * 1.40;
                    else price = priceAbove * 1.15;
                    break;
            }
            double total = price * luggageAmount;
            Console.WriteLine($"The total price of bags is: {total:f2} lv.");
        }
    }
}
