using System;

namespace School_Camp
{
    class SchoolCamp
    {
        static void Main(string[] args)
        {
            //declaration
            //prices per night for ..= { winter, spring, summer }
            string[] boyGirls = { "9.60", "7.20", "15.00" };
            string[] mixedGroup = { "10.00", "9.50", "20.00" };
            //sports according to season ..= { winter, spring , summer }
            string[] girls = { "Gymnastics", "Athletics", "Volleyball" };
            string[] boys = { "Judo", "Tennis", "Football" };
            string[] mixed = { "Ski", "Cycling", "Swimming" };
            //discount from number of students
            double discOne = 0.50; // 50 >= students
            double discTwo = 0.15; // 20 >= students < 50
            double discThree = 0.05; // 10 >= students < 20
            double price = 0.00;
            string sportChoice = "";

            //input
            string season = Console.ReadLine();
            string groupType = Console.ReadLine();
            int studentsQty = int.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());

            //calculation
            switch (season)
            {
                case "Winter":
                    if (groupType == "boys" || groupType == "girls")
                        price = nights * studentsQty * double.Parse(boyGirls[0]);
                    else if (groupType == "mixed")
                        price = nights * studentsQty * double.Parse(mixedGroup[0]);
                    break;
                case "Spring":
                    if (groupType == "boys" || groupType == "girls")
                        price = nights * studentsQty * double.Parse(boyGirls[1]);
                    else if (groupType == "mixed")
                        price = nights * studentsQty * double.Parse(mixedGroup[1]);
                    break;
                case "Summer":
                    if (groupType == "boys" || groupType == "girls")
                        price = nights * studentsQty * double.Parse(boyGirls[2]);
                    else if (groupType == "mixed")
                        price = nights * studentsQty * double.Parse(mixedGroup[2]);
                    break;
            }
            if (studentsQty >= 50)
                price -= price * discOne;
            else if (studentsQty >= 20)
                price -= price * discTwo;
            else if (studentsQty >= 10)
                price -= price * discThree;
            switch (groupType)
            {
                case "girls":
                    if (season == "Winter")
                        sportChoice = girls[0];
                    else if (season == "Spring")
                        sportChoice = girls[1];
                    else if (season == "Summer")
                        sportChoice = girls[2];
                    break;
                case "boys":
                    if (season == "Winter")
                        sportChoice = boys[0];
                    else if (season == "Spring")
                        sportChoice = boys[1];
                    else if (season == "Summer")
                        sportChoice = boys[2]; break;
                case "mixed":
                    if (season == "Winter")
                        sportChoice = mixed[0];
                    else if (season == "Spring")
                        sportChoice = mixed[1];
                    else if (season == "Summer")
                        sportChoice = mixed[2]; break;
            }
            //output
            Console.WriteLine($"{sportChoice} {price:f2} lv.");
        }
    }
}
