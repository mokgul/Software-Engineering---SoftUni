using System;

namespace Movie_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            int tickets = int.Parse(Console.ReadLine());
            double price = double.Parse(Console.ReadLine());
            int percentProfit = 100 - int.Parse(Console.ReadLine());

            double profit = price * tickets * days;
            profit *= (percentProfit / 100.00);
            Console.WriteLine($"The profit from the movie {movie} is {profit:f2} lv.");
        }
    }
}
