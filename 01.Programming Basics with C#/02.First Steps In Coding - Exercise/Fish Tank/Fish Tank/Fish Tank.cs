using System;

namespace Fish_Tank
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int width  = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            double percent = double.Parse(Console.ReadLine());

            int volume         = lenght * width * height;
            double totalLiters = volume * 0.001;
            double newPercent  = percent * 0.01;

            double result = totalLiters * (1 - newPercent);
            Console.WriteLine($"{result:F5}");


        }
    }
}
