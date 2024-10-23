using System;

namespace Moving
{
    class Moving
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int freeSpace = width * lenght * height;
            int boxCount = 0;
            int spaceTaken = 0;
            string input = "";

            while (input != "Done")
            {
                input = Console.ReadLine();
                if (input == "Done" && spaceTaken <= freeSpace)
                {
                    Console.WriteLine($"{freeSpace - spaceTaken} Cubic meters left.");
                    break;
                }
                boxCount = int.Parse(input);
                spaceTaken += boxCount;
                if (spaceTaken > freeSpace)
                {
                    Console.WriteLine($"No more free space! You need {spaceTaken - freeSpace} Cubic meters more.");
                    break;
                }
            }
        }
    }
}
