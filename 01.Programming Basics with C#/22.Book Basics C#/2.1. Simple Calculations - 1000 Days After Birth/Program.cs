using System;
using System.Globalization;

namespace _2._1._Simple_Calculations___1000_Days_After_Birth
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime date = DateTime.ParseExact(
                Console.ReadLine(),
                "dd-MM-yyyy",
                CultureInfo.InvariantCulture); // -> provider

            //DateTime - type of variable, in that case a date
            //ParseExact - a method from the DateTime class which converts the string into a date
            //ParseExact takes 3 arguments: string, format of the date, provider
            //string - the input from the console
            //format - "dd-MM-yyyy", the desired format of the date
            //provider - information about a specific culture
            //InvariantCulture ignores the local information of the computer

            date = date.AddDays(1000);
            //AddDays is a method from the DateTime class, adds the value in the brackets
            Console.WriteLine(date.ToString("dd-MM-yyyy"));
            //Converting the date into a string with the given format
        }
    }
}
