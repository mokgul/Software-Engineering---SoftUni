using System;

namespace Car_Number
{
    class CarNumber
    {
        static void Main(string[] args)
        {
            int startingNum = int.Parse(Console.ReadLine());
            int endingNum = int.Parse(Console.ReadLine());

            for (int firstDigit = startingNum; firstDigit <= endingNum; firstDigit++)
            {
                for (int secondDiggit = startingNum; secondDiggit <= endingNum; secondDiggit++)
                {
                    for (int thirdDiggit = startingNum; thirdDiggit <= endingNum; thirdDiggit++)
                    {
                        for (int forthDigit = startingNum; forthDigit <= endingNum; forthDigit++)
                        {
                            if (firstDigit > forthDigit)
                            {
                                if (firstDigit % 2 == 0)
                                {
                                    if (forthDigit % 2 != 0)
                                    {
                                        if ((firstDigit - forthDigit) % 2 != 0 && (secondDiggit + thirdDiggit) % 2 == 0)
                                        {
                                            Console.Write($"{firstDigit}{secondDiggit}{thirdDiggit}{forthDigit} ");
                                        }
                                    }
                                }
                                else
                                {
                                    if (forthDigit % 2 == 0)
                                    {
                                        if (firstDigit % 2 != 0)
                                        {
                                            if ((firstDigit - forthDigit) % 2 != 0 && (secondDiggit + thirdDiggit) % 2 == 0)
                                            {
                                                Console.Write($"{firstDigit}{secondDiggit}{thirdDiggit}{forthDigit} ");
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }
    }
}
