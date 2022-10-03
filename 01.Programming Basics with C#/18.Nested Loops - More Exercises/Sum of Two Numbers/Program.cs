using System;

namespace Sum_of_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            bool found = false;
            int combination = 0;
            int numStart = int.Parse(Console.ReadLine());
            int numEnd = int.Parse(Console.ReadLine());
            int numMagic = int.Parse(Console.ReadLine());

            for (int numOne = numStart; numOne <= numEnd; numOne++)
            {
                for (int numTwo = numStart; numTwo <= numEnd; numTwo++)
                {
                    combination++;
                    if (numOne + numTwo == numMagic)
                    {
                        found = true;
                        Console.WriteLine($"Combination N:{combination} ({numOne} + {numTwo} = {numMagic})");
                        break;
                    }
                }
                if (found) break;
            }
            if (!found)
            {
                Console.WriteLine($"{combination} combinations - neither equals {numMagic}");
            }
        }
    }
}
