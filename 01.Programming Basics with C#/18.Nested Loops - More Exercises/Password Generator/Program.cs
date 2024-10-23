using System;

namespace Password_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            l += 96;
            // from char list for visual, lowercase a starts at 97, so 1 + 96 returns 'a'
            char o = Convert.ToChar(l);
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    for (char k = 'a'; k <= o; k++)
                    {
                        for (char m = 'a'; m <= o; m++)
                        {
                            for (int s = 1; s <= n; s++)
                            {
                                if (s > i && s > j)
                                {
                                    Console.Write($"{i}{j}{k}{m}{s} ");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
