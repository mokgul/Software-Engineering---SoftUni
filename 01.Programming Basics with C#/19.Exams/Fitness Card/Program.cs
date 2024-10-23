using System;

namespace Fitness_Card
{
    class Program
    {
        static void Main(string[] args)
        {
            //                  Gym  Boxing Yoga  Zumba Dances Pilates
            string[] male = { "42", "41", "45", "34", "51", "39" };
            string[] female = { "35", "37", "42", "31", "53", "37" };
            bool man = false;
            double price = 0;

            double budget = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string sport = Console.ReadLine();
            if (gender == "m") man = true;

            switch (sport)
            {
                case "Gym":
                    if (man)
                        price += double.Parse(male[0]);
                    else
                        price += double.Parse(female[0]);
                    break;
                case "Boxing":
                    if (man)
                        price += double.Parse(male[1]);
                    else
                        price += double.Parse(female[1]);
                    break;
                case "Yoga":
                    if (man)
                        price += double.Parse(male[2]);
                    else
                        price += double.Parse(female[2]);
                    break;
                case "Zumba":
                    if (man)
                        price += double.Parse(male[3]);
                    else
                        price += double.Parse(female[3]);
                    break;
                case "Dances":
                    if (man)
                        price += double.Parse(male[4]);
                    else
                        price += double.Parse(female[4]);
                    break;
                case "Pilates":
                    if (man)
                        price += double.Parse(male[5]);
                    else
                        price += double.Parse(female[5]);
                    break;
            }
            if (age <= 19)
            {
                price -= price * 0.20;
            }
            budget -= price;
            if (budget >= 0)
                Console.WriteLine($"You purchased a 1 month pass for {sport}.");
            else
                Console.WriteLine($"You don't have enough money! You need ${Math.Abs(budget):f2} more.");
        }
    }
}
