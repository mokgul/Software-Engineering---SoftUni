using System;

namespace Pool_Day
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            double entry = double.Parse(Console.ReadLine());
            double sunbedPrice = double.Parse(Console.ReadLine());
            double umbrellaPrice = double.Parse(Console.ReadLine());

            double sunbeds = Math.Ceiling(people * 0.75);
            double umbrellas = Math.Ceiling(people / 2.0);
            double total = people * entry + sunbeds * sunbedPrice + umbrellas * umbrellaPrice;
            Console.WriteLine($"{total:f2} lv.");
        }
    }
}
