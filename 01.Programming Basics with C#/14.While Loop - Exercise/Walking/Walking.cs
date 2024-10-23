using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T04.Walking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string steps = Console.ReadLine();
            int goal = 0;

            do
            {
                goal += int.Parse(steps);
                if (goal >= 10000)
                {
                    break;
                }
                steps = Console.ReadLine();
            } while (steps != "Going home");

            if (steps == "Going home")
            {
                int walking = int.Parse(Console.ReadLine());
                goal += walking;
            }

            int difference = 10000 - goal;

            if (difference <= 0)
            {
                Console.WriteLine($"Goal reached! Good job!");
                Console.WriteLine($"{Math.Abs(difference)} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{difference} more steps to reach goal.");
            }
        }
    }
}
