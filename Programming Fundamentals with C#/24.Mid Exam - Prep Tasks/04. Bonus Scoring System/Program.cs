using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Bonus_Scoring_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());
            
            double max = 0;
            int maxAttendances = 0;
            if (studentsCount <= 0 || lecturesCount <= 0)
            {
                Console.WriteLine($"Max Bonus: 0.");
                Console.WriteLine($"The student has attended 0 lectures.");
                return;
            }

            for (int i = 0; i < studentsCount; i++)
            {
                int studentAttendances = int.Parse(Console.ReadLine());
                if(studentAttendances == 0) 
                    continue;
                
                double currentBonus = (studentAttendances / (double)lecturesCount) * (5 + additionalBonus);
                if (currentBonus > max)
                {
                    max = currentBonus;
                    maxAttendances = studentAttendances;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(max)}.");
            Console.WriteLine($"The student has attended {maxAttendances} lectures.");
        }
    }
}