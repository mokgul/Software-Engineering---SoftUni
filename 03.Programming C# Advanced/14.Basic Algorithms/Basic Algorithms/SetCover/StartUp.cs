namespace SetCover;

public class StartUp
{
    static void Main(string[] args)
    {
        int[] universe = Console.ReadLine()!.Split(",").Select(int.Parse).ToArray();

        int numberOfSets = int.Parse(Console.ReadLine()!);
        int[][] sets = new int[numberOfSets][];

        for (int row = 0; row < sets.Length; row++)
        {
            int[] rowsValue = Console.ReadLine()!.Split(",").Select(int.Parse).ToArray();
            sets[row] = new int[rowsValue.Length];

            for (int col = 0; col < sets[row].Length; col++)
            {
                sets[row][col] = rowsValue[col];
            }
        }

        List<int[]> selectedSets = ChooseSets(sets.ToList(), universe.ToList());
        Console.WriteLine($"Sets to take ({selectedSets.Count}):");

        foreach (var set in selectedSets)
        {
            Console.WriteLine($"{{ {string.Join(", ", set)} }}");
        }
    }

    public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
    {
        List<int[]> selectedSets = new List<int[]>();
        while (universe.Count > 0)
        {
            int[] longestSet = sets.OrderByDescending(s => s.Count(x => universe.Contains(x)))
                .FirstOrDefault()!;
            selectedSets.Add(longestSet);
            sets.Remove(longestSet);
           
            foreach(var item in longestSet)
                if(universe.Contains(item))
                    universe.Remove(item);
        }

        return selectedSets;
    }
}
