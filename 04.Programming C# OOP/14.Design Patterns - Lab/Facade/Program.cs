using System;
using System.Threading.Channels;

namespace _06._Balanced_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int interval = int.Parse(Console.ReadLine());
            int counterOpen = 0;
            int counterClose = 0;
            for (int i = 1 ; i <= interval; i++)
            {
                string massage = Console.ReadLine();
 
                if (massage=="(")
                {
                    counterOpen++;
                }
                else if (massage==")")
                {
                    counterClose++;
                }
                else
                {
                    continue;
                }
            }
            if (counterClose == 0 && counterOpen == 0)
            {
                Console.WriteLine("UNBALANCED");
            }
            else if(counterClose==counterOpen)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }

        }
    }
}