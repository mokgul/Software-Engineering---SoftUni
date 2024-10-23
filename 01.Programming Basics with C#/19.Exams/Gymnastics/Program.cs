using System;

namespace Gymnastics
{
    class Program
    {
        static void Main(string[] args)
        {
            //                  Russia    Bulgaria    Italy
            string[] ribbon = { "18.500", "19.000", "18.700" };
            string[] hoop = { "19.100", "19.300", "18.800" };
            string[] rope = { "18.600", "18.900", "18.850" };
            double points = 0;

            string country = Console.ReadLine();
            string catecory = Console.ReadLine();

            switch (country)
            {
                case "Russia":
                    switch (catecory)
                    {
                        case "ribbon":
                            points = double.Parse(ribbon[0]);
                            break;
                        case "hoop":
                            points = double.Parse(hoop[0]);
                            break;
                        case "rope":
                            points = double.Parse(rope[0]);
                            break;
                    }
                    break;
                case "Bulgaria":
                    switch (catecory)
                    {
                        case "ribbon":
                            points = double.Parse(ribbon[1]);
                            break;
                        case "hoop":
                            points = double.Parse(hoop[1]);
                            break;
                        case "rope":
                            points = double.Parse(rope[1]);
                            break;
                    }
                    break;
                case "Italy":
                    switch (catecory)
                    {
                        case "ribbon":
                            points = double.Parse(ribbon[2]);
                            break;
                        case "hoop":
                            points = double.Parse(hoop[2]);
                            break;
                        case "rope":
                            points = double.Parse(rope[2]);
                            break;
                    }
                    break;
            }
            double percent = 20.00 - points;
            percent = (percent / 20) * 100;
            Console.WriteLine($"The team of {country} get {points:f3} on {catecory}.");
            Console.WriteLine($"{percent:f2}%");
        }
    }
}
