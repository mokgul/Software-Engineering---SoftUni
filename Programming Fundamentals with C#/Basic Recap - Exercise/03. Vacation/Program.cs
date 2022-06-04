using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int people_Qty    = int.Parse(Console.ReadLine());
            string group_Type = Console.ReadLine();
            string day        = Console.ReadLine();
            double price      = 0;
            double student_discount  = (group_Type == "Students" && people_Qty >= 30) ? 0.15 : 0;
            int business_people_free = (group_Type == "Business" && people_Qty >= 100) ? 10 : 0;
            double regular_discount  = (group_Type == "Regular" && (people_Qty >= 10 && people_Qty <= 20)) ? 0.05 : 0;
            switch (day)
            {
                case "Friday":
                    switch (group_Type)
                    {
                        case "Students": price = (8.45 * people_Qty) * (1 - student_discount);  break;
                        case "Business": price =  10.90 * (people_Qty - business_people_free);  break;
                        case "Regular":  price = (15.00 * people_Qty) * (1 - regular_discount); break;
                    }
                    break;
                case "Saturday":
                    switch (group_Type)
                    {
                        case "Students": price = (9.80 * people_Qty) * (1 - student_discount);  break;
                        case "Business": price =  15.60 * (people_Qty - business_people_free);  break;
                        case "Regular":  price = (20.00 * people_Qty) * (1 - regular_discount); break;
                    }
                    break;
                case "Sunday":
                    switch (group_Type)
                    {
                        case "Students": price = (10.46 * people_Qty) * (1 - student_discount); break;
                        case "Business": price =   16.00 * (people_Qty - business_people_free); break;
                        case "Regular":  price = (22.50 * people_Qty) * (1 - regular_discount); break;
                    }
                    break;
            }
            //output
            Console.WriteLine($"Total price: {price:f2}");
        }
    }
}