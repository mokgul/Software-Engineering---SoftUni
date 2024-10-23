using System;

namespace Trekking_Mania
{
    class TrekkingMania
    {
        static void Main(string[] args)
        {
            int katerachi = int.Parse(Console.ReadLine());

            int obshtoKaterachi = 0;
            int musala = 0;
            int monblan = 0;
            int kilimandjaro = 0;
            int k2 = 0;
            int everest = 0;
            for (int i = 1; i <= katerachi; i++)
            {
                int grupaKaterachi = int.Parse(Console.ReadLine());
                obshtoKaterachi += grupaKaterachi;
                if (grupaKaterachi <= 5)
                {
                    musala += grupaKaterachi;
                }
                else if (grupaKaterachi <= 12)
                {
                    monblan += grupaKaterachi;
                }
                else if (grupaKaterachi <= 25)
                {
                    kilimandjaro += grupaKaterachi;
                }
                else if (grupaKaterachi <= 40)
                {
                    k2 += grupaKaterachi;
                }
                else
                {
                    everest += grupaKaterachi;
                }
            }
            Console.WriteLine($"{musala / obshtoKaterachi * 100:f2}%");
            Console.WriteLine($"{monblan / obshtoKaterachi * 100:f2}%");
            Console.WriteLine($"{kilimandjaro / obshtoKaterachi * 100:f2}%");
            Console.WriteLine($"{k2 / obshtoKaterachi * 100:f2}%");
            Console.WriteLine($"{everest / obshtoKaterachi * 100:f2}%");
        }
    }
}
