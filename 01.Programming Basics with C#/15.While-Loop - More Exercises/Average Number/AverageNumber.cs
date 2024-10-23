using System;

namespace Average_Number
{
    class AverageNumber
    {
        static void Main(string[] args)
        {
            int numQty = 0;
            int num = 0;
            int count = 0;
            double average = 0;

            numQty = int.Parse(Console.ReadLine());
            while (count < numQty)
            {
                num = int.Parse(Console.ReadLine());
                average += num;
                count++;
            }
            average /= count;
            Console.WriteLine("{0:0.00}", average);
        }
    }
}
