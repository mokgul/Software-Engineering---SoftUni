using System;

namespace Area_of_Figures
{
    class AreaOfFigures
    {
        static void Main(string[] args)
        {
            double area = 0;
            string shape = Console.ReadLine();
            switch (shape)
            {
                case "square": //"square" is the value of shape
                    double side = double.Parse(Console.ReadLine());
                    area = side * side;
                    Console.WriteLine(area);
                    break;

                case "rectangle":
                    double sideA = double.Parse(Console.ReadLine());
                    double sideB = double.Parse(Console.ReadLine());
                    area = sideA * sideB;
                    Console.WriteLine(area);
                    break;

                case "circle":
                    double radius = double.Parse(Console.ReadLine());
                    area = radius * radius * Math.PI;
                    Console.WriteLine(area);
                    break;

                case "triangle":
                    double sideT = double.Parse(Console.ReadLine());
                    double height = double.Parse(Console.ReadLine());
                    area = sideT * height * 0.5;
                    Console.WriteLine(area);
                    break;
            }
            
        }
    }
}
