using System;

namespace Easter_Bakery
{
    class Program
    {
        static void Main(string[] args)
        {
            double flourPrice = double.Parse(Console.ReadLine());
            double flourQty = double.Parse(Console.ReadLine());
            double sugarQty = double.Parse(Console.ReadLine());
            int eggsQty = int.Parse(Console.ReadLine());
            int yeastQty = int.Parse(Console.ReadLine());

            double sugarPrice = 0.75 * flourPrice;
            double eggsPrice = 1.1 * flourPrice;
            double yeastPrice = 0.20 * sugarPrice;

            double total = flourQty * flourPrice + sugarQty * sugarPrice + eggsQty * eggsPrice + yeastQty * yeastPrice;
            Console.WriteLine($"{total:f2}");
        }
    }
}
