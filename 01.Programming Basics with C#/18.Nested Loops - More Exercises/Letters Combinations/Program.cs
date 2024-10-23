using System;

namespace Letters_Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            char startingCharacter = char.Parse(Console.ReadLine());
            char endingCharacter = char.Parse(Console.ReadLine());
            char excludedCharacter = char.Parse(Console.ReadLine());
            int count = 0;

            for (char firstLetter = startingCharacter; firstLetter <= endingCharacter; firstLetter++)
            {
                for (char secondLetter = startingCharacter; secondLetter <= endingCharacter; secondLetter++)
                {
                    for (char thirdLetter = startingCharacter; thirdLetter <= endingCharacter; thirdLetter++)
                    {
                        if (firstLetter != excludedCharacter && secondLetter != excludedCharacter && thirdLetter != excludedCharacter)
                        {
                            Console.Write($"{firstLetter}{secondLetter}{thirdLetter} ");
                            count++;
                        }
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
