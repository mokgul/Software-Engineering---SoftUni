using System;

namespace Tennis_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double racketPrice = double.Parse(Console.ReadLine());
            int racketQty = int.Parse(Console.ReadLine());
            int shoesQty = int.Parse(Console.ReadLine());

            double shoesPrice = racketPrice / 6;
            double price = shoesPrice * shoesQty + racketPrice * racketQty;
            double others = 0.20 * price;
            double total = price + others;
            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(total / 8)}");
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(0.875 * total)}");
        }
    }
}
