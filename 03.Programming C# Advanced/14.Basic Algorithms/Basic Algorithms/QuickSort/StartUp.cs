using System.Collections.Concurrent;

namespace QuickSort;

public class StartUp
{
    static void Main(string[] args)
    {
        int[] array = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

        QuickSort(array);

        Console.WriteLine(string.Join(" ", array));
    }

    public static void QuickSort(int[] array)
    {
        QuickSort(array, 0, array.Length - 1);
    }

    public static void QuickSort(int[] array, int left, int right)
    {
        if (left >= right)
        {
            return;
        }
        int pivot = array[(left + right) / 2 ];
        int index = Partition(array, left, right, pivot);

        QuickSort(array, left, index - 1);
        QuickSort(array, index, right);
    }

    public static int Partition(int[] array, int left, int right, int pivot)
    {
        while (left <= right)
        {
            while (array[left] < pivot)
            {
                left++;
            }

            while (array[right] > pivot)
            {
                right--;
            }

            if (left <= right)
            {
                (array[left], array[right]) = (array[right], array[left]);
                left++;
                right--;
            }
        }
        return left;
    }
}
