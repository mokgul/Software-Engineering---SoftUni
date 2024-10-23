using System;

namespace Point_in_the_Figure
{
    class PointInTheFigure
    {
        static void Main(string[] args)
        {
            //declaration
            string border = "border";
            string inside = "inside";
            string outside = "outside";
            int h; //side size
            int x; //point coordinate x
            int y; //point coordinate y

            //input
            h = int.Parse(Console.ReadLine());
            x = int.Parse(Console.ReadLine());
            y = int.Parse(Console.ReadLine());

            //calculation
            //inside check
            var rectangleBottom = (x > 0 && x < 3 * h) && (y > 0 && y < h);
            var rectangleTop = (x > h && x < 2 * h) && (y > h && y < 4 * h);
            var lineInBetween = (x > h && x < 2 * h) && (y == h);
            //border check
            var rectangleBottomBorderLR = (x == 0 || x == 3 * h) && (y >= 0 && y <= h); // left, right side
            var rectangleBottomBorderBT = (y == 0 || y == h) && (x >= 0 && x <= 3 * h); //bottom, top side
            var rectangleTopBorderLR = (x == h || x == 2 * h) && (y >= h && y <= 4 * h); //leftm right side
            var rectangleTopBorderBT = (y == 4 * h) && (x >= h && x <= 2 * h); // only top side

            if (rectangleBottom || rectangleTop || lineInBetween)
                Console.WriteLine(inside);
            else if (rectangleBottomBorderLR || rectangleBottomBorderBT || rectangleTopBorderLR || rectangleTopBorderBT)
                Console.WriteLine(border);
            else
                Console.WriteLine(outside);
        }
    }
}
