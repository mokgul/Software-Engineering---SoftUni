using System;

namespace _3._2._Simple_Conditions___Exam_Problems___Firm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hoursNeeded = int.Parse(Console.ReadLine());
            int daysAvailable = int.Parse(Console.ReadLine());
            int overtimeWorkers = int.Parse(Console.ReadLine());

            var workdays = daysAvailable * 0.90;
            var overtime = (overtimeWorkers * workdays) * 2;
            var workHours = Math.Floor(workdays * 8 * overtimeWorkers + overtime);

            if(workHours >= hoursNeeded)
                Console.WriteLine($"Yes!{workHours - hoursNeeded} hours left.");
            else 
                Console.WriteLine($"Not enough time!{hoursNeeded - workHours} hours needed.");
        }
    }
}
