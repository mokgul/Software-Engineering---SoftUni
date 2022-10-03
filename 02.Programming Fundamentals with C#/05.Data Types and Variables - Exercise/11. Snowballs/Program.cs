using System;
using System.Numerics;

namespace _11._Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // {snowballSnow} : {snowballTime} = {snowballValue} ({snowballQuality})
            BigInteger bestValue = BigInteger.Zero;
            int[] bestValueData = new int[3];
            byte snowballsAmount = byte.Parse(Console.ReadLine());

            for (int i = 1; i <= snowballsAmount; i++)
            {
                ushort snowballSnow = ushort.Parse(Console.ReadLine());
                ushort snowballTime = ushort.Parse(Console.ReadLine());
                byte snowballQuality = byte.Parse(Console.ReadLine());

                int snowballPartValue = snowballSnow / snowballTime;
                BigInteger snowballValue = BigInteger.Pow(snowballPartValue, snowballQuality);

                if (snowballValue > bestValue)
                {
                    bestValue = snowballValue;
                    bestValueData[0] = snowballSnow;
                    bestValueData[1] = snowballTime;
                    bestValueData[2] = snowballQuality;
                }
            }

            Console.WriteLine($"{bestValueData[0]} : {bestValueData[1]} = {bestValue} ({bestValueData[2]})");
        }
    }
}