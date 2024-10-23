using System;

namespace Weather_Forecast
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "sunny";
            string weather = Console.ReadLine();

            if (String.Equals(weather, str1) == true)
            {
                Console.WriteLine("It's warm outside!");
            }
            else if (String.Equals(weather, str1) == false)
            {
                Console.WriteLine("It's cold outside!");
            }
        }
    }
}
