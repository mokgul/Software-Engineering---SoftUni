using System;

namespace Strong_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int factorial     = 1;
            int factorial_sum = 0;

            string integer = Console.ReadLine();

            for(int i = 0; i < integer.Length; i++)
            {
                int current_num = int.Parse(integer[i].ToString());
                factorial = 1;

                for(int j = current_num; j > 0; j--)
                {
                    factorial *= j;
                }
                factorial_sum += factorial;
            }

            bool IsStrong = (factorial_sum == int.Parse(integer)) ? true : false;
            if (IsStrong)
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");
        }
    }
}