
namespace MergeSort;

public class StartUp
{
    static void Main(string[] args)
    {
        int[] arr = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
        arr = Mergesort<int>.Sort(arr);
        Console.WriteLine(string.Join(" ", arr));
    }
}
