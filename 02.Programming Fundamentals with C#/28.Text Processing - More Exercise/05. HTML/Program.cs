using System;
 
namespace _01._Oscars_ceremony
{
    internal class Program
    {
        static void Main()
        {
            var moviesCount = int.Parse(Console.ReadLine());
            var averageRating = 0.0;
            double maxRating = double.MinValue;
            string maxRatingMovie = "";
            double minRating = double.MaxValue;
            string minRatingMovie = "";
 
            for (int i = moviesCount; i > 0; i--)
            {
                var movieName = Console.ReadLine();
                var movieRating = double.Parse(Console.ReadLine());
 
                if (movieRating > maxRating)
                {
                    maxRating = movieRating;
                    maxRatingMovie = movieName;
                }
                if (movieRating < minRating)
                {
                    minRating = movieRating;
                    minRatingMovie = movieName;
                }
                averageRating += movieRating;
            }
            averageRating /= moviesCount;
 
            Console.WriteLine($"{String.Format("{0:0.0}", maxRatingMovie)} is with highest rating: {maxRating}");
            Console.WriteLine($"{String.Format("{0:0.0}", minRatingMovie)} is with lowest rating: {minRating}");
            Console.WriteLine("Average rating: " + String.Format("{0:0.0}", averageRating));
 
        }
    }
}