using System;
using System.Linq;

namespace _01._Encrypt__Sort_and_Print_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stringsQty = int.Parse(Console.ReadLine());
            int[] encrypted = new int[stringsQty];
            string vowels = "aeiouAEIOU";

            for (int i = 0; i < stringsQty; i++)
            {
                string sequence = Console.ReadLine();
                int sumOfElements = 0;
                //taking each string and calculating its sum
                for (int j = 0; j < sequence.Length; j++)
                {
                    if (vowels.Contains(sequence[j]))
                    {
                        sumOfElements += (sequence[j] * sequence.Length);
                    }
                    else
                    {
                        sumOfElements += (sequence[j] / sequence.Length);
                    }
                }
                encrypted[i] = sumOfElements;
            }

            int temp;
            //first loop takes first element and using the second loop compares it to each next element
            // for example 1, 9, 6, 7. Takes 1 and compares it to 9, 6, 7 and etc.
            //if the condition is true, it swaps the two elements
            // for example 9 is bigger than 6 so the array will become 1, 6, 9, 7, then continues 
            // with comparing 6 and 7 and so on until its done with all iterations
            for (int i = 0; i < encrypted.Length - 1; i++)
            {
                for (int j = i + 1; j < encrypted.Length; j++)
                {
                    if (encrypted[i] > encrypted[j])
                    {
                        temp = encrypted[i];
                        encrypted[i] = encrypted[j];
                        encrypted[j] = temp;
                    }
                }
            }
            //simpler way to sort array in asc order
            //Array.Sort(encrypted);

            //printing all elements of the sorted array
            foreach (int element in encrypted)
            {
                Console.WriteLine(element);
            }
        }
    }
}