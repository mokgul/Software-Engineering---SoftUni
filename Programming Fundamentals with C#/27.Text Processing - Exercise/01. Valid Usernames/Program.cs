using System;
using System.Data.SqlTypes;


namespace _01._Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");
            foreach (string name in usernames)
            {
                if(Valid(name))
                    Console.WriteLine(name);
            }
        }

        static bool Valid(string name)
            => CheckOne(name) && CheckTwo(name) ? true : false;

        private static bool CheckTwo(string name)
        {
            for (int i = 0; i < name.Length; i++)
            {
                char current = name[i];
                if (char.IsLetter(current) == false
                    && char.IsDigit(current) == false
                    && current != '-'
                    && current != '_')
                    return false;
            }
            return true;
        }

        private static bool CheckOne(string name)
            => (name.Length >= 3 && name.Length <= 16) ? true : false;
    }
}
