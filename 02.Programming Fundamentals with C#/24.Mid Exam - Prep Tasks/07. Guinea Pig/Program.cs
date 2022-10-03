using System;

namespace _07._Guinea_Pig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var foodQuantity = double.Parse(Console.ReadLine()) * 1000;
            var hayQuantity = double.Parse(Console.ReadLine()) * 1000;
            var coverQuantity = double.Parse(Console.ReadLine()) * 1000;

            var guineaPigWeight = double.Parse(Console.ReadLine()) * 1000;
            const int DAILYFOOD = 300;
            bool enough = false;

            for (int i = 1; i <= 30; i++)
            {
                foodQuantity -= DAILYFOOD;
                if (i % 2 == 0)
                    hayQuantity -= 0.05 * foodQuantity;
                if (i % 3 == 0)
                    coverQuantity -= guineaPigWeight / 3;
                enough = foodQuantity > 0 && hayQuantity > 0 && coverQuantity > 0;
                if (!enough) break;
            }

            Console.WriteLine(enough
            ? $"Everything is fine! Puppy is happy! Food: {foodQuantity / 1000:f2}, Hay: {hayQuantity / 1000:f2}, Cover: {coverQuantity / 1000:f2}."
            : "Merry must go to the pet store!");
        }
    }
}
