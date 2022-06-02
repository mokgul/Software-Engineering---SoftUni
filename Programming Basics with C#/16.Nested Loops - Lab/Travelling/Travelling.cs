using System;

namespace T05.Travelling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            double minBujet = double.Parse(Console.ReadLine());
            bool end = false;

            for (double saveMoney = 0.0; saveMoney < minBujet;)
            {
                for (; saveMoney < minBujet;)
                {
                    saveMoney += double.Parse(Console.ReadLine());
                }
                Console.WriteLine($"Going to {destination}!");
                destination = Console.ReadLine();
                if (destination == "End")
                {
                    end = true;
                }
                if (end)
                {
                    break;
                }
                saveMoney = 0.0;
                minBujet = double.Parse(Console.ReadLine());
            }

        }
    }
}