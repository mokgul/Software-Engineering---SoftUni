using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02._Rally_Racing
{
    internal class Race
    {
        private static int size;
        private static string racingNumber;
        private static char[,] stage;
        private static int carRow = 0;
        private static int carCol = 0;
        private static int distance = 0;
        private static bool finished = false;

        static void Main(string[] args)
        {
            Input();
            CarRace();
            PrintResult();
        }

        private static void PrintResult()
        {
            if (Race.finished)
                Console.WriteLine($"Racing car {Race.racingNumber} finished the stage!");
            if(!Race.finished)
                Console.WriteLine($"Racing car {Race.racingNumber} DNF.");
            Console.WriteLine($"Distance covered {Race.distance} km.");
            Race.stage[Race.carRow, Race.carCol] = 'C';

            for (int i = 0; i < Race.size; i++)
            {
                for (int j = 0; j < Race.size; j++)
                {
                    Console.Write(Race.stage[i,j]);
                }

                Console.WriteLine();
            }
        }

        private static void CarRace()
        {
            string direction = Console.ReadLine();
            while (direction != "End")
            {
                switch (direction)
                {
                    case "left": Move(0, -1); break;
                    case "right": Move(0, 1); break;
                    case "up": Move(-1, 0); break;
                    case "down": Move(1, 0); break;
                }

                if (Race.finished) break;
                direction = Console.ReadLine();
            }
        }

        private static void Move(int row, int col)
        {
            if (ValidIndex(Race.carRow + row, Race.carCol + col))
            {
                int nextRow = Race.carRow + row;
                int nextCol = Race.carCol + col;


                if (Race.stage[nextRow, nextCol] == '.')
                {
                    Race.carRow += row;
                    Race.carCol += col;
                    Race.distance += 10;
                }
                if (Race.stage[nextRow, nextCol] == 'T')
                {
                    Race.stage[nextRow, nextCol] = '.';
                    Queue<int> position = FindEndOfTunnel(nextRow, nextCol);
                    Race.carRow = position.Dequeue();
                    Race.carCol = position.Dequeue();
                    Race.stage[Race.carRow, Race.carCol] = '.';
                    Race.distance += 30;
                }

                if (Race.stage[nextRow, nextCol] == 'F')
                {
                    Race.carRow += row;
                    Race.carCol += col;
                    Race.distance += 10;
                    Race.finished = true;
                }
            }
        }

        private static Queue<int> FindEndOfTunnel(int nextRow, int nextCol)
        {
            Queue<int> position = new Queue<int>();
            bool found = false;
            for (int i = nextRow; i < Race.size; i++)
            {
                for (int j = nextCol; j < Race.size; j++)
                {
                    if (Race.stage[i, j] == 'T')
                    {
                        position.Enqueue(i);
                        position.Enqueue(j);
                        found = true;
                    }
                    if(found) break;
                }

                nextCol = 0;
                if(found) break;
            }
            return position;

        }
        private static void Input()
        {
            Race.size = int.Parse(Console.ReadLine());
            Race.stage = new char[Race.size, Race.size];
            Race.racingNumber = Console.ReadLine();
            for (int i = 0; i < Race.size; i++)
            {
                char[] column = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < column.Length; j++)
                {
                    Race.stage[i, j] = column[j];
                }
            }
        }

        private static bool ValidIndex(int row, int col)
            => row >= 0 && row < Race.size && col >= 0 && col < Race.size;
    }
}
