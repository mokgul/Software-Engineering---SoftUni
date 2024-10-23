using System;

namespace _4._1._Complex_Conditions___Personal_Titles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();

            if (gender == "m")
            {
                if (age < 16) Console.WriteLine("Master");
                else Console.WriteLine("Mr.");
            }
            else
            {
                if (age < 16) Console.WriteLine("Miss");
                else Console.WriteLine("Ms.");
            }
        }
    }
}
