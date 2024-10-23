using System;

namespace _01._Data_Types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            switch (input)
            {
                case "int":
                    int integer = int.Parse(Console.ReadLine());
                    GetDataType(integer);
                    break;
                case "real":
                    double real = double.Parse(Console.ReadLine());
                    GetDataType(real);
                    break;
                case "string":
                    string word = Console.ReadLine();
                    GetDataType(word);
                    break;
            }
        }

        private static void GetDataType(int num)
        {
            num *= 2;
            Console.WriteLine(num);
        }

        private static void GetDataType(double num)
        {
            num *= 1.5;
            Console.WriteLine("{0:0.00}", num);
        }

        private static void GetDataType(string word)
        {
            Console.WriteLine($"${word}$");
        }
    }
}