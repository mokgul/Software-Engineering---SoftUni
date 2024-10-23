using System;

namespace Everest
{
    class Everest
    {
        static void Main(string[] args)
        {
            int distance = 5364;
            int peak = 8848;
            int meters = 0;
            int days = 1;

            string input = Console.ReadLine();
            while (input != "END")
            {
                meters = int.Parse(Console.ReadLine());
                if (input == "Yes")
                {
                    days++;
                    if (days > 5) break;
                    distance += meters;
                }
                else if (input == "No")
                {
                    distance += meters;
                }
                if (distance >= peak) break;
                input = Console.ReadLine();
            }
            if (distance >= peak && days <= 5)
            {
                Console.WriteLine($"Goal reached for {days} days!");
            }
            else
            {
                Console.WriteLine("Failed!");
                Console.WriteLine(distance);
            }
        }
    }
}