using System;

namespace Movie_Ratings
{
    class Program
    {
        static void Main(string[] args)
        {
            double max_rating = int.MinValue;
            double min_rating = int.MaxValue;
            double average = 0;
            string max = "";
            string min = "";
            int movie_qty = int.Parse(Console.ReadLine());
            for (int i = 0; i < movie_qty; i++)
            {
                string movie = Console.ReadLine();
                double rating = double.Parse(Console.ReadLine());
                if (max_rating < rating)
                {
                    max_rating = Math.Max(max_rating, rating);
                    max = movie;
                }
                if (min_rating > rating)
                {
                    min_rating = Math.Min(min_rating, rating);
                    min = movie;
                }
                average += rating;
            }
            average /= movie_qty;
            Console.WriteLine($"{max} is with highest rating: {max_rating:f1}");
            Console.WriteLine($"{min} is with lowest rating: {min_rating:f1}");
            Console.WriteLine($"Average rating: {average:f1}");
        }
    }
}