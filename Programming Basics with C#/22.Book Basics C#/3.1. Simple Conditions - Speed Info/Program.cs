using System;

namespace _3._1._Simple_Conditions___Speed_Info
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double speed = double.Parse(Console.ReadLine());

            if (speed <= 10)
                Console.WriteLine("slow");

            else if (speed <= 50)
                Console.WriteLine("average");

            else if (speed <= 150)
                Console.WriteLine("fast");

            else if (speed <= 1000)
                Console.WriteLine("ultra fast");

            else
                Console.WriteLine("extremely fast");

            //shorter way
            //string speedInfo = (speed <= 10) ? "slow" :
            //    (speed <= 50) ? "average" :
            //    (speed <= 150) ? "fast" :
            //    (speed < 1000) ? "ultra fast" :
            //    "extremely fast";
            //Console.WriteLine(speedInfo);
        }
    }
}
