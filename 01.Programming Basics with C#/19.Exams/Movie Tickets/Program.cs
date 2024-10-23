using System;

namespace Movie_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            int a1 = int.Parse(Console.ReadLine());
            int a2 = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            for (char i = (char)a1; i <= ((char)a2 - 1); i++)
            {
                for (int j = 1; j <= (n - 1); j++)
                {
                    for (int k = 1; k <= ((n / 2) - 1); k++)
                    {
                        int m = i;
                        if ((int)i % 2 == 1)
                        {
                            if ((j + k + m) % 2 == 1)
                                Console.WriteLine($"{i}-{j}{k}{m}");
                        }
                    }
                }
            }
        }
    }
}


}
