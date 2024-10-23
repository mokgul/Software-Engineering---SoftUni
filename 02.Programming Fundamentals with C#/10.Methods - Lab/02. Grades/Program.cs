using System;

namespace _02._Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            GradeDefinition(grade);
        }

        static void GradeDefinition(double num)
        {
            string result =
                (num >= 2.00 && num <= 2.99) ? "Fail" :
                (num >= 3.00 && num <= 3.49) ? "Poor" :
                (num >= 3.50 && num <= 4.49) ? "Good" :
                (num >= 4.50 && num <= 5.49) ? "Very good" :
                (num >= 5.50 && num <= 6.00) ? "Excellent" : "";
            Console.WriteLine(result);
        }
    }
}