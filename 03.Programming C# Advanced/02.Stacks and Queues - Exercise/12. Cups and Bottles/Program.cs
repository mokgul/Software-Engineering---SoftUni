using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    internal class WaterGame
    {
        private static Queue<int> _cups;
        private static Stack<int> _bottles;
        private static int wasted;
        static void Main(string[] args)
        {
            Inputs();
            Filling();
        }

        private static void Filling()
        {
            while(true)
            {
                if (WaterGame._cups.Count == 0)
                {
                    Console.WriteLine($"Bottles: {string.Join(" ",WaterGame._bottles)}");
                    Console.WriteLine($"Wasted litters of water: {WaterGame.wasted}");
                    break;
                }
                int cup = WaterGame._cups.Peek();
                while (cup > 0)
                {
                    if (WaterGame._bottles.Count == 0)
                    {
                        Console.WriteLine($"Cups: {string.Join(" ",WaterGame._cups)}");
                        Console.WriteLine($"Wasted litters of water: {WaterGame.wasted}");
                        return;
                    }
                    int bottle = WaterGame._bottles.Peek();
                    if (bottle <= cup)
                    {
                        WaterGame._bottles.Pop();
                        if (bottle == cup)
                            WaterGame._cups.Dequeue();
                        cup -= bottle;
                    }
                    else
                    {
                        WaterGame._bottles.Pop();
                        WaterGame._cups.Dequeue();
                        WaterGame.wasted += bottle - cup;
                        cup -= bottle;
                    }
                }
            }
        }

        private static void Inputs()
        {
            WaterGame._cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            WaterGame._bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
        }
    }
}
