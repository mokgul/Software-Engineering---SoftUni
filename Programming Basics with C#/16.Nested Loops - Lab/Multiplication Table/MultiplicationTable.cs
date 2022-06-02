using System;

namespace Multiplication_Table
{
    class MultiplicationTable
    {
        static void Main(string[] args)
        {
            int result = 0;
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    result = i * j;
                    Console.WriteLine($"{i} * {j} = {result}");
                }
            }
        }
    }
}
