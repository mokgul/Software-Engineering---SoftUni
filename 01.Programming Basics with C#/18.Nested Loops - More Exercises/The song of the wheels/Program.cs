using System;

namespace The_song_of_the_wheels
{
    class Program
    {
        static void Main(string[] args)
        {
            int index = 0;
            string password = "";
            int controlNum = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    for (int k = 1; k <= 9; k++)
                    {
                        for (int n = 1; n <= 9; n++)
                        {
                            var check = i * j + k * n;
                            if (check == controlNum)
                            {
                                if (i < j && k > n)
                                {
                                    Console.Write($"{i}{j}{k}{n} ");
                                    index++;
                                    if (index == 4)
                                    {
                                        password = i.ToString() + j.ToString() + k.ToString() + n.ToString();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (index < 4)
            {
                Console.WriteLine();
                Console.WriteLine("No!");
            }
            else if (password != "")
            {
                Console.WriteLine();
                Console.WriteLine($"Password: {password}");
            }
        }
    }
}
