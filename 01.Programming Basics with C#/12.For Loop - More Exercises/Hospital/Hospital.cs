using System;

namespace Hospital
{
    class Hospital
    {
        static void Main(string[] args)
        {
            int treated = 0;
            int untreated = 0;
            int doctors = 7;

            int days = int.Parse(Console.ReadLine());
            for (int i = 1; i <= days; i++)
            {
                int patients = int.Parse(Console.ReadLine());
                if (i % 3 == 0)
                {
                    if (untreated > treated)
                    {
                        doctors++;
                    }
                }
                if (patients <= doctors)
                {
                    treated += patients;
                }
                else
                {
                    treated += doctors;
                    untreated += patients - doctors;
                }
            }
            Console.WriteLine($"Treated patients: {treated}.");
            Console.WriteLine($"Untreated patients: {untreated}.");
        }
    }
}
