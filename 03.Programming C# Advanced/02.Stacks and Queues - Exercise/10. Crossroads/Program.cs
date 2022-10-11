using System;
using System.Collections.Generic;

namespace _10._Crossroads
{
    internal class Crossroad
    {
        private static int _green;
        private static int _freeWindow;
        private static int _carsPassed = 0;
        private static bool _crash = false;
        private static Queue<string> _cars = new Queue<string>();

        static void Main(string[] args)
        {
            Inputs();
            if(!Crossroad._crash)
            {
                Console.WriteLine($"Everyone is safe.");
                Console.WriteLine($"{Crossroad._carsPassed} total cars passed the crossroads.");
            }
        }

        private static void Inputs()
        {
            Crossroad._green = int.Parse(Console.ReadLine());
            Crossroad._freeWindow = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            while (input != "END")
            {
                if (input == "green") GreenLight();
                if(Crossroad._crash) return;
                Crossroad._cars.Enqueue(input);
                input = Console.ReadLine();
            }
        }

        private static void GreenLight()
        {
            int green = Crossroad._green;
            int freeWindow = Crossroad._freeWindow;
            while (true)
            {
                if (Crossroad._cars.Count == 0) break;
                if(Crossroad._cars.Peek().Length <= green)
                {
                    green -= Crossroad._cars.Peek().Length;
                    Crossroad._cars.Dequeue();
                    Crossroad._carsPassed++;
                }
                else
                {
                    int leftToPass = Crossroad._cars.Peek().Length - green;
                    green = 0;
                    if (leftToPass <= freeWindow)
                    {
                        freeWindow -= leftToPass;
                        Crossroad._cars.Dequeue();
                        Crossroad._carsPassed++;
                    }
                    else
                    {
                        string car = Crossroad._cars.Peek();
                        int index = car.Length - (leftToPass - freeWindow);
                        Console.WriteLine($"A crash happened!");
                        Console.WriteLine($"{car} was hit at {car[index]}.");
                        Crossroad._crash = true;
                    }
                }
                if (green == 0) break;
            }
        }
    }
}
