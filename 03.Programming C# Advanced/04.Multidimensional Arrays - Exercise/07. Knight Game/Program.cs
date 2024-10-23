using System;

namespace _07._Knight_Game
{
    internal class Knight
    {
        private static char[,] board;
        private static int size = 0;
        static void Main(string[] args)
        {
            Knight.size = int.Parse(Console.ReadLine());
            Knight.board = new char[size, size];

            for (int i = 0; i < Knight.size; i++)
            {
                string column = Console.ReadLine();
                for (int j = 0; j < Knight.size; j++)
                {
                    Knight.board[i, j] = column[j];
                }
            }
            if (size < 3)
            {
                Console.WriteLine(0);
                return;
            }

            bool threat = true;
            int removed = 0;
            while (threat)
            {
                int maxThreat = 0;
                int rowToRemove = 0;
                int colToRemove = 0;
                for (int i = 0; i < Knight.size; i++)
                {
                    for (int j = 0; j < Knight.size; j++)
                    {
                        if (Knight.board[i, j] == 'K')
                        {
                            var currentThreat = ThreatLevel(i, j);
                            if (currentThreat > maxThreat)
                            {
                                maxThreat = currentThreat;
                                rowToRemove = i;
                                colToRemove = j;
                            }
                        }
                    }
                }
                if (maxThreat > 0)
                {
                    Knight.board[rowToRemove, colToRemove] = '0';
                    removed++;
                }
                if (maxThreat == 0) threat = false;
            }

            Console.WriteLine(removed);
        }

        private static int ThreatLevel(int row, int col)
        {
            int threat = 0;
            //upLeft
            if (ValidIndex(row - 2, col - 1))
                if (Knight.board[row - 2, col - 1] == 'K')
                    threat++;

            //upRight
            if (ValidIndex(row - 2, col + 1))
                if (Knight.board[row - 2, col + 1] == 'K')
                    threat++;

            //rightUp
            if (ValidIndex(row - 1, col + 2))
                if (Knight.board[row - 1, col + 2] == 'K')
                    threat++;

            //rightDown
            if (ValidIndex(row + 1, col + 2))
                if (Knight.board[row + 1, col + 2] == 'K')
                    threat++;

            //downRight
            if (ValidIndex(row + 2, col + 1))
                if (Knight.board[row + 2, col + 1] == 'K')
                    threat++;

            //downLeft
            if (ValidIndex(row + 2, col - 1))
                if (Knight.board[row + 2, col - 1] == 'K')
                    threat++;

            //leftDown
            if (ValidIndex(row + 1, col - 2))
                if (Knight.board[row + 1, col - 2] == 'K')
                    threat++;

            //leftUp
            if (ValidIndex(row - 1, col - 2))
                if (Knight.board[row - 1, col - 2] == 'K')
                    threat++;

            return threat;
        }

        private static bool ValidIndex(int row, int col)
            => row >= 0 && row < Knight.size && col >= 0 && col < Knight.size;
    }
}
