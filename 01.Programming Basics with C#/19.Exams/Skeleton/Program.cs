using System;

namespace Skeleton
{
    class Program
    {
        static void Main(string[] args)
        {
            int controlMinutes = int.Parse(Console.ReadLine());
            int controlSeconds = int.Parse(Console.ReadLine());
            double lenght = double.Parse(Console.ReadLine());
            int secondsPM = int.Parse(Console.ReadLine());

            int controlTime = controlMinutes * 60 + controlSeconds;
            double delay = (lenght / 120) * 2.5;
            double playerTIme = (lenght / 100) * secondsPM - delay;

            if (playerTIme <= controlTime)
            {
                Console.WriteLine($"Marin Bangiev won an Olympic quota!");
                Console.WriteLine($"His time is {playerTIme:f3}.");
            }
            else
                Console.WriteLine($"No, Marin failed! He was {(playerTIme - controlTime):f3} second slower.");
        }
    }
}
