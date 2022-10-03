using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Take_Skip_Rope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<char> numbers = input.Where(x => Char.IsNumber(x)).ToList();
            List<char> nonNumbers = input.Where(x => !Char.IsNumber(x)).ToList();
            List<int> take = new List<int>();
            List<int> skip = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0) take.Add(int.Parse(numbers[i].ToString()));
                else if (i % 2 == 1) skip.Add(int.Parse(numbers[i].ToString()));
            }

            string message = string.Empty;
            int skipIndex = -1; // index to take values from skip
            int takeIndex = 0;  // index to take values from take
            for (int i = 0; i < nonNumbers.Count; i += skip[skipIndex]) //we iterate with the values from skip, skipping indexes from nonNumbers directly
            {
                int takeCount = take[takeIndex]; // count of values(from take) of how much chars we need to add to the message
                while (takeCount > 0 && i < nonNumbers.Count) // while there are values to be taken and we are still in the range of the list
                {
                    message += nonNumbers[i];
                    takeCount--; // decreasing the count after a value is taken
                    i++; // increasing i to keep moving forward in the nonNumbers List
                }
                takeIndex++; // after we are done adding values to the message
                skipIndex++; // we are increasing the values of the two indeces, so we can take the next values from take/skip
                if (skipIndex == skip.Count || takeIndex == take.Count) break; // ending the loop after we take the last value from skip, so we dont get an error
            }

            Console.WriteLine(message);
        }
    }
}
