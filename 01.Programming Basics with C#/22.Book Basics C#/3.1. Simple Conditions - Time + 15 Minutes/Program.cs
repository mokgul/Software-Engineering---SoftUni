using System;
using System.Xml.Schema;

namespace _3._1._Simple_Conditions___Time___15_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int total = hours * 60 + minutes + 15;
            int newHour = total / 60;
            int newMinute = total % 60;

            if(newHour > 23)
                newHour -= 24;

            if (newMinute < 10)
                Console.WriteLine(newHour + ":0" + newMinute);
            else
                Console.WriteLine(newHour + ":" + newMinute);
        }
    }
}
