using System;

namespace Personal_Titles
{
    class PersonalTitles
    {
        static void Main(string[] args)
        {
            double age    = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();

            if (gender == "m")
            {
                if (age < 16) 
                    Console.WriteLine("Master");
                else 
                    Console.WriteLine("Mr.");  
            }
            else
            {
                if (age < 16)
                    Console.WriteLine("Miss");
                else 
                    Console.WriteLine("Ms.");
            }
        }
    }
}
