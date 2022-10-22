using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace _07._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vlogger> vloggersList = new List<Vlogger>();

            string input = Console.ReadLine();
            while (input != "Statistics")
            {
                string[] tokens = input.Split(' ');
                if (tokens[1] == "joined")
                {
                    string vlogger = tokens[0];
                    if (!vloggersList.Any(x => x.Name == vlogger))
                        vloggersList.Add(new Vlogger(vlogger));
                }
                else if (tokens[1] == "followed")
                {
                    string first = tokens[0];
                    string second = tokens[2];
                    if (IsInList(first, vloggersList) && IsInList(second, vloggersList))
                    {
                        Vlogger firstVlogger = vloggersList.First(x => x.Name == first);
                        Vlogger secondVlogger = vloggersList.First(x => x.Name == second);
                        if (first != second)
                        {
                            if (!secondVlogger.Followers.Contains(first))
                            {
                                secondVlogger.Followers.Add(first);
                                firstVlogger.Following.Add(second);
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            vloggersList = vloggersList
                .OrderByDescending(x => x.Followers.Count)
                .ThenBy(x => x.Following.Count).ToList();
            Console.WriteLine($"The V-Logger has a total of {vloggersList.Count} vloggers in its logs.");
            int index = 1;
            foreach (var vlogger in vloggersList)
            {
                if (index == 1)
                {
                    Console.WriteLine($"{index}. {vlogger.Name} : {vlogger.Followers.Count} followers, {vlogger.Following.Count} following");
                    if (vlogger.Followers.Count > 0)
                    {
                        foreach (var follower in vlogger.Followers.OrderBy(x => x))
                        {
                            Console.WriteLine($"* {follower}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"{index}. {vlogger.Name} : {vlogger.Followers.Count} followers, {vlogger.Following.Count} following");
                }

                index++;
            }
        }

        private static bool IsInList(string name, List<Vlogger> vloggersList)
            => vloggersList.Any(x => x.Name == name);
    }

    public class Vlogger
    {
        public Vlogger(string name)
        {
            this.Name = name;
            this.Followers = new HashSet<string>();
            this.Following = new HashSet<string>();
        }

        public string Name { get; set; }
        public HashSet<string> Followers { get; set; }
        public HashSet<string> Following { get; set; }

    }
}
