using System;

namespace Supplies_for_School
{
    class Program
    {
        static void Main(string[] args)
        {
            int numPens    = int.Parse(Console.ReadLine());
            int numMarkers = int.Parse(Console.ReadLine());
            int Lsolution  = int.Parse(Console.ReadLine());
            int discount   = int.Parse(Console.ReadLine());
            double sum     = numPens * 5.80 + numMarkers * 7.20 + Lsolution * 1.20;
            double sumDiscount = sum - (sum * discount) / 100;
            Console.WriteLine(sumDiscount);
        }
    }
}
