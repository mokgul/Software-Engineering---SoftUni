using System;
using System.Linq;

namespace _10._LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ushort fieldSize = ushort.Parse(Console.ReadLine());
            if (fieldSize > 1000) return;
            int[] field = new int[fieldSize];
            int[] initialIndexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            //filling array field with 1s using the initialIndexes
            for (int i = 0; i < initialIndexes.Length; i++)
            {
                if (initialIndexes[i] > field.Length - 1) continue;
                if (initialIndexes[i] < 0) continue;

                field[initialIndexes[i]] = 1;
            }
            //command info
            int ladybugIndex;
            string direction = string.Empty;
            int flyLength;
            string[] commands = new string[3];

            string command = string.Empty;
            while (command != "end")
            {
                command = Console.ReadLine();
                if (command == "end") break;

                commands = command.Split(" ");
                ladybugIndex = int.Parse(commands[0]);
                direction = commands[1];
                flyLength = int.Parse(commands[2]);

                if (direction == "left")
                {
                    if (ladybugIndex < 0 || ladybugIndex > field.Length - 1) continue;
                    if (field[ladybugIndex] == 0) continue;
                    if (flyLength == 0) continue;
                    int newLadybugIndex = ladybugIndex - flyLength;
                    if (newLadybugIndex > field.Length - 1 || newLadybugIndex < 0)
                    {
                        field[ladybugIndex] = 0;
                        continue;
                    }
                    else
                    {
                        while (field[newLadybugIndex] == 1)
                        {
                            newLadybugIndex -= flyLength;
                            if (newLadybugIndex > field.Length - 1 || newLadybugIndex < 0) break;
                        }
                        if (newLadybugIndex > field.Length - 1 || newLadybugIndex < 0)
                        {
                            field[ladybugIndex] = 0;
                            continue;
                        }
                        else
                        {
                            field[newLadybugIndex] = 1;
                            field[ladybugIndex] = 0;
                        }
                    }

                }
                else if (direction == "right")
                {
                    if (ladybugIndex < 0 || ladybugIndex > field.Length - 1) continue;
                    if (field[ladybugIndex] == 0) continue;
                    if (flyLength == 0) continue;
                    int newLadybugIndex = ladybugIndex + flyLength;
                    if (newLadybugIndex > field.Length - 1 || newLadybugIndex < 0)
                    {
                        field[ladybugIndex] = 0;
                        continue;
                    }
                    else
                    {
                        while (field[newLadybugIndex] == 1)
                        {
                            newLadybugIndex += flyLength;
                            if (newLadybugIndex > field.Length - 1 || newLadybugIndex < 0) break;
                        }
                        if (newLadybugIndex > field.Length - 1 || newLadybugIndex < 0)
                        {
                            field[ladybugIndex] = 0;
                            continue;
                        }
                        else
                        {
                            field[newLadybugIndex] = 1;
                            field[ladybugIndex] = 0;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", field));
        }
    }
}