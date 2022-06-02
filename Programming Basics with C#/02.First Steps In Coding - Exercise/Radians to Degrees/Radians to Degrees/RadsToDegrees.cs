using System;

namespace USD_to_BGN
{
    class RadsToDegrees
    {
        static void Main(string[] args)
        {
            double rad = double.Parse(Console.ReadLine());
            double deg = (rad * 180) / Math.PI;
            Console.WriteLine($"{deg:f0}");
        }
    }
}
