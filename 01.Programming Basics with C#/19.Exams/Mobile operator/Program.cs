using System;

namespace Mobile_operator
{
    class Program
    {
        static void Main(string[] args)
        {
            //               Small    Middle   Large   ExtraLarge
            string[] one = { "9.98", "18.99", "25.98", "35.99" };
            string[] two = { "8.58", "17.09", "23.59", "31.79" };
            double tax = 0;

            string term = Console.ReadLine();
            string type = Console.ReadLine();
            string net = Console.ReadLine();
            int months = int.Parse(Console.ReadLine());

            switch (type)
            {
                case "Small":
                    if (term == "one")
                        tax = double.Parse(one[0]);
                    else
                        tax = double.Parse(two[0]);
                    break;
                case "Middle":
                    if (term == "one")
                        tax = double.Parse(one[1]);
                    else
                        tax = double.Parse(two[1]);
                    break;
                case "Large":
                    if (term == "one")
                        tax = double.Parse(one[2]);
                    else
                        tax = double.Parse(two[2]);
                    break;
                case "ExtraLarge":
                    if (term == "one")
                        tax = double.Parse(one[3]);
                    else
                        tax = double.Parse(two[3]);
                    break;
            }
            if (net == "yes")
            {
                if (tax <= 10) tax += 5.50;
                else if (tax <= 30) tax += 4.35;
                else if (tax > 30) tax += 3.85;
            }
            tax *= months;
            if (term == "two") tax *= 0.9625;

            Console.WriteLine($"{tax:f2} lv.");
        }
    }
}
