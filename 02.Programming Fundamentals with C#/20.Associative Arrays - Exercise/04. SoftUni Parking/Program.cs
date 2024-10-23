using System;
using System.Collections.Generic;

namespace _04._SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> users = UsersActions();
            foreach (var keyValuePair in users)
            {
                Console.WriteLine($"{keyValuePair.Key} => {keyValuePair.Value}");
            }
        }

        private static Dictionary<string, string> UsersActions()
        {
            Dictionary<string, string> users = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string[] command = line.Split(' ');
                switch (command[0])
                {
                    case "register":
                        users = Register(users, command);
                        break;
                    case "unregister":
                        users = Unregister(users, command);
                        break;
                }
            }
            return users;
        }

        private static Dictionary<string, string> Register(Dictionary<string, string> users, string[] command)
        {
            string username = command[1];
            string license = command[2];
            if (users.ContainsKey(username))
                Console.WriteLine($"ERROR: already registered with plate number {license}");
            else
            {
                users.Add(username, license);
                Console.WriteLine($"{username} registered {license} successfully");
            }
            return users;
        }

        private static Dictionary<string, string> Unregister(Dictionary<string, string> users, string[] command)
        {
            string username = command[1];

            if (!users.ContainsKey(username))
                Console.WriteLine($"ERROR: user {username} not found");
            else
            {
                users.Remove(username);
                Console.WriteLine($"{username} unregistered successfully");
            }

            return users;
        }
    }
}
