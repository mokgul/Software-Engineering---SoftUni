using System;

namespace _05._Multiplication_Sign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            string product = CheckProduct(num1, num2, num3);
            Console.WriteLine(product);
        }

        private static string CheckProduct(int x, int y, int z)
        {
            string result = String.Empty;
            if (x == 0 || y == 0 || z == 0)
            {
                result = "zero";
                return result;
            }
            else if (x < 0 || y < 0 || z < 0)
            {
                if (x < 0 && y < 0 && z < 0)
                {
                    result = "negative";
                }

                else if ((x < 0 && y < 0) || (x < 0 && z < 0) || (y < 0 && z < 0))
                {
                    result = "positive";
                }

                else
                {
                    result = "negative";
                }
                return result;
            }
            else
            {
                result = "positive";
                return result;
            }
        }
    }
}