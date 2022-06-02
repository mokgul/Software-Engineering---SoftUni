using System;

namespace Exam_Preparation
{
    class ExamPreparation
    {
        static void Main(string[] args)
        {
            int failsAllowed = 0;
            int fails = 0;
            int problemsCount = 0;
            double averageGrade = 0;
            double grade = 0;
            string input = "";
            string lastProblem = "";

            failsAllowed = int.Parse(Console.ReadLine());

            while (input != "Enough")
            {
                if (fails == failsAllowed)
                {
                    Console.WriteLine($"You need a break, {fails} poor grades.");
                    break;
                }
                lastProblem = input;
                input = Console.ReadLine();
                if (input == "Enough")
                    break;
                grade = double.Parse(Console.ReadLine());
                if (grade <= 4.00) fails++;
                problemsCount++;
                averageGrade += grade;
            }
            averageGrade /= problemsCount;
            if (input == "Enough")
            {
                Console.WriteLine($"Average score: {averageGrade:f2}");
                Console.WriteLine($"Number of problems: {problemsCount}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
        }
    }
}
