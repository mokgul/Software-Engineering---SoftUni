using System;

namespace Darts
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string type = "";
            int score = 301;
            int points = 0;
            int successful = 0;
            int unsuccessful = 0;

            while (score > 0)
            {
                type = Console.ReadLine();
                if (type != "Retire")
                {
                    points = int.Parse(Console.ReadLine());
                }
                switch (type)
                {
                    case "Single":
                        if (points <= score)
                        {
                            score -= points;
                            successful++;
                        }
                        else
                            unsuccessful++;
                        break;
                    case "Double":
                        points *= 2;
                        if (points <= score)
                        {
                            score -= points;
                            successful++;
                        }
                        else
                            unsuccessful++;
                        break;
                    case "Triple":
                        points *= 3;
                        if (points <= score)
                        {
                            score -= points;
                            successful++;
                        }
                        else
                            unsuccessful++;
                        break;
                    case "Retire":
                        Console.WriteLine($"{name} retired after {unsuccessful} unsuccessful shots.");
                        score = 0;
                        break;
                }
            }
            if (type != "Retire")
                Console.WriteLine($"{name} won the leg with {successful} shots.");
        }
    }
}
