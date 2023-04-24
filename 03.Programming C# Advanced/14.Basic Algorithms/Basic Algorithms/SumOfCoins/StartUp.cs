
namespace SumOfCoins;

public class StartUp
{
    public static void Main(string[] args)
    {
        int[] coins = Console.ReadLine()!.Split(',').Select(int.Parse).ToArray();
        int sum = int.Parse(Console.ReadLine()!);

        try
        {
            var selected = ChooseCoins(coins, sum);
            selected = selected.Where(x => x.Value != 0)
                .OrderByDescending(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"Number of coins to take: {selected.Values.Sum()}");

            foreach (var coin in selected)
                Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        Dictionary<int, int> coinsCount = new Dictionary<int, int>();

        foreach (int co in coins)
            coinsCount[co] = 0;

        coins = coins.OrderByDescending(x => x).ToList();
        while (targetSum > 0)
        {
            if (targetSum >= coins[0])
            {
                coinsCount[coins[0]]++;
                targetSum -= coins[0];
                if (targetSum >= coins[0])
                    continue;

            }
            coins.RemoveAt(0);
            if (coins.Count == 0 && targetSum != 0)
                throw new InvalidOperationException("Error");
        }

        return coinsCount;
    }
}
