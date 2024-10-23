using System;

namespace Prime_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstStart = int.Parse(Console.ReadLine());
            int secondStart = int.Parse(Console.ReadLine());
            int firstDiff = int.Parse(Console.ReadLine());
            int secondDiff = int.Parse(Console.ReadLine());

            int firstEnd = firstStart + firstDiff;
            int secondEnd = secondStart + secondDiff;
            int factorCount = 0;
            int secondFactorCount = 0;
            for (int numOne = firstStart; numOne <= firstEnd; numOne++)
            {
                for (int numTwo = secondStart; numTwo <= secondEnd; numTwo++)
                {
                    for (int i = 1; i <= numOne; i++)
                    {
                        if (numOne % i == 0)
                        {
                            factorCount++;
                        }
                        if (factorCount > 2)
                        {
                            break;
                        }
                    }
                    for (int j = 1; j <= numTwo; j++)
                    {
                        if (numTwo % j == 0)
                        {
                            secondFactorCount++;
                        }
                        if (secondFactorCount > 2)
                        {
                            break;
                        }
                    }
                    if (factorCount == 2 && secondFactorCount == 2)
                    {
                        Console.WriteLine($"{numOne}{numTwo}");
                    }
                    factorCount = 0;
                    secondFactorCount = 0;
                }
            }
        }
    }
}