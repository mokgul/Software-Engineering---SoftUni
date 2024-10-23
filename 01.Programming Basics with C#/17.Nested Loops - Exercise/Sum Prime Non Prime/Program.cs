using System;

namespace Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            int num = 0;
            int factorCount = 0;
            int primeSum = 0;
            int nonPrimeSum = 0;

            while (input != "stop")
            {
                input = Console.ReadLine();
                if (input == "stop") break;

                num = int.Parse(input);
                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }

                for (int i = 1; i <= num; i++)
                {
                    if (num % i == 0)
                    {
                        factorCount++;
                    }
                }
                if (factorCount == 2)
                    primeSum += num;
                else
                    nonPrimeSum += num;
                factorCount = 0;
            }
            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
        }
    }
}
