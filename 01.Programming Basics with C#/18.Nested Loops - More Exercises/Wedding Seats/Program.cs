using System;

namespace Wedding_Seats
{
    class Program
    {
        static void Main(string[] args)
        {
            char sectorRange = char.Parse(Console.ReadLine());
            int firstSectorRows = int.Parse(Console.ReadLine());
            int seatsPerOddRow = int.Parse(Console.ReadLine());

            int seatsPerEvenRow = seatsPerOddRow + 2;
            int rows = firstSectorRows;
            int totalSeats = 0;

            for (char sector = 'A'; sector <= sectorRange; sector++)
            {
                for (int row = 1; row <= rows; row++)
                {
                    if (row % 2 != 0)
                    {
                        int oddSeatsTaken = seatsPerOddRow;
                        char seat = 'a';
                        while (oddSeatsTaken > 0)
                        {
                            Console.WriteLine($"{sector}{row}{seat}");
                            seat++;
                            totalSeats++;
                            oddSeatsTaken--;
                        }
                    }
                    else if (row % 2 == 0)
                    {
                        int evenSeatsTaken = seatsPerEvenRow;
                        char seat = 'a';
                        while (evenSeatsTaken > 0)
                        {
                            Console.WriteLine($"{sector}{row}{seat}");
                            seat++;
                            totalSeats++;
                            evenSeatsTaken--;
                        }
                    }
                }
                rows++;
            }
            Console.WriteLine(totalSeats);
        }
    }
}
