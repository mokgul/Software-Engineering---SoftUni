using System;

namespace Football_League
{
    class FootBallLeague
    {
        static void Main(string[] args)
        {
            double sectorA = 0, sectorB = 0, sectorC = 0, sectorD = 0;
            double totalFansPercent = 0;

            int stadionCapacity = int.Parse(Console.ReadLine());
            int totalFans = int.Parse(Console.ReadLine());
            for (int i = 0; i < totalFans; i++)
            {
                string fanSector = Console.ReadLine();
                switch (fanSector)
                {
                    case "A": sectorA++; break;
                    case "B": sectorB++; break;
                    case "V": sectorC++; break;
                    case "G": sectorD++; break;
                }
            }
            sectorA = (sectorA / totalFans) * 100;
            sectorB = (sectorB / totalFans) * 100;
            sectorC = (sectorC / totalFans) * 100;
            sectorD = (sectorD / totalFans) * 100;
            totalFansPercent = ((double)totalFans / stadionCapacity) * 100;

            Console.WriteLine($"{sectorA:f2}%");
            Console.WriteLine($"{sectorB:f2}%");
            Console.WriteLine($"{sectorC:f2}%");
            Console.WriteLine($"{sectorD:f2}%");
            Console.WriteLine($"{totalFansPercent:f2}%");
        }
    }
}
