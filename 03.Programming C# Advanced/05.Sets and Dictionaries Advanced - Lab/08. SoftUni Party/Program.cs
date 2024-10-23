using System;
using System.Collections.Generic;

namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> regular = new HashSet<string>();
            HashSet<string> vip = new HashSet<string>();

            string command = Console.ReadLine();
            while (command != "END")
            {
                if (command == "PARTY")
                {
                    command = Console.ReadLine();
                    while (command != "END")
                    {
                        if (vip.Contains(command))
                            vip.Remove(command);
                        if(regular.Contains(command))
                            regular.Remove(command);
                        command = Console.ReadLine();
                    }
                    continue;
                }
                if (Char.IsDigit(command[0]))
                    vip.Add(command);
                else
                    regular.Add(command);

                command = Console.ReadLine();
            }

            Console.WriteLine(vip.Count + regular.Count);
            if(vip.Count > 0)
                Console.WriteLine(string.Join(Environment.NewLine,vip));
            if(regular.Count > 0)
                Console.WriteLine(string.Join(Environment.NewLine,regular));
        }
    }
}
