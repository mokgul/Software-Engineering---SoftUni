using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace _03._Messages_Manager
{
    class User
    {
        public User(string name, int sent, int received)
        {
            this.Name = name;
            this.Sent = sent;
            this.Received = received;
        }
        public string Name { get; set; }
        public int Sent { get; set; }
        public int Received { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalMessages = int.Parse(Console.ReadLine());

            List<User> users = new List<User>();

            string line = Console.ReadLine();
            while (line != "Statistics")
            {
                string[] commands = line.Split("=");
                switch (commands[0])
                {
                    case "Add":
                        string user = commands[1];
                        int sent = int.Parse(commands[2]);
                        int received = int.Parse(commands[3]);

                        if (!users.Any(x => x.Name == user))
                        {
                            User newUser = new User(user, sent, received);
                            users.Add(newUser);
                        }
                        break;
                    case "Message":
                        User one = users.Find(x => x.Name == commands[1]);
                        User two = users.Find(x => x.Name == commands[2]);

                        if (one != null && two != null)
                        {
                            one.Sent++;
                            two.Received++;

                            if ((one.Sent + one.Received) >= totalMessages)
                            {
                                users.Remove(one);
                                Console.WriteLine($"{one.Name} reached the capacity!");
                            }

                            if ((two.Sent + two.Received) >= totalMessages)
                            {
                                users.Remove(two);
                                Console.WriteLine($"{two.Name} reached the capacity!");
                            }
                        }

                        break;
                    case "Empty":
                        string username = commands[1];
                        if (username == "All")
                            users.Clear();
                        else
                        {
                            User toDelete = users.Find(x => x.Name == username);
                            users.Remove(toDelete);
                        }
                        break;
                }
                line = Console.ReadLine();
            }

            Console.WriteLine($"Users count: {users.Count}");
            Console.WriteLine(string.Join(Environment.NewLine,
                users.Select(x => $"{x.Name} - {x.Sent + x.Received}")));
        }
    }
}
