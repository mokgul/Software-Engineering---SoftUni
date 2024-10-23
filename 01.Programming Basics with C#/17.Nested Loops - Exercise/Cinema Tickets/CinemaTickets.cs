using System;

namespace Cinema_Tickets
{
    class CinemaTickets
    {
        static void Main(string[] args)
        {
            string movie = "";
            string seatType = "";
            string lastmovie = "";
            int freeSeats = 0;
            int seatTakenCount = 0;
            double seatTakenCountNonNull = 0;
            int studentCount = 0;
            int standardCount = 0;
            int kidCount = 0;
            int totalTickets = 0;
            double cinemaFullPerc = 0;
            double ticketPercStudent = 0;
            double ticketPercStandard = 0;
            double ticketPercKid = 0;

            while (movie != "Finish")
            {
                movie = Console.ReadLine();
                if (movie == "Finish")
                {
                    break;
                }

                freeSeats = int.Parse(Console.ReadLine());
                for (int seat = 1; seat <= freeSeats; seat++)
                {
                    bool caseEnd = false;

                    seatType = Console.ReadLine();
                    switch (seatType)
                    {
                        case "student":
                            studentCount++;
                            break;
                        case "standard":
                            standardCount++;
                            break;
                        case "kid":
                            kidCount++;
                            break;
                        case "End":
                            caseEnd = true;
                            cinemaFullPerc = ((double)seatTakenCount / freeSeats) * 100;
                            Console.WriteLine($"{movie} - {cinemaFullPerc:f2}% full.");
                            seatTakenCount = 0;
                            break;
                    }
                    seatTakenCount++;
                    if (caseEnd) break;
                }
                totalTickets = studentCount + standardCount + kidCount;
                if (seatTakenCount == freeSeats)
                {
                    cinemaFullPerc = ((double)seatTakenCount / freeSeats) * 100;
                    Console.WriteLine($"{movie} - {cinemaFullPerc:f2}% full.");
                    seatTakenCount = 0;
                    continue;
                }
                seatTakenCount = 0;
            }
            ticketPercStudent = ((double)studentCount / totalTickets) * 100;
            ticketPercStandard = ((double)standardCount / totalTickets) * 100;
            ticketPercKid = ((double)kidCount / totalTickets) * 100;

            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{ticketPercStudent:f2}% student tickets.");
            Console.WriteLine($"{ticketPercStandard:f2}% standard tickets.");
            Console.WriteLine($"{ticketPercKid:f2}% kids tickets.");
        }
    }
}
