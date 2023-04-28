namespace BinarySearchAlgorithm;

public class StartUp
{
    static void Main(string[] args)
    {
        int[] array = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
        int key = int.Parse(Console.ReadLine()!);

        Console.WriteLine(BinarySearch.IndexOf(array, key));
    }
}

