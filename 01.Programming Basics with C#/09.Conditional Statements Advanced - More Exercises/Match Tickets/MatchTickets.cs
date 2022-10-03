using System;

namespace Match_Tickets
{
    class MatchTickets
    {
        static void Main(string[] args)
        {
            double vipTicket = 499.99;
            double normalTicket = 249.99;
            double transport = 0.00;
            double ticketPrice = 0.00;
            double total = 0.00;

            double budget = double.Parse(Console.ReadLine());
            string ticket = Console.ReadLine();
            int peopleQty = int.Parse(Console.ReadLine());

            if (peopleQty <= 4)
                transport = 0.75 * budget;
            else if (peopleQty <= 9)
                transport = 0.60 * budget;
            else if (peopleQty <= 24)
                transport = 0.50 * budget;
            else if (peopleQty <= 49)
                transport = 0.40 * budget;
            else if (peopleQty > 50)
                transport = 0.25 * budget;
            if (ticket == "VIP")
                ticketPrice = peopleQty * vipTicket;
            else
                ticketPrice = peopleQty * normalTicket;
            total = ticketPrice + transport;

            if (budget >= total)
                Console.WriteLine($"Yes! You have {(budget - total):f2} leva left.");
            else
                Console.WriteLine($"Not enough money! You need {(total - budget):f2} leva.");


        }
    }
}
