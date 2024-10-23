using System;

namespace Easter_Eggs_Battle
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstPlayer = int.Parse(Console.ReadLine());
            int secondPlayer = int.Parse(Console.ReadLine());

            string input = "";
            while (input != "End of battle")
            {
                input = Console.ReadLine();
                switch (input)
                {
                    case "one": secondPlayer--; break;
                    case "two": firstPlayer--; break;
                    case "End of battle":
                        Console.WriteLine($"Player one has {firstPlayer} eggs left.");
                        Console.WriteLine($"Player two has {secondPlayer} eggs left.");
                        break;
                }
                if (firstPlayer == 0)
                {
                    Console.WriteLine($"Player one is out of eggs. Player two has {secondPlayer} eggs left.");
                    break;
                }
                if (secondPlayer == 0)
                {
                    Console.WriteLine($"Player two is out of eggs. Player one has {firstPlayer} eggs left.");
                    break;
                }
            }
        }
    }
}
