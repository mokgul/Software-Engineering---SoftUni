using System;

namespace Basketball_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int rate       = int.Parse(Console.ReadLine());
            double shoes   = 0.60 * rate;
            double clothes = 0.80 * shoes;
            double ball    = 0.25 * clothes;
            double accs    = 0.20 * ball;
            Console.WriteLine(rate + shoes + clothes + ball + accs);
        }
    }
}
