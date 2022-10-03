using System;

namespace Vowels_Sum
{
    class VowelsSum
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int vowelSum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case 'a': vowelSum += 1; break;
                    case 'e': vowelSum += 2; break;
                    case 'i': vowelSum += 3; break;
                    case 'o': vowelSum += 4; break;
                    case 'u': vowelSum += 5; break;
                }
            }
            Console.WriteLine(vowelSum);
        }
    }
}
