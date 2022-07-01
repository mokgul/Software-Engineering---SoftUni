using System;

namespace _2._2._Simple_Conditions___Exam_Problems___Training_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int workingSpacesLost = 3; // входна врата и катедра

            double length = double.Parse(Console.ReadLine()) * 100; // converting to centimeters
            double width = double.Parse(Console.ReadLine()) * 100;  // converting to centimeters

            int columns = (int)length / 120;
            int rows = ((int)width - 100) / 70; // substractin 100cm for the hallway 

            int workingSpaces = rows * columns - workingSpacesLost;
            Console.WriteLine(workingSpaces);
        }
    }
}
