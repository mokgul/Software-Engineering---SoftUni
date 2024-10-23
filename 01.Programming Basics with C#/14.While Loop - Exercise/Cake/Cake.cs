using System;

namespace Cake
{
    class Cake
    {
        static void Main(string[] args)
        {
            string input = "";
            int peicesTaken = 0;

            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int piecesQty = Math.Abs(width * height);

            while (input != "STOP")
            {
                input = Console.ReadLine();
                if (input == "STOP" && peicesTaken < piecesQty)
                {
                    Console.WriteLine($"{piecesQty} pieces are left.");
                    break;
                }
                peicesTaken = int.Parse(input);
                piecesQty -= peicesTaken;
                if (piecesQty <= 0)
                {
                    Console.WriteLine($"No more cake left! You need {Math.Abs(piecesQty)} pieces more.");
                    break;
                }
            }
        }
    }
}
