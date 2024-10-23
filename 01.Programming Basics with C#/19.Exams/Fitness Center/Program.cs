using System;

namespace Fitness_Center
{
    class Program
    {
        static void Main(string[] args)
        {
            string activity = "";
            int back = 0;
            int chest = 0;
            int legs = 0;
            int abs = 0;
            int shake = 0;
            int bar = 0;
            double training = 0;
            double buyers = 0;

            int clients = int.Parse(Console.ReadLine());
            for (int i = 1; i <= clients; i++)
            {
                activity = Console.ReadLine();
                switch (activity)
                {
                    case "Back":
                        back++;
                        training++;
                        break;
                    case "Chest":
                        chest++;
                        training++;
                        break;
                    case "Legs":
                        legs++;
                        training++;
                        break;
                    case "Abs":
                        abs++;
                        training++;
                        break;
                    case "Protein shake":
                        shake++;
                        buyers++;
                        break;
                    case "Protein bar":
                        bar++;
                        buyers++;
                        break;
                }
            }
            training = (training / clients) * 100;
            buyers = (buyers / clients) * 100;

            Console.WriteLine($"{back} - back");
            Console.WriteLine($"{chest} - chest");
            Console.WriteLine($"{legs} - legs");
            Console.WriteLine($"{abs} - abs");
            Console.WriteLine($"{shake} - protein shake");
            Console.WriteLine($"{bar} - protein bar");
            Console.WriteLine($"{training:f2}% - work out");
            Console.WriteLine($"{buyers:f2}% - protein");
        }
    }
}
