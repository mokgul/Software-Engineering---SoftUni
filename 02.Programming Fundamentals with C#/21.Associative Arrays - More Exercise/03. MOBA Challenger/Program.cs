using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._MOBA_Challenger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();

            string line = Console.ReadLine();
            while (line != "Season end")
            {
                if (!line.Contains("vs"))
                {
                    UpdatePool(line, players);
                }
                else
                {
                    Duel(line, players);
                }

                line = Console.ReadLine();
            }
            PrintResults(players);
        }

        private static void PrintResults(List<Player> players)
        {
            foreach (Player player in players.OrderByDescending(x => x.PositionAndValue.Values.Sum()).ThenBy(k => k.PositionAndValue.Keys))
            {
                Console.WriteLine($"{player.Name}: {player.PositionAndValue.Values.Sum()} skill");
                Console.WriteLine(string.Join(Environment.NewLine,
                    player.PositionAndValue.OrderByDescending(x => x.Value)
                        .ThenBy(y => y.Key)
                        .Select(y => $"- {y.Key} <::> {y.Value}")));
            }
        }
        private static void Duel(string line, List<Player> players)
        {
            string[] playerInfo = line.Split(" vs ");
            string playerOne = playerInfo[0];
            string playerTwo = playerInfo[1];
            if (IsInPool(players, playerOne) && IsInPool(players, playerTwo))
            {
                Player playerFirst = players[players.FindIndex(p => p.Name == playerOne)];
                Player playerSecond = players[players.FindIndex(p => p.Name == playerTwo)];

                if (Player.Compare(playerFirst, playerSecond))
                {
                    if(playerFirst.PositionAndValue.Values.Sum() > playerSecond.PositionAndValue.Values.Sum())
                        players.Remove(playerSecond);
                    else if (playerSecond.PositionAndValue.Values.Sum() > playerFirst.PositionAndValue.Values.Sum())
                        players.Remove(playerFirst);
                    else
                    {
                        return;
                    }
                }
            }
        }
        private static void UpdatePool(string line, List<Player> players)
        {
            string[] playerInfo = line.Split(" -> ");
            string player = playerInfo[0];
            string position = playerInfo[1];
            int skill = int.Parse(playerInfo[2]);


            if (!IsInPool(players, player))
            {
                Player newPlayer = new Player(player);
                newPlayer.PositionAndValue.Add(position, skill);
                players.Add(newPlayer);
            }
            else
            {
                int indexOfPlayer = players.FindIndex(p => p.Name == player);
                if (!players[indexOfPlayer].PositionAndValue.ContainsKey(position))
                {
                    players[indexOfPlayer].PositionAndValue.Add(position, skill);
                }
                else
                {
                    players[indexOfPlayer].PositionAndValue[position] =
                        Math.Max(skill, players[indexOfPlayer].PositionAndValue[position]);
                }
            }
        }

        private static bool IsInPool(List<Player> players, string player)
            => players.Any(p => p.Name == player);
    }

    public class Player
    {
        public Player(string name)
        {
            Name = name;
            PositionAndValue = new Dictionary<string, int>();
        }
        public string Name { get; set; }

        public Dictionary<string, int> PositionAndValue { get; set; }

        public static bool Compare(Player first, Player second)
        {
            foreach (var item in first.PositionAndValue.Keys)
            {
                foreach (var itemTwo in second.PositionAndValue.Keys)
                {
                    if (item.Equals(itemTwo))
                        return true;
                }
            }
            return false;
        }
    }
}
