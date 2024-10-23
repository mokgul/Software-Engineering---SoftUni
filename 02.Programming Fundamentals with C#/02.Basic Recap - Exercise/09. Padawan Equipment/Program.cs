using System;

namespace Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget           = double.Parse(Console.ReadLine());
            int students            =    int.Parse(Console.ReadLine());
            double lightsaber_price = double.Parse(Console.ReadLine());
            double robe_price       = double.Parse(Console.ReadLine());
            double belt_price       = double.Parse(Console.ReadLine());

            double lightsabers_total = Math.Ceiling(students * 1.1) * lightsaber_price;
            double robes_total = students * robe_price;
            int free_belts = students / 6;
            double belt_total = (students - free_belts) * belt_price;
            double total = lightsabers_total + robes_total + belt_total;
            if ((budget - total) >= 0)
            {
                Console.WriteLine($"The money is enough - it would cost {total:f2}lv.");
            }
            else
                Console.WriteLine($"John will need {(total - budget):f2}lv more.");
        }
    }
}