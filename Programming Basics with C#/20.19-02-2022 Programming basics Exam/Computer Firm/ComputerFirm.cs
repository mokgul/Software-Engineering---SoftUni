using System;

namespace Computer_Firm
{
    class ComputerFirm
    {
        static void Main(string[] args)
        {
            //                    2     3       4        5       6
            string[] ratings = { "0", "0.50", "0.70", "0.85", "1.00" };
            int computersQty = int.Parse(Console.ReadLine());
            int rating = 0;
            int possibleSales = 0;
            double sales = 0;
            double totalSales = 0;
            double averageRating = 0;
            double ratingPerc = 0;

            for (int i = 1; i <= computersQty; i++)
            {
                int model = int.Parse(Console.ReadLine());
                rating = model % 10;
                averageRating += rating;
                if (rating == 2) ratingPerc = double.Parse(ratings[0]);
                else if (rating == 3) ratingPerc = double.Parse(ratings[1]);
                else if (rating == 4) ratingPerc = double.Parse(ratings[2]);
                else if (rating == 5) ratingPerc = double.Parse(ratings[3]);
                else if (rating == 6) ratingPerc = double.Parse(ratings[4]);
                possibleSales = model / 10;
                sales = possibleSales * ratingPerc;
                totalSales += sales;
            }
            averageRating /= computersQty;
            Console.WriteLine($"{totalSales:f2}");
            Console.WriteLine($"{averageRating:f2}");
        }
    }
}
