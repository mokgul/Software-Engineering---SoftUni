using System;

namespace Numbers_1_to_N_with_Step_3
{
    class NumbersWithStep3
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int i = 1; i <= num; i += 3)
            {
                Console.WriteLine(i);
            }
        }
    }
}
