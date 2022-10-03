using System;
using System.Drawing;

namespace _2._1._Simple_Calculations___Currency_Converter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //simpler way
            var lev = 1;
            var dollar = 1.79549;
            var euro = 1.95583;
            var pound = 2.53405;

            double money = double.Parse(Console.ReadLine());
            string fromCurrency = Console.ReadLine();
            string toCurrency = Console.ReadLine();

            if (fromCurrency == "BGN" && toCurrency == "USD") Console.WriteLine(Math.Round((money * lev / dollar), 2));
            if (fromCurrency == "BGN" && toCurrency == "EUR") Console.WriteLine(Math.Round((money * lev / euro), 2));
            if (fromCurrency == "BGN" && toCurrency == "GBP") Console.WriteLine(Math.Round((money * lev / pound), 2));

            if (fromCurrency == "USD" && toCurrency == "BGN") Console.WriteLine(Math.Round((money * dollar / lev), 2));
            if (fromCurrency == "USD" && toCurrency == "EUR") Console.WriteLine(Math.Round((money * dollar / euro), 2));
            if (fromCurrency == "USD" && toCurrency == "GBP") Console.WriteLine(Math.Round((money * dollar / pound), 2));

            if (fromCurrency == "EUR" && toCurrency == "BGN") Console.WriteLine(Math.Round((money * euro / lev), 2));
            if (fromCurrency == "EUR" && toCurrency == "USD") Console.WriteLine(Math.Round((money * euro / dollar), 2));
            if (fromCurrency == "EUR" && toCurrency == "GBP") Console.WriteLine(Math.Round((money * euro / pound), 2));

            if (fromCurrency == "GBP" && toCurrency == "BGN") Console.WriteLine(Math.Round((money * pound / lev), 2));
            if (fromCurrency == "GBP" && toCurrency == "USD") Console.WriteLine(Math.Round((money * pound / dollar), 2));
            if (fromCurrency == "GBP" && toCurrency == "EUR") Console.WriteLine(Math.Round((money * pound / euro), 2));

            //Smarter way

            //string BGN = "1";
            //string USD = "1.79549";
            //string EUR = "1.95583";
            //string GBP = "2.53405";

            //fromCurrency = (fromCurrency == "BGN") ? BGN :
            //    (fromCurrency == "USD") ? USD :
            //    (fromCurrency == "EUR") ? EUR :
            //    GBP;

            //toCurrency = (toCurrency == "BGN") ? BGN :
            //    (toCurrency == "USD") ? USD :
            //    (toCurrency == "EUR") ? EUR :
            //    GBP;

            //double result = money * (double.Parse(fromCurrency) / double.Parse(toCurrency));
            //Console.WriteLine("{0:0.00}", result);
        }
    }
}
