using System;

namespace Tournament_of_Christmas
{
    class Program
    {
        static void Main(string[] args)
        {
            string game = "";
            string result = "";

            double profit = 0;
            double totalProfit = 0;

            int dailyWins = 0;
            int dailyLoses = 0;
            int totalWins = 0;
            int totalLoses = 0;
            int day = 1;

            int days = int.Parse(Console.ReadLine());

            while (day <= days)
            {
                game = Console.ReadLine();
                if (game == "Finish") goto finish;
                result = Console.ReadLine();

                if (game != "Finish")
                {
                    if (result == "win")
                    {
                        dailyWins++;
                        profit += 20;
                    }
                    else if (result == "lose")
                    {
                        dailyLoses++;
                    }
                }
            finish:
                if (game == "Finish")
                {
                    if (dailyWins > dailyLoses)
                    {
                        profit *= 1.1;
                    }
                    totalProfit += profit;
                    totalLoses += dailyLoses;
                    totalWins += dailyWins;
                    profit = 0;
                    dailyLoses = 0;
                    dailyWins = 0;
                    day++;
                }
            }
            if (totalWins > totalLoses)
            {
                totalProfit *= 1.2;
                Console.WriteLine($"You won the tournament! Total raised money: {totalProfit:f2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {totalProfit:f2}");
            }
        }
    }
}
