using System;

namespace Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int t = 0;
            for (int i = 1111; i <= 9999; i++)
            {
                string text = Convert.ToString(i);
                for (int h = 0; h < text.Length; h++)
                {
                    int s = int.Parse(text[h].ToString());
                    if (s == 0) continue;
                    if (a % s == 0)
                    {
                        t++;
                    }
                    else
                    {
                        t = 0;
                        break;
                    }
                }
                if (t == 4)
                {

                    Console.Write(i + " ");
                }
                t = 0;
            }
        }
    }
}