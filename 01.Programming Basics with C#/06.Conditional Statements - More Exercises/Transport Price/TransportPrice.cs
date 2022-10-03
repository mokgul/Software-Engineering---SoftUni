using System;

namespace Transport_Price
{
    class TransportPrice
    {
        static void Main(string[] args)
        {
            double taxi  = 0;
            double bus   = 0;
            double train = 0;
            double price = 0;

            int distance = int.Parse(Console.ReadLine());
            string time  = Console.ReadLine();

            if (time == "day")
            {
                taxi += 0.79;
                bus += 0.09;
                train += 0.06;
            }
            else
            {
                taxi += 0.90;
                bus += 0.09;
                train += 0.06;
            }

            if (distance < 20)
            {
                price = distance * taxi + 0.70;
                Console.WriteLine("{0:0.00}",price);
            }
            else if (distance < 100)
            {
                price = distance * bus;
                Console.WriteLine("{0:0.00}", price);
            }
            else
            {
                price = distance * train;
                Console.WriteLine("{0:0.00}", price);
            }
        }
    }
}
