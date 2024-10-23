
namespace RecursiveArraySum;

public class Program
{
    static void Main(string[] args)
    {
        int[] nums = Console.ReadLine()!
            .Split()
            .Select(int.Parse)
            .ToArray();
        Console.WriteLine(Sum(nums, nums.Length - 1));
    }

    private static int Sum(int[] nums, int index)
    {
        if (index < 0)
        {
            return 0;
        }
        return nums[index] + Sum(nums, index - 1);
    }
}
