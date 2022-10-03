using System;

namespace Bike_Race
{
    class BikeRace
    {
        static void Main(string[] args)
        {
            //declaration
            // taxes = {"trail","cross-country", "downhill", "road"}
            string[] juniors = { "5.50", "8.00", "12.25", "20.00" };
            string[] seniors = { "7.00", "9.50", "13.75", "21.50" };
            double juniorFees = 0.00;
            double seniorFees = 0.00;
            double costs = 0.05;
            double funds = 0.00;

            int juniorsQty = int.Parse(Console.ReadLine());
            int seniorsQty = int.Parse(Console.ReadLine());
            string traceType = Console.ReadLine();

            //calculation
            switch (traceType)
            {
                case "trail":
                    juniorFees = juniorsQty * double.Parse(juniors[0]);
                    seniorFees = seniorsQty * double.Parse(seniors[0]);
                    funds = juniorFees + seniorFees;
                    funds -= funds * costs;
                    break;
                case "cross-country":

                    if ((juniorsQty + seniorsQty) >= 50)
                    {
                        juniorFees = double.Parse(juniors[1]);
                        juniorFees *= 0.75;
                        juniorFees *= juniorsQty;
                        seniorFees = double.Parse(seniors[1]);
                        seniorFees *= 0.75;
                        seniorFees *= seniorsQty;
                        funds = juniorFees + seniorFees;
                        funds -= funds * costs;
                    }
                    else
                    {
                        juniorFees = juniorsQty * double.Parse(juniors[1]);
                        seniorFees = seniorsQty * double.Parse(seniors[1]);
                        funds = juniorFees + seniorFees;
                        funds -= funds * costs;
                    }
                    break;
                case "downhill":
                    juniorFees = juniorsQty * double.Parse(juniors[2]);
                    seniorFees = seniorsQty * double.Parse(seniors[2]);
                    funds = juniorFees + seniorFees;
                    funds -= funds * costs;
                    break;
                case "road":
                    juniorFees = juniorsQty * double.Parse(juniors[3]);
                    seniorFees = seniorsQty * double.Parse(seniors[3]);
                    funds = juniorFees + seniorFees;
                    funds -= funds * costs;
                    break;
            }
            //Output
            Console.WriteLine("{0:0.00}", funds);
        }
    }
}
