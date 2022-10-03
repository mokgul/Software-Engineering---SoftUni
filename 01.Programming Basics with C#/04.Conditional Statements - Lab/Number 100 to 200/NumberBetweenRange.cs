using System;

namespace Number_100_to_200
{
    class NumberBetweenRange
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            if (num < 100)
            { Console.WriteLine("Less than 100"); }
            else if (num <= 200)
            { Console.WriteLine("Between 100 and 200"); }
            else 
            { Console.WriteLine("Greater than 200"); }
        }
    }
}
