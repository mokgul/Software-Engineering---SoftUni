namespace BinarySearchAlgorithm;

public class BinarySearch
{
    public static int IndexOf(int[] array, int key)
    {
        int start = 0;
        int end = array.Length - 1;

        while (start <= end)
        {
            int mid = start + (end - start) / 2;

            if (key < array[mid])
                end = mid - 1;
            else if(key > array[mid])
                start = mid + 1;
            else
                return mid;
        }

        return -1;
    }
}