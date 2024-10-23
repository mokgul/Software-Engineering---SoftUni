using System;

namespace Suitcases_Load
{
    class Program
    {
        static void Main(string[] args)
        {
            double capacity = double.Parse(Console.ReadLine());

            string input = "";
            double suitcase = 0;
            int count = 0;

            while (input != "End")
            {
                input = Console.ReadLine();
                if (input == "End")
                {
                    Console.WriteLine("Congratulations! All suitcases are loaded!");
                    break;
                }
                suitcase = double.Parse(input);

                if ((count + 1) % 3 == 0) suitcase *= 1.1;
                if (suitcase > capacity)
                {
                    Console.WriteLine("No more space!");
                    break;
                }
                capacity -= suitcase;
                count++;
            }
            Console.WriteLine($"Statistic: {count} suitcases loaded.");
        }
    }
}
