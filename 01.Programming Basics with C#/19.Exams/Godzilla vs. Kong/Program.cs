using System;

namespace Oscars_week_in_cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] normal = { "7.50", "7.35", "8.15", "8.75" };
            string[] luxury = { "10.50", "9.45", "10.25", "11.55" };
            string[] ultra = { "13.50", "12.75", "13.25", "13.95" };
            double price = 0;
            string movie = Console.ReadLine();
            string type = Console.ReadLine();
            int tickets = int.Parse(Console.ReadLine());

            switch (movie)
            {
                case "A Star Is Born":
                    switch (type)
                    {
                        case "normal": price = double.Parse(normal[0]); break;
                        case "luxury": price = double.Parse(luxury[0]); break;
                        case "ultra luxury": price = double.Parse(ultra[0]); break;
                    }
                    break;
                case "Bohemian Rhapsody":
                    switch (type)
                    {
                        case "normal": price = double.Parse(normal[1]); break;
                        case "luxury": price = double.Parse(luxury[1]); break;
                        case "ultra luxury": price = double.Parse(ultra[1]); break;
                    }
                    break;
                case "Green Book":
                    switch (type)
                    {
                        case "normal": price = double.Parse(normal[2]); break;
                        case "luxury": price = double.Parse(luxury[2]); break;
                        case "ultra luxury": price = double.Parse(ultra[2]); break;
                    }
                    break;
                case "The Favourite":
                    switch (type)
                    {
                        case "normal": price = double.Parse(normal[3]); break;
                        case "luxury": price = double.Parse(luxury[3]); break;
                        case "ultra luxury": price = double.Parse(ultra[3]); break;
                    }
                    break;
            }
            price *= tickets;
            Console.WriteLine($"{movie} -> {price:f2} lv.");
        }
    }
}