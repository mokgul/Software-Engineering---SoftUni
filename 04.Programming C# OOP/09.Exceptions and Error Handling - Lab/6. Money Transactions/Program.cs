using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Money_Transactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(',');
            Dictionary<int, double> accounts = new Dictionary<int, double>();
            foreach (var i in input)
            {
                string[] temp = i.Split('-');
                accounts.Add(
                    int.Parse(temp[0])
                    , double.Parse(temp[1]));
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] tokens = command.Split();
                int account = int.Parse(tokens[1]);
                try
                {
                    if (!accounts.ContainsKey(account))
                        throw new ArgumentException("Invalid account!");
                    double sum = double.Parse(tokens[2]);
                    _ = tokens[0] switch
                    {
                        "Deposit" => accounts[account] += sum,
                        "Withdraw" => sum > accounts[account]
                            ? throw new ArgumentException("Insufficient balance!")
                            : accounts[account] -= sum,
                        _ => throw new ArgumentException("Invalid command!")
                    };
                    Console.WriteLine($"Account {account} has new balance: {accounts[account]}");
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
                command = Console.ReadLine();
            }
        }
    }
}
