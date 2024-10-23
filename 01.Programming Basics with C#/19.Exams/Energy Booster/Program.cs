using System;

namespace Energy_Booster
{
    class Program
    {
        static void Main(string[] args)
        {
            //               Watermelon  Mango  Pineapple  Raspberry
            string[] small = { "56.00", "36.66", "42.10", "20.00" };
            string[] big = { "28.70", "19.60", "24.80", "15.20" };
            bool setsizeSmall = false;
            double setPrice = 0;
            double total = 0;

            string fruit = Console.ReadLine();
            string setsize = Console.ReadLine();
            int setQty = int.Parse(Console.ReadLine());

            if (setsize == "small")
            {
                setsizeSmall = true;
            }

            switch (fruit)
            {
                case "Watermelon":
                    if (setsizeSmall)
                        setPrice = 2 * double.Parse(small[0]);
                    else
                        setPrice = 5 * double.Parse(big[0]);
                    break;
                case "Mango":
                    if (setsizeSmall)
                        setPrice = 2 * double.Parse(small[1]);
                    else
                        setPrice = 5 * double.Parse(big[1]);
                    break;
                case "Pineapple":
                    if (setsizeSmall)
                        setPrice = 2 * double.Parse(small[2]);
                    else
                        setPrice = 5 * double.Parse(big[2]);
                    break;
                case "Raspberry":
                    if (setsizeSmall)
                        setPrice = 2 * double.Parse(small[3]);
                    else
                        setPrice = 5 * double.Parse(big[3]);
                    break;
            }
            total = setQty * setPrice;
            if (total >= 400 && total <= 1000)
                total *= 0.85;
            else if (total > 1000)
                total *= 0.50;

            Console.WriteLine($"{total:f2} lv.");
        }
    }
}
