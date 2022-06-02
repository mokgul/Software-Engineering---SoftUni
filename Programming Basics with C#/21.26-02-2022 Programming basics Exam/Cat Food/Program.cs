using System;

namespace Cat_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            double catfoodPricePerKg = 12.45;
            double foodPerCat = 0;
            double totalfood = 0;
            double price = 0;
            int small = 0;
            int big = 0;
            int enormous = 0;

            int catQty = int.Parse(Console.ReadLine());
            for (int i = 1; i <= catQty; i++)
            {
                foodPerCat = double.Parse(Console.ReadLine());
                totalfood += foodPerCat;
                if (foodPerCat >= 100 && foodPerCat < 200) small++;
                else if (foodPerCat >= 200 && foodPerCat < 300) big++;
                else if (foodPerCat >= 300 && foodPerCat < 400) enormous++;

            }
            price = (totalfood / 1000) * catfoodPricePerKg;
            Console.WriteLine($"Group 1: {small} cats.");
            Console.WriteLine($"Group 2: {big} cats.");
            Console.WriteLine($"Group 3: {enormous} cats.");
            Console.WriteLine($"Price for food per day: {price:f2} lv.");
        }
    }
}
