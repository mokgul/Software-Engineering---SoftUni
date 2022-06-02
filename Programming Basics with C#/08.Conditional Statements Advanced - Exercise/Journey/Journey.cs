using System;

namespace Journey
{
    class Journey
    {
        static void Main(string[] args)
        {
            string[] destination = { "Bulgaria", "Balkans", "Europe" };
            string[] place = { "Camp", "Hotel" };
            string chosenDest = "";
            string chosenPlace = "";
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            switch (season)
            {
                case "summer":
                    if (budget <= 100)
                    {
                        budget *= 0.30;
                        chosenDest = destination[0];
                        chosenPlace = place[0];
                    }

                    else if (budget <= 1000)
                    {
                        budget *= 0.40;
                        chosenDest = destination[1];
                        chosenPlace = place[0];
                    }
                    break;

                case "winter":
                    if (budget <= 100)
                    {
                        budget *= 0.70;
                        chosenDest = destination[0];
                        chosenPlace = place[1];
                    }

                    else if (budget <= 1000)
                    {
                        budget *= 0.80;
                        chosenDest = destination[1];
                        chosenPlace = place[1];
                    }
                    break;

                default:
                    Console.WriteLine("error");
                    break;
            }
            if (budget > 1000)
            {
                budget *= 0.90;
                chosenDest = destination[2];
                chosenPlace = place[1];
            }
            Console.WriteLine($"Somewhere in {chosenDest}");
            Console.WriteLine($"{chosenPlace} - {budget:f2}");
        }
    }
}
