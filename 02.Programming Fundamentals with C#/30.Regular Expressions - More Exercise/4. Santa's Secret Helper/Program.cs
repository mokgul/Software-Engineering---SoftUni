using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace _4._Santa_s_Secret_Helper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            List<string> names = new List<string>();
            string message = Console.ReadLine();
            while (message != "end")
            {
                string decrypted = string.Empty;
                foreach (var ch in message)
                    decrypted += (char)(ch - key);
                string pattern = @"@(?<name>[A-za-z]+)[^@\-!:>]*!(?<type>[GN])!";
                Match match = Regex.Match(decrypted, pattern);
                string name = match.Groups["name"].Value;
                string type = match.Groups["type"].Value;
                if (!names.Contains(name))
                {
                    if(type == "G")
                        names.Add(name);
                }
                message = Console.ReadLine();
            }
            names.ForEach(x => Console.WriteLine(x));
        }
    }
}
