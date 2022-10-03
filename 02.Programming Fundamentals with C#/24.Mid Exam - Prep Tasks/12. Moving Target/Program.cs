using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Moving_Target
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var targets = Console.ReadLine().Split().Select(int.Parse).ToList();

            var input = Console.ReadLine();
            while (input != "End")
            {
                var commands = input.Split();
                var command = commands[0];

                switch (command)
                {
                    case "Shoot":
                        Shoot(commands, targets);
                        break;
                    case "Add":
                        Add(commands, targets);
                        break;
                    case "Strike":
                        Strike(commands, targets);
                        break;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join("|", targets));
        }

        private static void Strike(string[] commands, List<int> targets)
        {
            var index = int.Parse(commands[1]);
            var radius = int.Parse(commands[2]);
            var start = index - radius;
            var end = index + radius;
            var count = 2 * radius + 1;
            if (!IndexIsValid(start, targets) 
                || !IndexIsValid(end, targets) 
                || radius < 0
                || index < 0
                || index >= targets.Count)
            {
                Console.WriteLine("Strike missed!");
                return;
            }

            targets.RemoveRange(start, count);
        }

        private static void Add(string[] commands, List<int> targets)
        {
            var index = int.Parse(commands[1]);
            var value = int.Parse(commands[2]);
            if (!IndexIsValid(index, targets))
            {
                Console.WriteLine("Invalid placement!");
                return;
            }
            targets.Insert(index, value);
        }

        private static void Shoot(string[] commands, List<int> targets)
        {
            var index = int.Parse(commands[1]);
            var power = int.Parse(commands[2]);
            if (!IndexIsValid(index, targets)) return;
            targets[index] = targets[index] - power <= 0 ? 0 : targets[index] -= power;
            if (targets[index] == 0)
                targets.RemoveAt(index);
        }

        private static bool IndexIsValid(int index, List<int> targets)
            => index >= 0 && index < targets.Count ? true : false;

    }
}
