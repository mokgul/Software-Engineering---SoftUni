using System;

namespace _3._1._Simple_Conditions___Bonus_Score
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            double bonus = 0;

            //simple way
            if (num <= 100)
                bonus += 5;
            else if (num <= 1000)
                bonus = 0.2 * num;
            else
                bonus = 0.1 * num;

            if (num % 2 == 0)
                bonus += 1;
            if (num % 10 == 5)
                bonus += 2;

            //smarter way
            //bonus = (num <= 100) ? bonus += 5 :
            //    (bonus <= 1000) ? 0.2 * num : 0.1 * num;
            //if (num % 2 == 0)
            //    bonus += 1;
            //if (num % 10 == 5)
            //    bonus += 2;

            Console.WriteLine(bonus);
            Console.WriteLine(num + bonus);
        }
    }
}
