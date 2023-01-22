using System;
using System.Collections.Generic;
using System.Linq;

namespace Football_Team_Generator
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            while (true)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split(';');
                try
                {
                    switch (tokens[0])
                    {
                        case "Team":
                            teams.Add(new Team(tokens[1]));
                            break;
                        case "Add":
                            string team = tokens[1];
                            string player = tokens[2];
                            Team current = teams.FirstOrDefault(t => t.Name == team);
                            if (!teams.Contains(current))
                                throw new ArgumentException(string.Format(ExceptionMessages.TEAM_DOES_NOT_EXIST, team));
                            current.AddPlayer(team, new Player(player,
                                int.Parse(tokens[3]),
                                int.Parse(tokens[4]),
                                int.Parse(tokens[5]),
                                int.Parse(tokens[6]),
                                int.Parse(tokens[7])));
                            break;
                        case "Remove":
                            string teamToRemove = tokens[1];
                            string playerToRemove = tokens[2];
                            Team currentx = teams.FirstOrDefault(t => t.Name == teamToRemove);
                            if(currentx == null)
                                throw new ArgumentException(string.Format(ExceptionMessages.TEAM_DOES_NOT_EXIST, teamToRemove));
                            currentx.RemovePlayer(teamToRemove, playerToRemove);
                            break;
                        case "Rating":
                            string teamForRate = tokens[1];
                            Team currenty = teams.FirstOrDefault(t => t.Name == teamForRate);
                            if (currenty == null)
                                throw new ArgumentException(string.Format(ExceptionMessages.TEAM_DOES_NOT_EXIST, teamForRate));
                            Console.WriteLine(currenty);
                            break;
                        case "END": return;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
