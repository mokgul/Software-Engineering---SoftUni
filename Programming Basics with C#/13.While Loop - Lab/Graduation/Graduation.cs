using System;

namespace Graduation
{
    class Graduation
    {
        static void Main(string[] args)
        {
            string name = "";
            double grade = 0;
            int classYear = 0;
            int fail = 0;
            double average = 0;

            name = Console.ReadLine();
            while (classYear < 12)
            {
                grade = double.Parse(Console.ReadLine());
                average += grade;
                if (grade < 4.00) fail++;
                if (fail > 1)
                {
                    Console.WriteLine($"{name} has been excluded at {classYear} grade");
                    break;
                }
                classYear++;
            }
            average /= classYear;
            if (fail < 2)
                Console.WriteLine($"{name} graduated. Average grade: {average:f2}");
        }
    }
}
