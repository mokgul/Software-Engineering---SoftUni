using System;

namespace _2._2._Simple_Calculations___Exam_Problems___Money
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bitcoin = 1168;     // lv.
            double yuan = 0.15;     // usd
            double usd = 1.76;      // lv.
            double euro = 1.95;     //lv.

            int bitcoinAmount = int.Parse(Console.ReadLine());
            double yuanAmount = double.Parse(Console.ReadLine());
            double commision = double.Parse(Console.ReadLine()) / 100.00d;
            // the d after the numbers tells the code thats the number is a double

            double bitToEuro = (bitcoinAmount * bitcoin) / euro;
            double yuanToEuro = ((yuanAmount * yuan) * usd) / euro;
            double totalEuro = bitToEuro + yuanToEuro;
            totalEuro -= totalEuro * commision;
            Console.WriteLine(totalEuro);

        }
    }
}
