using System;
using System.Collections.Generic;
using System.Linq;


namespace _05._Teamwork_Projects
{
    class Team
    {
        public Team(string[] info)
        {
            this.Name = info[1];
            this.Creator = info[0];
            this.Members = new List<string>();
        }
        public string Name { get; set; }

        public string Creator { get; set; }

        public List<string> Members { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            int countOfTeams = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfTeams; i++)
            {
                string[] line = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries);
                // line[0] = user , line[1] = teamName

                if (TeamDoesNotExist(teams, line[1]) && IsNotCreator(teams, line[0]))
                {
                    Team team = new Team(line);
                    teams.Add(team);
                    Console.WriteLine($"Team {line[1]} has been created by {line[0]}!");
                }
                else if (!TeamDoesNotExist(teams, line[1]))
                {
                    Console.WriteLine($"Team {line[1]} was already created!");
                }
                else if (!IsNotCreator(teams, line[0]))
                {
                    Console.WriteLine($"{line[0]} cannot create another team!");
                }
            }

            string command = Console.ReadLine();

            while (command != "end of assignment")
            {
                string[] tokens = command.Split("->", StringSplitOptions.RemoveEmptyEntries);
                string user = tokens[0];
                string teamName = tokens[1];

                if (!TeamDoesNotExist(teams, teamName) && IsNotMember(teams, user) && IsNotCreator(teams, user))
                {
                    AddMember(teams, user, teamName);
                }
                else if (TeamDoesNotExist(teams, teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if ((!IsNotMember(teams, user) || (!IsNotCreator(teams, user))))
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                }
                command = Console.ReadLine();
            }

            List<Team> disbanded = teams.Where(item => item.Members.Count == 0).ToList();
            disbanded = disbanded.OrderBy(item => item.Name).ToList();
            //ordered name in ascending order

            List<Team> valid = teams.Where(item => item.Members.Count > 0).ToList();
            valid = valid.OrderByDescending(item => item.Members.Count)
                .ThenBy(item => item.Name).ToList();
            //ordered by count of members


            foreach (Team team in valid)
            {
                Console.WriteLine($"{team.Name}");
                Console.WriteLine($"- {team.Creator}");
                team.Members.Sort();
                foreach (string member in team.Members)
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine($"Teams to disband:");
            foreach (Team team in disbanded)
            {
                Console.WriteLine($"{team.Name}");
            }
        }

        private static bool IsNotCreator(List<Team> teams, string user)
        {
            foreach (Team team in teams)
            {
                if (team.Creator == user)
                    return false;
            }
            return true;
        }

        private static bool TeamDoesNotExist(List<Team> teams, string teamName)
        {
            foreach (Team team in teams)
            {
                if (team.Name == teamName)
                    return false;
            }
            return true;
        }

        private static bool IsNotMember(List<Team> teams, string user)
        {
            foreach (Team team in teams)
            {
                if (team.Members != null)
                {
                    if (team.Members.Contains(user))
                        return false;
                }
            }
            return true;
        }

        private static void AddMember(List<Team> teams, string user, string teamName)
        {
            foreach (Team team in teams)
            {
                if (team.Name == teamName)
                    team.Members.Add(user);
            }
        }
    }
}
