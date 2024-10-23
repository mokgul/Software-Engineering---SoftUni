using System;

namespace Half_Sum_Element
{
    class HalfSumElement
    {
        static void Main(string[] args)
        {

            int biggest = int.MinValue;
            int sum = 0;
            int diff = 0;
            bool check = false;

            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                numbers[i] = num;
                sum += num;
                if (num > biggest)
                    biggest = num;
            }
            for (int i = 0; i < n; i++)
            {
                if (numbers[i] == (sum - numbers[i]))
                {
                    check = true;
                    Console.WriteLine("Yes");
                    Console.WriteLine("Sum = " + (sum - numbers[i]));
                }
            }
            if (!check)
            {
                diff = (Math.Abs(biggest - (sum - biggest)));
                Console.WriteLine("No");
                Console.WriteLine("Diff = " + diff);
            }
            //Console.WriteLine(String.Join(" ",numbers)) ;

        }
    }
}

