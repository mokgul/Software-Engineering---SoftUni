using System;

namespace Vegetable_Market
{
    class VegetableMarket
    {
        static void Main(string[] args)
        {
            double veggiePrice = double.Parse(Console.ReadLine());
            double fruitPrice  = double.Parse(Console.ReadLine());
            int veggieAmount   = int.Parse(Console.ReadLine());
            int fruitAmount    = int.Parse(Console.ReadLine());
            double total = (veggiePrice * veggieAmount + fruitPrice * fruitAmount) / 1.94;
            //Console.WriteLine($"{total:f2}");
            Console.WriteLine(total);

        }
    }
}
