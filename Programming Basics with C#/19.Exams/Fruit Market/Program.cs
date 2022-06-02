using System;

namespace Fruit_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double strawberriesPrice = double.Parse(Console.ReadLine());
            double bananasAmount = double.Parse(Console.ReadLine());
            double orangesAmount = double.Parse(Console.ReadLine());
            double raspberriesAmount = double.Parse(Console.ReadLine());
            double strawberriesAmount = double.Parse(Console.ReadLine());

            double raspberriesPrice = 0.50 * strawberriesPrice;
            double orangesPrice = 0.60 * raspberriesPrice;
            double bananasPrice = 0.20 * raspberriesPrice;

            double strawberry = strawberriesPrice * strawberriesAmount;
            double banana = bananasPrice * bananasAmount;
            double orange = orangesPrice * orangesAmount;
            double raspberry = raspberriesPrice * raspberriesAmount;
            double total = strawberry + banana + orange + raspberry;
            Console.WriteLine("{0:0.00}", total);
        }
    }
}
