using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;


namespace _02._Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Contest> contestList = new List<Contest>();
            Dictionary<string, int> users = new Dictionary<string, int>();

            string line = Console.ReadLine();
            while (line != "no more time")
            {
                string[] tokens = line.Split(" -> ");
                string username = tokens[0];
                string contest = tokens[1];
                int points = int.Parse(tokens[2]);


                if (!Contest.IsInList(contestList, contest))
                {
                    Contest newContest = new Contest(contest);
                    contestList.Add(newContest);
                }
                UpdatePoints(username, contest, points, contestList);
                line = Console.ReadLine();
            }
            UpdateUser(contestList,users);
            PrintResults(contestList, users);
        }

        static void PrintResults(List<Contest> contestList, Dictionary<string, int> users)
        {
            foreach (Contest contest in contestList)
            {
                int index = 1;
                Console.WriteLine($"{contest.Name}: {contest.Results.Count} participants");
                Console.WriteLine(string.Join(Environment.NewLine,
                    contest.Results.OrderByDescending(x => x.Value)
                        .ThenBy(y => y.Key)
                        .Select(y => $"{index++}. {y.Key} <::> {y.Value}")));
            }

            Console.WriteLine("Individual standings:");

            int indexOfUsers = 1;
            Console.WriteLine(string.Join(Environment.NewLine,
                users.OrderByDescending(x => x.Value)
                    .ThenBy(y => y.Key)
                    .Select(y => $"{indexOfUsers++}. {y.Key} -> {y.Value}")));

        }

        private static void UpdatePoints(string username, string contest, int points, List<Contest> contestList)
        {
            foreach (Contest item in contestList)
            {
                if (item.Name == contest)
                {
                    if (!Contest.IsUserParticipating(username, item))
                    {
                        item.Results.Add(username, points);
                    }
                    else
                    {
                        item.Results[username] = Math.Max(points, item.Results[username]);
                    }
                }
            }
        }

        private static void UpdateUser(List<Contest> contestList, Dictionary<string, int> users)
        {
            foreach (Contest contest in contestList)
            {
                foreach (var item in contest.Results)
                {
                    if (!users.ContainsKey(item.Key))
                    {
                        users.Add(item.Key, 0);
                    }

                    users[item.Key] += item.Value;
                }
            }
        }
    }

    public class Contest
    {
        public Contest(string name)
        {
            this.Name = name;
            this.Results = new Dictionary<string, int>();
        }
        public string Name { get; set; }

        public Dictionary<string, int> Results { get; set; }

        public static bool IsInList(List<Contest> contestList, string contest)
            => contestList.Any(c => c.Name == contest);

        public static bool IsUserParticipating(string username, Contest contest)
            => contest.Results.ContainsKey(username);
    }
}
