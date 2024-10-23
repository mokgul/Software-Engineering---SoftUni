using System;

namespace Easter_Decoration
{
    class Program
    {
        static void Main(string[] args)
        {
            double basket = 1.50;
            double wreath = 3.80;
            double chocoBunny = 7;
            double price = 0;
            double average = 0;
            int counter = 0;
            string input = "";

            int clients = int.Parse(Console.ReadLine());

            for (int i = 1; i <= clients; i++)
            {
                while (input != "Finish")
                {
                    input = Console.ReadLine();
                    switch (input)
                    {
                        case "basket":
                            price += basket;
                            counter++;
                            break;
                        case "wreath":
                            price += wreath;
                            counter++;
                            break;
                        case "chocolate bunny":
                            price += chocoBunny;
                            counter++;
                            break;
                        case "Finish":
                            if (counter % 2 == 0) price *= 0.80;
                            average += price;
                            Console.WriteLine($"You purchased {counter} items for {price:f2} leva.");
                            break;
                    }
                }
                price = 0;
                counter = 0;
                input = "";
            }
            average /= clients;
            Console.WriteLine($"Average bill per client is: {average:f2} leva.");
        }
    }
}
