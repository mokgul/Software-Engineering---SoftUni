using System;

namespace Easter_Competition
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "";
            string input = "";
            string best = "";
            int points = 0;
            int max = 0;

            int bread = int.Parse(Console.ReadLine());

            for (int i = 1; i <= bread; i++)
            {
                name = Console.ReadLine();
                input = Console.ReadLine();
                while (input != "Stop")
                {
                    points += int.Parse(input);
                    input = Console.ReadLine();
                }
                Console.WriteLine($"{name} has {points} points.");
                if (points > max)
                {
                    max = points;
                    best = name;
                    Console.WriteLine($"{name} is the new number 1!");
                }
                points = 0;
            }
            Console.WriteLine($"{best} won competition with {max} points!");

        }
    }
}
