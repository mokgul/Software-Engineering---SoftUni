using System;

namespace Renovation
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            double freespace = double.Parse(Console.ReadLine()) / 100;

            double area = Math.Ceiling((4 * (height * width)) * (1 - freespace));

            string command = Console.ReadLine();
            while (command != "Tired!")
            {
                area -= int.Parse(command);
                if (area <= 0) break;
                command = Console.ReadLine();
            }
            if (area > 0)
                Console.WriteLine($"{area} quadratic m left.");
            else if (area < 0)
                Console.WriteLine($"All walls are painted and you have {Math.Abs(area)} l paint left!");
            else if (area == 0)
                Console.WriteLine($"All walls are painted! Great job, Pesho!");
        }
    }
}
