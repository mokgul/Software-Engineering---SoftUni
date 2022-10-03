using System;

namespace Summer_Outfit
{
    class SummerOutfit
    {
        static void Main(string[] args)
        {
            string[] outfit = { "Sweatshirt", "Shirt", "T-Shirt", "Swim Suit" };
            string[] shoes = { "Sneakers", "Moccasins", "Sandals", "Barefoot" };
            string outfitChoice = "";
            string shoesChoice = "";
            int temp = int.Parse(Console.ReadLine());
            string time = Console.ReadLine().ToLower();

            if (temp >= 10 && temp <= 18)
                switch (time)
                {
                    case "morning":
                        outfitChoice = outfit[0];
                        shoesChoice = shoes[0];
                        break;
                    case "afternoon":
                        outfitChoice = outfit[1];
                        shoesChoice = shoes[1];
                        break;
                    case "evening":
                        outfitChoice = outfit[1];
                        shoesChoice = shoes[1];
                        break;
                }
            else if (temp <= 24)
                switch (time)
                {
                    case "morning":
                        outfitChoice = outfit[1];
                        shoesChoice = shoes[1];
                        break;
                    case "afternoon":
                        outfitChoice = outfit[2];
                        shoesChoice = shoes[2];
                        break;
                    case "evening":
                        outfitChoice = outfit[1];
                        shoesChoice = shoes[1];
                        break;
                }
            else if (temp >= 25)
                switch (time)
                {
                    case "morning":
                        outfitChoice = outfit[2];
                        shoesChoice = shoes[2];
                        break;
                    case "afternoon":
                        outfitChoice = outfit[3];
                        shoesChoice = shoes[3];
                        break;
                    case "evening":
                        outfitChoice = outfit[1];
                        shoesChoice = shoes[1];
                        break;
                }
            Console.WriteLine($"It's {temp} degrees, get your {outfitChoice} and {shoesChoice}.");
        }
    }
}
