using System;

namespace _3._2._Simple_Conditions___Exam_Problems___Pipes_In_Pool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int volume = int.Parse(Console.ReadLine());
            int firstPipeDebit = int.Parse(Console.ReadLine());
            int secondPipeDebit = int.Parse(Console.ReadLine());
            double hours = double.Parse(Console.ReadLine());

            //liters filled
            double firstPipeTotal = hours * firstPipeDebit;
            double secondPipeTotal = hours * secondPipeDebit;
            double total = firstPipeTotal + secondPipeTotal;

            //percentages
            double firstPipePercent = firstPipeTotal / total * 100;
            double secondPipePercent = secondPipeTotal / total * 100;
            double totalPercent = total / volume * 100;

            if (total <= volume)
            {
                Console.WriteLine($"The pool is {(int)totalPercent}% full. Pipe 1: {(int)firstPipePercent}%. Pipe 2: {(int)secondPipePercent}%.");
            }
            else
            {
                Console.WriteLine($"For {hours} hours the pool overflows with {total - volume} liters.");
            }
        }
    }
}
