using System;

namespace _3._2._Simple_Conditions___Exam_Problems___Transport_Price
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double taxi = 0;
            double bus = 0.09;
            double train = 0.06;
            double price = 0;

            int distance = int.Parse(Console.ReadLine());
            string time = Console.ReadLine();

            if (time == "day")
                taxi += 0.79;
            
            else
                taxi += 0.90;

            if (distance < 20)
                price = distance * taxi + 0.70;
            
            else if (distance >= 20 && distance < 100)
                price = distance * bus;
              
            else 
                price = distance * train;
                
            Console.WriteLine("{0:0.00}",price);
        }
    }
}
