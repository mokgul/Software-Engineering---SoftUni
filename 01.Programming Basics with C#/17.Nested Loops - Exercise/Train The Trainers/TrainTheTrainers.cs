using System;

namespace Train_The_Trainers
{
    class TrainTheTrainers
    {
        static void Main(string[] args)
        {
            string input = "";
            double grade = 0;
            double average = 0;
            double averageGrade = 0;
            int taskCount = 0;

            int juryQty = int.Parse(Console.ReadLine());

            while (input != "Finish")
            {
                input = Console.ReadLine();
                if (input == "Finish") break;

                taskCount++;
                for (int i = 1; i <= juryQty; i++)
                {
                    grade = double.Parse(Console.ReadLine());
                    average += grade;
                }
                average /= juryQty;
                averageGrade += average;
                Console.WriteLine($"{input} - {average:f2}.");
                average = 0;
            }
            if (input == "Finish")
            {
                averageGrade /= taskCount;
                Console.WriteLine($"Student's final assessment is {averageGrade:f2}.");
            }
        }
    }
}
