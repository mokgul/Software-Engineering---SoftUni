using System;

namespace _4._1._Complex_Conditions___Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double premiere = 12.00;
            double normal = 7.50;
            double discount = 5.00;
            double income = 0.0;

            string type = Console.ReadLine().ToLower();
            int rows = int.Parse(Console.ReadLine());
            int colums = int.Parse(Console.ReadLine());

            if (type == "premiere")
                income = rows * colums * premiere;
            else if (type == "normal")
                income = rows * colums * normal;
            else if (type == "discount")
                income = rows * colums * discount;
            else Console.WriteLine("error");

            Console.WriteLine($"{income:f2} leva");
        }
    }
}
