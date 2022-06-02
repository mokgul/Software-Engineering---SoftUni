using System;

namespace Sum_Numbers
{
    class SumNumbers
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int num = int.Parse(Console.ReadLine());

            while (sum < num)
            {
                int input = int.Parse(Console.ReadLine());
                sum += input;
            }
            Console.WriteLine(sum);
        }
    }
}
