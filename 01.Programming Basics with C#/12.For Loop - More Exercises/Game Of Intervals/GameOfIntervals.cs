using System;

namespace Game_Of_Intervals
{
    class GameOfIntervals
    {
        static void Main(string[] args)
        {
            double result = 0;
            double int1 = 0.20;
            double int2 = 0.30;
            double int3 = 0.40;
            double int4 = 50;
            double int5 = 100;
            double invalid = 2;
            double p1 = 0, p2 = 0, p3 = 0, p4 = 0, p5 = 0, percInv = 0;

            int moves = int.Parse(Console.ReadLine());
            for (int i = 0; i < moves; i++)
            {
                double num = double.Parse(Console.ReadLine());
                switch (num)
                {
                    case double n when (num >= 0 && num <= 9):
                        num *= int1;
                        result += num;
                        p1++;
                        break;
                    case double n when (num >= 10 && num <= 19):
                        num *= int2;
                        result += num;
                        p2++;
                        break;
                    case double n when (num >= 20 && num <= 29):
                        num *= int3;
                        result += num;
                        p3++;
                        break;
                    case double n when (num >= 30 && num <= 39):
                        num = int4;
                        result += num;
                        p4++;
                        break;
                    case double n when (num >= 40 && num <= 50):
                        num = int5;
                        result += num;
                        p5++;
                        break;
                    default:
                        result /= invalid;
                        percInv++;
                        break;
                }
            }
            p1 = (p1 / moves) * 100;
            p2 = (p2 / moves) * 100;
            p3 = (p3 / moves) * 100;
            p4 = (p4 / moves) * 100;
            p5 = (p5 / moves) * 100;
            percInv = (percInv / moves) * 100;

            Console.WriteLine("{0:0.00}", result);
            Console.WriteLine($"From 0 to 9: {p1:f2}%");
            Console.WriteLine($"From 10 to 19: {p2:f2}%");
            Console.WriteLine($"From 20 to 29: {p3:f2}%");
            Console.WriteLine($"From 30 to 39: {p4:f2}%");
            Console.WriteLine($"From 40 to 50: {p5:f2}%");
            Console.WriteLine($"Invalid numbers: {percInv:f2}%");
        }
    }
}
