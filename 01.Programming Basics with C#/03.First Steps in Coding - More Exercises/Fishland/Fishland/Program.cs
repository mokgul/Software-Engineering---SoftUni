using System;

namespace Fishland
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double skumriaPrice  = double.Parse(Console.ReadLine());
            double cacaPrice     = double.Parse(Console.ReadLine());
            double palamudAmount = double.Parse(Console.ReadLine());
            double safridAmount  = double.Parse(Console.ReadLine());
            double midiAmount    = double.Parse(Console.ReadLine());
            double palamudPrice  = skumriaPrice + 0.6 * skumriaPrice;
            double safridPrice   = cacaPrice + 0.8 * cacaPrice;
            double total = palamudAmount * palamudPrice + safridAmount * safridPrice + midiAmount * 7.50;
            Console.WriteLine($"{total:f2}");

        }
    }
}
