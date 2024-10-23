using System;

namespace Change_Bureau
{
    class Program
    {
        static void Main(string[] args)
        {
            int bitcoins = int.Parse(Console.ReadLine());
            double yuans = double.Parse(Console.ReadLine());
            double commission = double.Parse(Console.ReadLine());

            bitcoins *= 1168;  // bitcoins to bgn
            yuans *= 0.15;     // yuans to usd
            yuans *= 1.76;     // usd to bgn
            double total = bitcoins + yuans;  // in bgn
            total /= 1.95;     // bgn to euro
            total -= total * (commission / 100);
            Console.WriteLine("{0:0.00}", total);
        }
    }
}
