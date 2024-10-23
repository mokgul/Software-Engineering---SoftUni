using System;

namespace Unique_PIN_Codes
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumRange = int.Parse(Console.ReadLine());
            int secondNumRange = int.Parse(Console.ReadLine());
            int thirdNumRange = int.Parse(Console.ReadLine());

            bool first = false;
            bool second = false;
            bool third = false;

            for (int firstNum = 1; firstNum <= firstNumRange; firstNum++)
            {
                for (int secondNum = 2; secondNum <= secondNumRange; secondNum++)
                {
                    for (int thirdNum = 1; thirdNum <= thirdNumRange; thirdNum++)
                    {
                        if (firstNum % 2 == 0)
                            first = true;
                        else continue;

                        if (secondNum == 2 || secondNum == 3 || secondNum == 5 || secondNum == 7)
                            second = true;
                        else continue;

                        if (thirdNum % 2 == 0)
                            third = true;
                        else continue;

                        if (first && second && third)
                        {
                            Console.Write(firstNum + " ");
                            Console.Write(secondNum + " ");
                            Console.Write(thirdNum);
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}
