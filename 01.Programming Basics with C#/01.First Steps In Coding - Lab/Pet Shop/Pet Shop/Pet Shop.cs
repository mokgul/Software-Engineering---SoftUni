using System;

namespace Pet_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogs             = int.Parse(Console.ReadLine());
            int others           = int.Parse(Console.ReadLine());
            double dogfood_price = dogs * 2.50;
            double othersprice   = others * 4;
            double total         = dogfood_price + othersprice;
            Console.WriteLine($"{total} lv.");
        }
    }
}
