using System;

namespace Best_Player
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            string bestPlayer = "";
            int record = 0;
            int goals = 0;
            while (input != "END")
            {
                if (goals >= 10) break;
                input = Console.ReadLine();
                if (input == "END") break;

                goals = int.Parse(Console.ReadLine());
                if (goals > record)
                {
                    bestPlayer = input;
                    record = goals;
                }

            }
            Console.WriteLine($"{bestPlayer} is the best player!");
            if (goals > 2)
            {
                Console.WriteLine($"He has scored {record} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {record} goals.");
            }
        }
    }
}
