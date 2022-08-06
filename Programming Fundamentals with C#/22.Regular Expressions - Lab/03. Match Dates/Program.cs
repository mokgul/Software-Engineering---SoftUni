using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Match_Dates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dates = Console.ReadLine();
            string pattern = @"\b(?<day>\d{2})([-.\/])(?<month>[A-Z]\w{2})\1(?<year>\d{4})\b";

            MatchCollection matched = Regex.Matches(dates, pattern);

            Console.WriteLine(string.Join(Environment.NewLine,
                matched.Select(x =>
                                    $"Day: {x.Groups["day"].Value}," +
                                    $" Month: {x.Groups["month"].Value}," +
                                    $" Year: {x.Groups["year"].Value}")));
        }
    }
}
