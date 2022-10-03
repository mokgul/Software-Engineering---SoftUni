using System;

namespace Histogram
{
    class Histogram
    {
        static void Main(string[] args)
        {
            //declaration
            int numQty = 0;
            int numbers = 0;
            double p1 = 0, p2 = 0, p3 = 0, p4 = 0, p5 = 0;
            // % for <200 , 200..399, 400..599, 600..799,>= 800

            //input
            numQty = int.Parse(Console.ReadLine());
            for (int i = 0; i < numQty; i++)
            {
                numbers = int.Parse(Console.ReadLine());
                if (numbers < 200) p1++;
                else if (numbers < 400) p2++;
                else if (numbers < 600) p3++;
                else if (numbers < 800) p4++;
                else p5++;
            }

            //calculation
            p1 = (p1 / numQty) * 100;
            p2 = (p2 / numQty) * 100;
            p3 = (p3 / numQty) * 100;
            p4 = (p4 / numQty) * 100;
            p5 = (p5 / numQty) * 100;

            //output
            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
            Console.WriteLine($"{p4:f2}%");
            Console.WriteLine($"{p5:f2}%");
        }
    }
}
