using System;

namespace _02._Center_Point
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());

            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double distanceOne = GetDistanceFromCenter(x1, y1);
            double distanceTwo = GetDistanceFromCenter(x2, y2);

            if (distanceOne <= distanceTwo)
                Console.WriteLine($"({x1}, {y1})");
            else
                Console.WriteLine($"({x2}, {y2})");
        }

        private static double GetDistanceFromCenter(double x, double y, int x0 = 0, int y0 = 0)
        {
            double distanceX = x - x0;
            double distanceY = y - y0;
            double distancePartialX = Math.Pow(distanceX, 2);
            double distancePartialY = Math.Pow(distanceY, 2);
            double distance = Math.Sqrt(distancePartialX + distancePartialY);

            return distance;
        }
    }
}