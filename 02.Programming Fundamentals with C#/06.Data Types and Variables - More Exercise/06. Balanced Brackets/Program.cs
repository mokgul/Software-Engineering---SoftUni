using System;
using System.Threading.Channels;

namespace _06._Balanced_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberLines = int.Parse(Console.ReadLine());
            int brackets = 0;
            
            for (int i = 1; i <= numberLines; i++)
            {
                string line = Console.ReadLine();

                if (line == "(")
                {
                    brackets++;
                }

                if (line == ")")
                {
                    brackets--;
                }

                if (brackets != 0 && brackets != 1 )
                {
                    Console.WriteLine("UNBALANCED");
                    return;;
                }
            }


            if (brackets == 0)
                Console.WriteLine("BALANCED");
            else
            {
                Console.WriteLine("UNBALANCED");
            }

        }
    }
}