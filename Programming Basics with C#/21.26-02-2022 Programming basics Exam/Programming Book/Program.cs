using System;

namespace Programming_Book
{
    class Program
    {
        static void Main(string[] args)
        {
            double pricePerPage = double.Parse(Console.ReadLine());
            double coverPrice = double.Parse(Console.ReadLine());
            int pageDiscount = int.Parse(Console.ReadLine());
            double designer = double.Parse(Console.ReadLine());
            int moneyFromTeam = int.Parse(Console.ReadLine());

            double total = 899 * pricePerPage + 2 * coverPrice;
            total *= (1 - (pageDiscount / 100.00));
            total += designer;
            total *= (1 - (moneyFromTeam / 100.00));
            Console.WriteLine($"Avtonom should pay {total:f2} BGN.");
        }
    }
}
