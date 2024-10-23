using System;

namespace Painting_Eggs
{
    class Program
    {
        static void Main(string[] args)
        {
            //..               Red   Green Yellow
            string[] large = { "16", "12", "9" };
            string[] medium = { "13", "9", "7" };
            string[] small = { "9", "8", "5" };
            double price = 0;

            string size = Console.ReadLine();
            string color = Console.ReadLine();
            int amount = int.Parse(Console.ReadLine());

            switch (size)
            {
                case "Large":
                    switch (color)
                    {
                        case "Red":
                            price = double.Parse(large[0]);
                            break;
                        case "Green":
                            price = double.Parse(large[1]);
                            break;
                        case "Yellow":
                            price = double.Parse(large[2]);
                            break;
                    }
                    break;
                case "Medium":
                    switch (color)
                    {
                        case "Red":
                            price = double.Parse(medium[0]);
                            break;
                        case "Green":
                            price = double.Parse(medium[1]);
                            break;
                        case "Yellow":
                            price = double.Parse(medium[2]);
                            break;
                    }
                    break;
                case "Small":
                    switch (color)
                    {
                        case "Red":
                            price = double.Parse(small[0]);
                            break;
                        case "Green":
                            price = double.Parse(small[1]);
                            break;
                        case "Yellow":
                            price = double.Parse(small[2]);
                            break;
                    }
                    break;
            }
            price *= amount;
            price *= 0.65;
            Console.WriteLine($"{price:f2} leva.");
        }
    }
}
