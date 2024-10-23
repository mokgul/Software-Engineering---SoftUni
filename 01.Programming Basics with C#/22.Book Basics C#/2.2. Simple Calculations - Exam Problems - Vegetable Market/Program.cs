using System;

namespace _2._2._Simple_Calculations___Exam_Problems___Vegetable_Market
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double veggiePrice = double.Parse(Console.ReadLine());
            double fruitPrice = double.Parse(Console.ReadLine());
            int veggieAmount = int.Parse(Console.ReadLine());
            int fruitAmount = int.Parse(Console.ReadLine());

            double total = veggieAmount * veggiePrice + fruitAmount * fruitPrice;
            double totalToEUR = total / 1.94;
            Console.WriteLine(totalToEUR);
        }
    }
}
