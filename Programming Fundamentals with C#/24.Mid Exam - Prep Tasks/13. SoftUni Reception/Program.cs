using System;

namespace _13._SoftUni_Reception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstWorker = int.Parse(Console.ReadLine());
            var secondWorker = int.Parse(Console.ReadLine());
            var thirdWorker = int.Parse(Console.ReadLine());
            var students = int.Parse(Console.ReadLine());
            var hours = 0;
            var totalPerHour = firstWorker + secondWorker + thirdWorker;

            while (students > 0)
            {
                hours++;
                if(hours % 4 == 0)
                {
                    continue;
                }
                students -= totalPerHour;
            }

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
