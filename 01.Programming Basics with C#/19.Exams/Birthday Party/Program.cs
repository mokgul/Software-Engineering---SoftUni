using System;

namespace Birthday_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int rent = int.Parse(Console.ReadLine());

            double cake = 0.20 * rent;
            double drinks = 0.55 * cake;
            double animator = rent / 3;
            double total = cake + drinks + animator + rent;
            Console.WriteLine("{0:0.00}", total);
        }
    }
}
