using System;
using System.Collections.Generic;
using System.Text;

namespace _06._Replace_Repeating_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            StringBuilder result = new StringBuilder();

            while(input.Length > 0)
            {
                int count = 1;
                int index = 0;
                while (true)
                {
                    if (index >= input.Length - 1) break;
                    if (input[index] == input[index + 1])
                    {
                        count++;
                        index++;
                    }
                    else
                    {
                        index = 0;
                        break;
                    }
                }

                result.Append(input[0]);
                input = input.Remove(0, count);
            }
            Console.WriteLine(result.ToString());
        }
    }
}
