using System;

namespace _4._1._Complex_Conditions___Point_on_Rectangle_Border
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //declaration
            string border = "Border";
            string inOut = "Inside / Outside";
            string check = "";

            //input
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            //calculation
            //checking if the point is on the border
            if ((x == x1 || x == x2) && (y >= y1 && y <= y2))
                check = border;
            else if ((y == y1 || y == y2) && (x >= x1 && x <= x2))
                check = border;
            else
                check = inOut;

            //output
            Console.WriteLine(check);
        }
    }
}
