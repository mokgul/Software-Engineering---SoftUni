using System;

namespace _2._2._Simple_Calculations___Exam_Problems___Change_Tiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //park
            int side = int.Parse(Console.ReadLine());
            int area = side * side;

            //tiles
            double tileLenght = double.Parse(Console.ReadLine());
            double tileWidth = double.Parse(Console.ReadLine());
            double tileArea = tileWidth * tileLenght;

            //bench
            double benchLength = double.Parse(Console.ReadLine());
            double benchWidth = double.Parse(Console.ReadLine());
            double benchArea = benchLength * benchWidth;

            //calculations
            double totalTiles = area - benchArea;
            totalTiles /= tileArea;

            double time = totalTiles * 0.2;

            //print
            Console.WriteLine(totalTiles);
            Console.WriteLine(time);
        }
    }
}
