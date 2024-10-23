using System;

namespace _4._1._Complex_Conditions___Trade_Comissions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] Sofia = { "0.05", "0.07", "0.08", "0.12" }; //commissions from sales 0-500,500-1000,1k-10k,10k+,%
            string[] Varna = { "0.045", "0.075", "0.10", "0.13" }; // commissions for .., .., ... , %
            string[] Plovdiv = { "0.055", "0.08", "0.12", "0.145" }; //commissions for ..,.., ... , %  

            var city = Console.ReadLine().ToLower();
            decimal sales = decimal.Parse(Console.ReadLine());
            decimal commission = 0;

            switch(sales)
            {
                case decimal n when (sales > 0 && sales <= 500): 
                    switch(city)
                    {
                        case "sofia":   commission = sales * (decimal.Parse(Sofia[0]));     break;
                        case "varna":   commission = sales * (decimal.Parse(Varna[0]));     break;
                        case "plovdiv": commission = sales * (decimal.Parse(Plovdiv[0]));     break;
                        default:Console.WriteLine("error"); break;
                    }
                    break;
                case decimal n when (sales > 500 && sales <= 1000):
                    switch (city)
                    {
                        case "sofia": commission = sales * (decimal.Parse(Sofia[1])); break;
                        case "varna": commission = sales * (decimal.Parse(Varna[1])); break;
                        case "plovdiv": commission = sales * (decimal.Parse(Plovdiv[1])); break;
                        default: Console.WriteLine("error"); break;
                    }
                    break;
                case decimal n when (sales > 1000 && sales <= 10000):
                    switch (city)
                    {
                        case "sofia": commission = sales * (decimal.Parse(Sofia[2])); break;
                        case "varna": commission = sales * (decimal.Parse(Varna[2])); break;
                        case "plovdiv": commission = sales * (decimal.Parse(Plovdiv[2])); break;
                        default: Console.WriteLine("error"); break;
                    }
                    break;
                case decimal n when (sales > 10000):
                    switch (city)
                    {
                        case "sofia": commission = sales * (decimal.Parse(Sofia[3])); break;
                        case "varna": commission = sales * (decimal.Parse(Varna[3])); break;
                        case "plovdiv": commission = sales * (decimal.Parse(Plovdiv[3])); break;
                        default: Console.WriteLine("error"); break;
                    }
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
            if (commission != 0)
            Console.WriteLine($"{commission:f2}");
        }
    }
}
