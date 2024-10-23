using System;

namespace _04._Refactor_Prime_Checker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            for (int num = 2; num <= range; num++)
            {
                bool isPrime = true;
                for (int divider = 2; divider < num; divider++)
                {
                    if (num % divider == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                    Console.WriteLine($"{num} -> true ");
                else
                {
                    Console.WriteLine($"{num} -> false ");
                }
            }

        }
    }
}