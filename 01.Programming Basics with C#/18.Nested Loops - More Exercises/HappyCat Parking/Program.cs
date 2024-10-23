using System;

namespace HappyCat_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            double tax = 0;
            double taxPerDay = 0;
            double total = 0;

            for (int day = 1; day <= days; day++)
            {
                for (int hour = 1; hour <= hours; hour++)
                {
                    if (day % 2 == 0 && hour % 2 != 0)
                    {
                        tax = 2.50;
                    }
                    else if (day % 2 != 0 && hour % 2 == 0)
                    {
                        tax = 1.25;
                    }
                    else
                    {
                        tax = 1.00;
                    }
                    taxPerDay += tax;
                }
                Console.WriteLine($"Day: {day} - {taxPerDay:f2} leva");
                total += taxPerDay;
                taxPerDay = 0;
            }
            Console.WriteLine($"Total: {total:f2} leva");
        }
    }
}
