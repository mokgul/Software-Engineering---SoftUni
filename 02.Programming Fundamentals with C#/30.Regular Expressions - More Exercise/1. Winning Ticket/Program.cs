using System;
using System.Text.RegularExpressions;

namespace _1._Winning_Ticket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine().Split(new char[]{',',' '},StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tickets.Length; i++)
            {
                string validateTicket = @"([@#$^])\1{5,9}";
                string ticket = tickets[i];
                
                if (CheckLength(ticket))
                {
                    Console.WriteLine($"invalid ticket");
                    continue;
                }
                else if (GetWinnings(ticket, validateTicket).Length >= 6 
                         && GetWinnings(ticket, validateTicket).Length <= 9)
                {
                    string win = GetWinnings(ticket, validateTicket);
                    Console.WriteLine($"ticket \"{ticket}\" - {win.Length}{win[0]}");
                }
                else if (GetWinnings(ticket, validateTicket).Length == 10)
                {
                    string win = GetWinnings(ticket, validateTicket);
                    Console.WriteLine($"ticket \"{ticket}\" - 10{win[0]} Jackpot!");
                }
                else
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }
            }
        }

        private static bool CheckLength(string ticket)
            => ticket.Length != 20 ? true : false;

        private static string GetWinnings(string ticket, string pattern)
        {
            string matchingSymbols = string.Empty;
            string left = ticket.Substring(0, 10);
            string right = ticket.Substring(ticket.Length / 2, 10);
            MatchCollection leftSub = Regex.Matches(left, pattern);
            MatchCollection rightSub = Regex.Matches(right, pattern);
            if ((leftSub.Count > 0 && rightSub.Count > 0) &&
                (leftSub[0].Value.Contains(rightSub[0].Value) ||
                rightSub[0].Value.Contains(leftSub[0].Value)))
            {
                int length = Math.Min(leftSub[0].Value.Length, rightSub[0].Value.Length);
                if (length == leftSub[0].Value.Length)
                    matchingSymbols += leftSub[0].Value;
                else
                {
                    matchingSymbols += rightSub[0].Value;
                }
            }
            return matchingSymbols;
        }

    }
}
