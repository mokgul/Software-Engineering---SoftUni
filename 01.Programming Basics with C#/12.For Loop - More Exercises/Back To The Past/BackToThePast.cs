using System;

namespace Back_To_The_Past
{
    class BackToThePast
    {
        static void Main(string[] args)
        {
            int age = 18;
            double money = double.Parse(Console.ReadLine());
            int yearDeath = int.Parse(Console.ReadLine());

           for (int i = 1800; i <= yearDeath; i++)
            {
                age = 18 + (i - 1800);
                if (i % 2 == 0)
                {
                    money -= 12000;
                }
                else
                {
                    money -= (12000 + 50 * age);
                }
            }
            if (money >= 0)
                Console.WriteLine($"Yes! He will live a carefree life and will have {money:f2} dollars left.");
            else
                Console.WriteLine($"He will need {Math.Abs(money):f2} dollars to survive.");
        }
    }
}
