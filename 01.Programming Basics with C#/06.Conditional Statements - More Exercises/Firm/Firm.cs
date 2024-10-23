using System;

namespace Firm
{
    class Firm
    {
        static void Main(string[] args)
        {
            int workhours = 8;
            int overtime = 2;
            double workersStudyDays = 0.10;

            int projectHours    = int.Parse(Console.ReadLine());
            int workdays        = int.Parse(Console.ReadLine());
            int overtimeWorkers = int.Parse(Console.ReadLine());

            double daysForProject = workdays - (workdays * workersStudyDays);
            int overtimeHours     = (overtimeWorkers * overtime) * workdays;
            double totalProjectHours = Math.Floor((daysForProject * workhours) + overtimeHours);

            if (projectHours <= totalProjectHours)
            {
                Console.WriteLine($"Yes!{totalProjectHours - projectHours} hours left.");
            }
            else
            {
                Console.WriteLine($"Not enough time!{projectHours - totalProjectHours} hours needed.");
            }
        }
    }
}
