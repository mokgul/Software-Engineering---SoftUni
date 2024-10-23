using System;

namespace _2._1._Simple_Calculations___Square_area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("a = ");
            int a = int.Parse(Console.ReadLine());
            int area = a * a;
            Console.Write("Square area = ");
            Console.WriteLine(area);
        }
    }
}
