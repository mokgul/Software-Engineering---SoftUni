using System;

namespace _03._Longer_Line
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());

            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());

            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            double lineOne = GetDistanceBetweenPoints(x1, y1, x2, y2);
            double lineTwo = GetDistanceBetweenPoints(x3, y3, x4, y4);

            if (lineOne > lineTwo)
            {
                double distancePointOne = GetDistanceFromCenter(x1, y1);
                double distancePointTwo = GetDistanceFromCenter(x2, y2);
                if (distancePointOne <= distancePointTwo)
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                else
                {
                    Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
                }
            }
            else if (lineOne < lineTwo)
            {
                double distancePointOne = GetDistanceFromCenter(x3, y3);
                double distancePointTwo = GetDistanceFromCenter(x4, y4);
                if (distancePointOne <= distancePointTwo)
                    Console.WriteLine($"({x3}, {y3})({x4}, {y4})");
                else
                {
                    Console.WriteLine($"({x4}, {y4})({x3}, {y3})");
                }
            }
            else
            {
                double distancePointOne = GetDistanceFromCenter(x1, y1);
                double distancePointTwo = GetDistanceFromCenter(x2, y2);
                if (distancePointOne <= distancePointTwo)
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                else
                {
                    Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
                }
            }
        }

        private static double GetDistanceBetweenPoints(double x1, double y1, double x2, double y2)
        {
            double distanceX = x2 - x1;
            double distanceY = y2 - y1;
            double distancePartialX = Math.Pow(distanceX, 2);
            double distancePartialY = Math.Pow(distanceY, 2);
            double distance = Math.Sqrt(distancePartialX + distancePartialY);

            return distance;
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