using System;
using System.Runtime.InteropServices;

namespace _01._Cooking_Masterclass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double flourPrice = double.Parse(Console.ReadLine());
            double eggPrice = double.Parse(Console.ReadLine());
            double apronPrice = double.Parse(Console.ReadLine());

            int flourPackages = students - (students / 5);
            int aprons = students + (int)Math.Ceiling(students * 0.20);
            double total = flourPackages * flourPrice + students * 10 * eggPrice + aprons * apronPrice;

            if (budget >= total)
            {
                Console.WriteLine($"Items purchased for {total:f2}$.");
            }
            else
            {
                Console.WriteLine($"{(total - budget):f2}$ more needed.");
            }
        }
    }
}
