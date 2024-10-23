using System;

namespace Pastry_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            //..                    Cake    Souffle  Baklava
            string[] preDate = { "24.00", "6.66", "12.60" };
            string[] afterDate = { "28.70", "9.80", "16.98" };
            double price = 0;
            double total = 0;

            string dessert = Console.ReadLine();
            int amount = int.Parse(Console.ReadLine());
            int date = int.Parse(Console.ReadLine());

            switch (dessert)
            {
                case "Cake":
                    if (date <= 15) price = double.Parse(preDate[0]);
                    else
                        price = double.Parse(afterDate[0]);
                    break;
                case "Souffle":
                    if (date <= 15) price = double.Parse(preDate[1]);
                    else
                        price = double.Parse(afterDate[1]); break;
                case "Baklava":
                    if (date <= 15) price = double.Parse(preDate[2]);
                    else
                        price = double.Parse(afterDate[2]); break;
            }
            total = amount * price;
            if (date <= 22)
            {
                if (total >= 100 && total <= 200) total *= 0.85;
                else if (total > 200) total *= 0.75;
                if (date <= 15) total *= 0.90;
            }
            Console.WriteLine("{0:0.00}", total);
        }
    }
}
