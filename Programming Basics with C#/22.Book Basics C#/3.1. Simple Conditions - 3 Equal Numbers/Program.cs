using System;

namespace _3._1._Simple_Conditions___3_Equal_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            if (a == b && b == c)
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");
        }
    }
}
