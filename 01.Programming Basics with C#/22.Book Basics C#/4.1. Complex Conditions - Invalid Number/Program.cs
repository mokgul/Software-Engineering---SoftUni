using System;

namespace _4._1._Complex_Conditions___Invalid_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            bool valid = (num >= 100 && num <= 200) || num == 0;
            if (!valid)
                Console.WriteLine("invalid");
        }
    }
}
