using System;

namespace Easter_Eggs
{
    class Program
    {
        static void Main(string[] args)
        {
            string color = "";
            int red = 0;
            int orange = 0;
            int blue = 0;
            int green = 0;
            int max = 0;
            string maxColor = "";

            int eggs = int.Parse(Console.ReadLine());
            for (int i = 1; i <= eggs; i++)
            {
                color = Console.ReadLine();
                switch (color)
                {
                    case "red": red++; break;
                    case "orange": orange++; break;
                    case "blue": blue++; break;
                    case "green": green++; break;
                }
                if (red > max || orange > max || blue > max || green > max)
                {
                    max++;
                    maxColor = color;
                }
            }
            Console.WriteLine($"Red eggs: {red}");
            Console.WriteLine($"Orange eggs: {orange}");
            Console.WriteLine($"Blue eggs: {blue}");
            Console.WriteLine($"Green eggs: {green}");
            Console.WriteLine($"Max eggs: {max} -> {maxColor}");
        }
    }
}
