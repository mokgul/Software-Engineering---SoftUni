using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var names = new HashSet<string>();
            for (int i = 0; i < count; i++)
                names.Add(Console.ReadLine());
            Console.WriteLine(string.Join(Environment.NewLine,names));
        }
    }
}
