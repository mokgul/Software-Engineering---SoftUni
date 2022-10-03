using System;

namespace Time___15_Minutes
{
    class TimeAdd15minutes
    {
        static void Main(string[] args)
        {
            int hourTime       = int.Parse(Console.ReadLine());
            int minutesTime    = int.Parse(Console.ReadLine());
            int hoursToMinutes = hourTime * 60;
            int totalMinutes = hoursToMinutes + minutesTime + 15;
            int hour         = totalMinutes / 60;
            int minutes      = totalMinutes % 60;
            if (hour >= 24)
            {
                hour -= 24;
            }
            if (minutes < 10)
            {
                Console.WriteLine(hour + ":0" + minutes);
            }
            else
            {
                Console.WriteLine(hour + ":" + minutes);
            }
        }
    }
}
