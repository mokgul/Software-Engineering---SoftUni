using System;

namespace Car_To_Go
{
    class CarToGo
    {
        static void Main(string[] args)
        {
            //declaration
            string[] carClass = { "Economy class", "Compact class", "Luxury class" }; //..={<=100,100-<=500,>500} according budget
            string[] cabrioPrice = { "0.35", "0.45" }; // ..={<=100,100-<=500} according budget
            string[] jeepPrice = { "0.65", "0.80", "0.90" }; //..={<=100,100-<=500,>500} according budget
            string[] carType = { "Cabrio", "Jeep" };
            double price = 0.00;
            string car = "";
            string classChoice = "";

            //input
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            //calculation
            switch (season)
            {
                case "Summer":
                    if (budget <= 100)
                    {
                        classChoice = carClass[0];
                        car = carType[0];
                        price = budget * double.Parse(cabrioPrice[0]);
                    }
                    else if (budget <= 500)
                    {
                        classChoice = carClass[1];
                        car = carType[0];
                        price = budget * double.Parse(cabrioPrice[1]);
                    }
                    else if (budget > 500)
                    {
                        classChoice = carClass[2];
                        car = carType[1];
                        price = budget * double.Parse(jeepPrice[2]);
                    }
                    break;
                case "Winter":
                    if (budget <= 100)
                    {
                        classChoice = carClass[0];
                        car = carType[1];
                        price = budget * double.Parse(jeepPrice[0]);
                    }
                    else if (budget <= 500)
                    {
                        classChoice = carClass[1];
                        car = carType[1];
                        price = budget * double.Parse(jeepPrice[1]);
                    }
                    else if (budget > 500)
                    {
                        classChoice = carClass[2];
                        car = carType[1];
                        price = budget * double.Parse(jeepPrice[2]);
                    }
                    break;
            }

            //output
            Console.WriteLine(classChoice);
            Console.WriteLine(car + " - " + "{0:0.00}", price);
        }
    }
}
