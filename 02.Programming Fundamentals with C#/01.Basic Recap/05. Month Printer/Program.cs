using System;

namespace Month_Printer
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] months = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
            int number = int.Parse(Console.ReadLine());
            if(number > 0 && number <= 12)
            Console.WriteLine(months[number - 1]);
            else
                Console.WriteLine("Error!");
            

        }
    }
}

