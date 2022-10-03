using System;

namespace Favorite_Movie
{
    class Program
    {
        static void Main(string[] args)
        {
            int points = 0;
            int max = int.MinValue;
            string best = "";
            string name = Console.ReadLine();
            int counter = 1;
            while (name != "STOP")
            {
                for (int i = 0; i < name.Length; i++)
                {
                    char current = name[i];
                    points += current;
                    if (char.IsUpper(current))
                        points -= name.Length;
                    if (char.IsLower(current))
                        points -= 2 * name.Length;
                }
                if (points > max)
                {
                    max = points;
                    best = name;
                }
                points = 0;
                name = Console.ReadLine();
                counter++;
                if (counter > 7)
                {
                    Console.WriteLine("The limit is reached.");
                    break;
                }
            }
            Console.WriteLine($"The best movie for you is {best} with {max} ASCII sum.");
        }
    }
}
