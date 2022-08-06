using System;
using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\+359([ |\-]{1})2\1[0-9]{3}\1[0-9]{4}\b";
            string phoneNumbers = Console.ReadLine();

            MatchCollection matched = Regex.Matches(phoneNumbers, pattern);

            Console.WriteLine(string.Join(", ",matched));
        }
    }
}
