using System;

namespace Max_Number
{
    class MaxNumber
    {
        static void Main(string[] args)
        {
            string input = "";
            int min = int.MaxValue;
            int num = 0;
            while (input != "Stop")
            {
                input = Console.ReadLine();
                if (input == "Stop") break;
                num = int.Parse(input);
                if (num < min) min = num;
            }
            Console.WriteLine(min);
        }
    }
}
