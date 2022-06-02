using System;

namespace Trekking_Mania
{
    class TrekkingMania
    {
        static void Main(string[] args)
        {
            //declaration
            int groupsQty;
            int peoplePerGroup = 0;
            double totalPeople = 0;
            int peak01 = 0, peak02 = 0, peak03 = 0, peak04 = 0, peak05 = 0; // Musala, Mont Blanc, Kilimanjaro, K2, Everest
            double[] percPeak = new double[5];

            //input and calculation
            groupsQty = int.Parse(Console.ReadLine());
            for (int i = 0; i < groupsQty; i++)
            {
                peoplePerGroup = int.Parse(Console.ReadLine());
                totalPeople += peoplePerGroup;
                if (peoplePerGroup <= 5) peak01 += peoplePerGroup;
                else if (peoplePerGroup <= 12) peak02 += peoplePerGroup;
                else if (peoplePerGroup <= 25) peak03 += peoplePerGroup;
                else if (peoplePerGroup <= 40) peak04 += peoplePerGroup;
                else if (peoplePerGroup > 40) peak05 += peoplePerGroup;
            }
            percPeak[0] = (peak01 / totalPeople) * 100;
            percPeak[1] = (peak02 / totalPeople) * 100;
            percPeak[2] = (peak03 / totalPeople) * 100;
            percPeak[3] = (peak04 / totalPeople) * 100;
            percPeak[4] = (peak05 / totalPeople) * 100;

            //output

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{percPeak[i]:f2}%");
            }
        }
    }
}
