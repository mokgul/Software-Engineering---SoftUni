using System;

namespace Лекция_3___12_13_Март
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            byte count = byte.Parse(Console.ReadLine());
            double priseForStudio = 0;
            double priseForApartment = 0;
            double totalPriseForStudio = 0;
            double totalPriseForApartment = 0;

            switch (month)
            {
                case "May":
                case "October":
                    if (count > 7 && count <= 14)
                    {
                        priseForStudio = 50;
                        priseForApartment = 65;
                        totalPriseForStudio = priseForStudio * 0.95;
                        Console.WriteLine($"Apartment: {totalPriseForApartment * count:F2} lv.");
                        Console.WriteLine($"Studio: {totalPriseForStudio * count:F2} lv.");
                    }
                    else if (count > 14)
                    {
                        priseForStudio = 50;
                        priseForApartment = 65;
                        totalPriseForApartment = priseForApartment * 0.90;
                        totalPriseForStudio = priseForStudio * 0.70;
                        Console.WriteLine($"Apartment: {totalPriseForApartment * count:F2} lv.");
                        Console.WriteLine($"Studio: {totalPriseForStudio * count:F2} lv.");
                    }
                    else
                    {
                        priseForStudio = 50;
                        priseForApartment = 65;
                        Console.WriteLine($"Apartment: {priseForApartment * count:F2} lv.");
                        Console.WriteLine($"Studio: {priseForStudio * count:F2} lv.");
                    }
                    break;
                case "June":
                case "September":
                    if (count > 14)
                    {
                        priseForStudio = 75.20;
                        priseForApartment = 68.70;
                        totalPriseForApartment = priseForApartment * 0.90;
                        totalPriseForStudio = priseForStudio * 0.80;
                        Console.WriteLine($"Apartment: {totalPriseForApartment * count:F2} lv.");
                        Console.WriteLine($"Studio: {totalPriseForStudio * count:F2} lv.");
                    }
                    else
                    {
                        priseForStudio = 75.20;
                        priseForApartment = 68.70;
                        Console.WriteLine($"Apartment: {priseForApartment * count:F2} lv.");
                        Console.WriteLine($"Studio: {priseForStudio * count:F2} lv.");
                    }
                    break;
                case "July":
                case "August":
                    if (count > 14)
                    {
                        priseForStudio = 76;
                        priseForApartment = 77;
                        totalPriseForApartment = priseForApartment * 0.90;
                        Console.WriteLine($"Apartment: {totalPriseForApartment * count:F2} lv.");
                        Console.WriteLine($"Studio: {priseForStudio * count:F2} lv.");
                    }
                    else
                    {
                        priseForStudio = 75.20;
                        priseForApartment = 68.70;
                        Console.WriteLine($"Apartment: {priseForApartment * count:F2} lv.");
                        Console.WriteLine($"Studio: {priseForStudio * count:F2} lv.");
                    }
                    break;
            }
        }
    }
}