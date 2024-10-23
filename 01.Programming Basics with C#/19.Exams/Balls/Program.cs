using System;

namespace Balls
{
    class Program
    {
        static void Main(string[] args)
        {
            double total = 0;
            int red = 0;
            int orange = 0;
            int yellow = 0;
            int white = 0;
            int black = 0;
            int others = 0;
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string color = Console.ReadLine();
                switch (color)
                {
                    case "red":
                        total += 5;
                        red++;
                        break;
                    case "orange":
                        total += 10;
                        orange++;
                        break;
                    case "yellow":
                        total += 15;
                        yellow++;
                        break;
                    case "white":
                        total += 20;
                        white++;
                        break;
                    case "black":
                        total = Math.Floor(total / 2);
                        black++;
                        break;
                    default:
                        others++;
                        break;
                }
            }
            Console.WriteLine($"Total points: {total}");
            Console.WriteLine($"Red balls: {red}");
            Console.WriteLine($"Orange balls: {orange}");
            Console.WriteLine($"Yellow balls: {yellow}");
            Console.WriteLine($"White balls: {white}");
            Console.WriteLine($"Other colors picked: {others}");
            Console.WriteLine($"Divides from black balls: {black}");
        }
    }
}
