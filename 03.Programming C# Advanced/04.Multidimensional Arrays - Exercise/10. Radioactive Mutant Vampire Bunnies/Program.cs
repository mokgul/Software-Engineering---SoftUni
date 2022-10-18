using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    internal class Board
    {
        private static int _row;
        private static int _col;
        private static char[,] _board;
        private static Queue<char> _commands;
        private static Queue<string> _bunnyPositions = new Queue<string>();
        private static bool gameWon = false;
        private static bool gameLost = false;
        static void Main(string[] args)
        {
            Input();
            FindStart();
        }

        private static void PrintBoard()
        {
            for (int i = 0; i < Board._row; i++)
            {
                for (int j = 0; j < Board._col; j++)
                {
                    Console.Write(Board._board[i,j]);
                }

                Console.WriteLine();
            }
        }
        private static void FindStart()
        {
            string currentPosition = String.Empty;
            for (int i = 0; i < Board._row; i++)
            {
                for (int j = 0; j < Board._col; j++)
                {
                    if (Board._board[i, j] == 'P')
                    {
                        currentPosition = Movement(i, j);
                    }
                    if(Board.gameWon)
                    {
                        PrintBoard();
                        string[] tokens = currentPosition.Split();
                        Console.WriteLine($"won: {tokens[0]} {tokens[1]}");
                        return;
                    }
                    if(Board.gameLost)
                    {
                        PrintBoard();
                        string[] tokens = currentPosition.Split();
                        Console.WriteLine($"dead: {tokens[0]} {tokens[1]}");
                        return;
                    }
                }
            }
        }

        private static string Movement(int i, int j)
        {
            int currentPositionRow = i;
            int currentPositionCol = j;
            while (Board._commands.Count > 0)
            {
                if (Board.gameWon || Board.gameLost) break;
                char nextCommand = Board._commands.Dequeue();
                
                switch (nextCommand)
                {
                    case 'L':
                        if (!ValidIndex(currentPositionRow, currentPositionCol - 1))
                        {
                            Board._board[currentPositionRow, currentPositionCol] = '.';
                            Board.gameWon = true;
                            SpreadBunnies();
                            UpdateBunnyPositions();
                        }
                        else
                        {
                            if (CheckForBunny(currentPositionRow, currentPositionCol - 1))
                            {
                                Board.gameLost = true;
                                Board._board[currentPositionRow, currentPositionCol] = '.';
                                currentPositionCol = currentPositionCol - 1;
                                SpreadBunnies();
                                UpdateBunnyPositions();
                            }
                            else
                            {
                                Board._board[currentPositionRow, currentPositionCol] = '.';
                                currentPositionCol = currentPositionCol - 1;
                                Board._board[currentPositionRow, currentPositionCol] = 'P';
                                SpreadBunnies();
                                UpdateBunnyPositions();
                            }
                        }
                        break;
                    case 'R':
                        if (!ValidIndex(currentPositionRow, currentPositionCol + 1))
                        {
                            //player goes out of borders and wins
                            Board._board[currentPositionRow, currentPositionCol] = '.';
                            Board.gameWon = true;
                            SpreadBunnies();
                            UpdateBunnyPositions();
                        }
                        else 
                        {
                            if (CheckForBunny(currentPositionRow, currentPositionCol + 1))
                            {
                                //player steps on bunny
                                Board.gameLost = true;
                                Board._board[currentPositionRow, currentPositionCol] = '.';
                                currentPositionCol = currentPositionCol + 1;
                                SpreadBunnies();
                                UpdateBunnyPositions();
                            }
                            else
                            {
                                //player doesnt step on bunny but we should check
                                //if a bunny will spread over the player

                                
                                Board._board[currentPositionRow, currentPositionCol] = '.';
                                currentPositionCol = currentPositionCol + 1;
                                Board._board[currentPositionRow, currentPositionCol] = 'P';
                                SpreadBunnies();
                                UpdateBunnyPositions();
                            }
                        }
                        break;
                    case 'U':
                        if (!ValidIndex(currentPositionRow - 1, currentPositionCol))
                        {
                            Board._board[currentPositionRow, currentPositionCol] = '.';
                            Board.gameWon = true;
                            SpreadBunnies();
                            UpdateBunnyPositions();
                        }
                        else 
                        {
                            if(CheckForBunny(currentPositionRow - 1, currentPositionCol))
                            {
                                Board.gameLost = true;
                                Board._board[currentPositionRow, currentPositionCol] = '.';
                                currentPositionRow = currentPositionRow - 1;
                                SpreadBunnies();
                                UpdateBunnyPositions();
                            }
                            else
                            {
                                Board._board[currentPositionRow, currentPositionCol] = '.';
                                currentPositionRow = currentPositionRow - 1;
                                Board._board[currentPositionRow, currentPositionCol] = 'P';
                                SpreadBunnies();
                                UpdateBunnyPositions();
                            }
                        }
                        break;
                    case 'D':
                        if (!ValidIndex(currentPositionRow + 1, currentPositionCol))
                        {
                            Board._board[currentPositionRow, currentPositionCol] = '.';
                            Board.gameWon = true;
                            SpreadBunnies();
                            UpdateBunnyPositions();
                        }
                        else 
                        {
                            if (CheckForBunny(currentPositionRow + 1, currentPositionCol))
                            {
                                Board.gameLost = true;
                                Board._board[currentPositionRow, currentPositionCol] = '.';
                                currentPositionRow = currentPositionRow + 1;
                                SpreadBunnies();
                                UpdateBunnyPositions();
                            }
                            else
                            {
                                Board._board[currentPositionRow, currentPositionCol] = '.';
                                currentPositionRow = currentPositionRow + 1;
                                Board._board[currentPositionRow, currentPositionCol] = 'P';
                                SpreadBunnies();
                                UpdateBunnyPositions();
                            }
                        }
                        break;
                }
            }
            string currentPosition = currentPositionRow.ToString() + " " + currentPositionCol.ToString();
            return currentPosition;

        }

        private static void UpdateBunnyPositions()
        {
            for (int i = 0; i < Board._row; i++)
            {
                for (int j = 0; j < Board._col; j++)
                {
                    if(Board._board[i,j] == 'B')
                        Board._bunnyPositions.Enqueue(i.ToString() + " "+ j.ToString());
                }
            }
        }

        private static void SpreadBunnies()
        {
            while (Board._bunnyPositions.Count > 0)
            {
                string position = Board._bunnyPositions.Dequeue();
                string[] tokens = position.Split();
                int row = int.Parse(tokens[0].ToString());
                int col = int.Parse(tokens[1].ToString());
                //up
                if (ValidIndex(row - 1, col))
                {
                    if (Board._board[row - 1, col] == 'P')
                        Board.gameLost = true;
                    Board._board[row - 1, col] = 'B';
                }
                //right
                if (ValidIndex(row, col + 1))
                {
                    if(Board._board[row, col + 1] == 'P')
                        Board.gameLost = true;
                    Board._board[row, col + 1] = 'B';
                }
                //down
                if (ValidIndex(row + 1, col))
                {
                    if(Board._board[row + 1, col] == 'P')
                        Board.gameLost = true;
                    Board._board[row + 1, col] = 'B';
                }
                //left
                if (ValidIndex(row, col - 1))
                {
                    if(Board._board[row, col - 1] == 'P')
                        Board.gameLost = true;
                    Board._board[row, col - 1] = 'B';
                }
            }
        }

        private static bool CheckForBunny(int currentPositionRow, int currentPositionCol)
            => Board._board[currentPositionRow, currentPositionCol] == 'B';

        private static void Input()
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n)).ToArray();
            Board._row = dimensions[0];
            Board._col = dimensions[1];
            Board._board = new char[Board._row, Board._col];

            for (int i = 0; i < Board._row; i++)
            {
                string column = Console.ReadLine();

                for (int j = 0; j < Board._col; j++)
                {
                    Board._board[i, j] = column[j];
                    if (Board._board[i, j] == 'B')
                    {
                        Board._bunnyPositions.Enqueue(i.ToString() + " " +  j.ToString());
                    }
                }
            }
            Board._commands = new Queue<char>(Console.ReadLine().ToCharArray());
        }
        private static bool ValidIndex(int row, int col)
            => row >= 0 && row < Board._row && col >= 0 && col < Board._col;
    }
}
