using System;

namespace Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            int plasticAmount = int.Parse(Console.ReadLine());
            int paintAmount   = int.Parse(Console.ReadLine());
            int thinnerAmount = int.Parse(Console.ReadLine());
            int hoursWorked   = int.Parse(Console.ReadLine());
            double plastic    = (plasticAmount + 2) * 1.50;
            double paint      = (paintAmount * 1.10) * 14.50;
            double sumMats    = plastic + paint + thinnerAmount * 5 + 0.40;
            double workersPay = (0.30 * sumMats)*hoursWorked;
            Console.WriteLine(sumMats + workersPay);
        }
    }
}
