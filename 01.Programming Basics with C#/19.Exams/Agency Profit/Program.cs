using System;

namespace Agency_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int adultTicketsQty = int.Parse(Console.ReadLine());
            int kidTicketsQty = int.Parse(Console.ReadLine());
            double adultTicketPrice = double.Parse(Console.ReadLine());
            double tax = double.Parse(Console.ReadLine());

            double kidTicketPrice = 0.30 * adultTicketPrice + tax;
            adultTicketPrice += tax;
            double total = adultTicketsQty * adultTicketPrice + kidTicketsQty * kidTicketPrice;
            double profit = 0.20 * total;
            Console.WriteLine($"The profit of your agency from {name} tickets is {profit:f2} lv.");
        }
    }
}
