using System;

namespace Series_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int seasons = int.Parse(Console.ReadLine());
            int episodes = int.Parse(Console.ReadLine());
            double time = double.Parse(Console.ReadLine());

            double ads = 0.20 * time;
            time += ads;
            double total = seasons * episodes * time + seasons * 10;
            Console.WriteLine($"Total time needed to watch the {name} series is {Math.Floor(total)} minutes.");
        }
    }
}
