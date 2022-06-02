using System;

namespace Working_Hours
{
    class WorkingHours
    {
        static void Main(string[] args)
        {

            int hour = int.Parse(Console.ReadLine());
            var day = Console.ReadLine().ToLower();

            if (hour >= 10 && hour <= 18)
            {
                switch (day)
                {
                    case "monday":
                    case "tuesday":
                    case "wednesday":
                    case "thursday":
                    case "friday":
                    case "saturday":
                        Console.WriteLine("open");
                        break;
                    case "sunday":
                        Console.WriteLine("closed");
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }
            else
                Console.WriteLine("closed");
        }
    }
}
