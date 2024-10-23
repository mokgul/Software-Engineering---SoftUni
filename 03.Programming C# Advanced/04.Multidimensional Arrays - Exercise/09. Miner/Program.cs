using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _09._Miner
{
    internal class Miner
    {
        private static int _size;
        private static int _coals = 0;
        private static char[,] _board;
        private static Queue<string> _commands;
        private static bool EndGame = false;
        static void Main(string[] args)
        {
            Input();
            FindStart();
        }

        private static void FindStart()
        {
            string currentPosition = String.Empty;
            
            for (int i = 0; i < Miner._size; i++)
            {
                for (int j = 0; j < Miner._size; j++)
                {
                    if (Miner._board[i, j] == 's')
                        currentPosition = Movement(i, j);
                    if (Miner.EndGame)
                    {
                        Console.WriteLine($"Game over! ({currentPosition[0]}, {currentPosition[1]})");
                        return;
                    }

                    if (Miner._coals == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({currentPosition[0]}, {currentPosition[1]})");
                        return;
                    }

                    if (Miner._commands.Count == 0 && Miner.EndGame == false && Miner._coals > 0)
                    {
                        Console.WriteLine($"{Miner._coals} coals left. ({currentPosition[0]}, {currentPosition[1]})");
                        return;
                    }
                }
            }
        }

        private static string Movement(int i, int j)
        {
            int currentPositionRow = i;
            int currentPositionCol = j;
            while (Miner._commands.Count > 0)
            {
                string nextCommand = Miner._commands.Dequeue();
                switch (nextCommand)
                {
                    case "left":
                        if (ValidIndex(currentPositionRow, currentPositionCol - 1))
                        {
                            CheckSymbol(currentPositionRow, currentPositionCol - 1);
                            currentPositionCol = currentPositionCol - 1;
                        }
                        break;
                    case "right":
                        if (ValidIndex(currentPositionRow, currentPositionCol + 1))
                        {
                            CheckSymbol(currentPositionRow, currentPositionCol + 1);
                            currentPositionCol = currentPositionCol + 1;
                        }
                        break;
                    case "up":
                        if (ValidIndex(currentPositionRow - 1, currentPositionCol))
                        {
                            CheckSymbol(currentPositionRow - 1, currentPositionCol);
                            currentPositionRow = currentPositionRow - 1;
                        }
                        break;
                    case "down":
                        if (ValidIndex(currentPositionRow + 1, currentPositionCol))
                        {
                            CheckSymbol(currentPositionRow + 1, currentPositionCol);
                            currentPositionRow = currentPositionRow + 1;
                        }
                        break;
                }

                if (Miner.EndGame) break;
                if (Miner._coals == 0) break;
            }
            string currentPosition = currentPositionRow.ToString() + currentPositionCol.ToString();
            return currentPosition;

        }

        private static void CheckSymbol(int currentPositionRow, int currentPositionCol)
        {
            if (Miner._board[currentPositionRow, currentPositionCol] == 'e') Miner.EndGame = true;
            if (Miner._board[currentPositionRow, currentPositionCol] == 'c')
            {
                Miner._board[currentPositionRow, currentPositionCol] = '*';
                Miner._coals--;
            }
        }

        private static void Input()
        {
            Miner._size = int.Parse(Console.ReadLine());
            Miner._commands = new Queue<string>(
                Console.ReadLine().Split());
            Miner._board = new char[Miner._size, Miner._size];

            for (int i = 0; i < Miner._size; i++)
            {
                char[] column = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int j = 0; j < column.Length; j++)
                {
                    Miner._board[i, j] = column[j];
                    if (Miner._board[i, j] == 'c') Miner._coals++;
                }
            }
        }

        private static bool ValidIndex(int row, int col)
            => row >= 0 && row < Miner._size && col >= 0 && col < Miner._size;
    }
}
