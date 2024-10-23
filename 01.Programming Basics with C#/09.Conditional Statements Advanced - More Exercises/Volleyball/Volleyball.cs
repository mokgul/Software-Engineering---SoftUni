using System;

namespace Volleyball
{
    class Volleyball
    {
        static void Main(string[] args)
        {
            //declaration
            int weekends = 48; // 48 saturdays and 48 sundays 
            int weekendsOutOfTown;
            int holidays;
            double totalPlays = 0;


            //input
            string year = Console.ReadLine();
            holidays = int.Parse(Console.ReadLine());
            weekendsOutOfTown = int.Parse(Console.ReadLine());

            //calculation
            double freeWeekends = ((weekends - weekendsOutOfTown) * 3.00) / 4;
            double playsDuringHolidays = (2.0 * holidays) / 3;
            int sundayPlaysOutofTown = weekendsOutOfTown;
            totalPlays = freeWeekends + playsDuringHolidays + sundayPlaysOutofTown;

            if (year == "leap")
                totalPlays *= 1.15;

            //output
            Console.WriteLine(Math.Floor(totalPlays));
        }
    }
}
