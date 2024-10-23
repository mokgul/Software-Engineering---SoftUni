using System;

namespace Grades
{
    class Grades
    {
        static void Main(string[] args)
        {
            int topStudents = 0;
            int gradeFours = 0;
            int gradeThrees = 0;
            int fails = 0;
            double averageGrade = 0;
            double gradeSum = 0;
            double percTop = 0, perc4s = 0, perc3s = 0, percFails = 0;

            int students = int.Parse(Console.ReadLine());
            for (int i = 1; i <= students; i++)
            {
                double grades = double.Parse(Console.ReadLine());
                gradeSum += grades;
                if (grades > 4.99) topStudents++;
                else if (grades > 3.99) gradeFours++;
                else if (grades > 2.99) gradeThrees++;
                else
                    fails++;
            }
            averageGrade = gradeSum / students;
            percTop = ((double)topStudents / students) * 100;
            perc4s = ((double)gradeFours / students) * 100;
            perc3s = ((double)gradeThrees / students) * 100;
            percFails = ((double)fails / students) * 100;

            Console.WriteLine($"Top students: {percTop:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {perc4s:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {perc3s:f2}%");
            Console.WriteLine($"Fail: {percFails:f2}%");
            Console.WriteLine($"Average: {averageGrade:f2}");
        }
    }
}
