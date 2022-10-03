using System;

namespace _08._Beer_Kegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double bestVolume = double.MinValue;
            string bestKeg = "";

            int kegsAmount = int.Parse(Console.ReadLine());
            for (int i = 0; i < kegsAmount; i++)
            {
                string model = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                double volume = Math.PI * height * Math.Pow(radius, 2);
                if (volume > bestVolume)
                {
                    bestVolume = volume;
                    bestKeg = model;
                }
            }
            Console.WriteLine(bestKeg);
        }
    }
}