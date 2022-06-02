using System;

namespace Excursion_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //                 spring    summer   autumn   winter
            string[] under = { "50.00", "48.50", "60.00", "86.00" }; // <= 5 people
            string[] above = { "48.00", "45.00", "49.50", "85.00" }; // > 5 people
            double price = 0;

            int peopleQty = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            switch (season)
            {
                case "spring":
                    if (peopleQty <= 5) price = peopleQty * double.Parse(under[0]);
                    else price = peopleQty * double.Parse(above[0]);
                    break;
                case "summer":
                    if (peopleQty <= 5) price = peopleQty * double.Parse(under[1]);
                    else price = peopleQty * double.Parse(above[1]);
                    price *= 0.85;
                    break;
                case "autumn":
                    if (peopleQty <= 5) price = peopleQty * double.Parse(under[2]);
                    else price = peopleQty * double.Parse(above[2]);
                    break;
                case "winter":
                    if (peopleQty <= 5) price = peopleQty * double.Parse(under[3]);
                    else price = peopleQty * double.Parse(above[3]);
                    price *= 1.08;
                    break;
            }
            Console.WriteLine($"{price:f2} leva.");
        }
    }
}
