namespace MergeSort;

public class Mergesort<T> where T : IComparable
{
    private static T[] aux;

    public static T[] Sort(T[] arr)
    {
        T[] left;
        T[] right;
        T[] result = new T[arr.Length];
        if(arr.Length == 1)
            return arr;

        int midPoint = arr.Length / 2;
        left = new T[midPoint];
        right = arr.Length % 2 == 0 ? new T[midPoint] : new T[midPoint + 1];

        for (int i = 0; i < midPoint; i++)
            left[i] = arr[i];

        int x = 0;
        for (int i = midPoint; i < arr.Length; i++)
        {
            right[x] = arr[i];
            x++;
        }

        left = Sort(left);
        right = Sort(right);
        result = Merge(left, right);
        return result;
    }

    private static T[] Merge(T[] left, T[] right)
    {
        int resultLength = right.Length + left.Length;
        T[] result = new T[resultLength];

        int leftIndex = 0;
        int rightIndex = 0;
        int resultIndex = 0;

        while (leftIndex < left.Length || rightIndex < right.Length)
        {
            if (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex].CompareTo(right[rightIndex]) == -1 || left[leftIndex].CompareTo(right[rightIndex]) == 0)
                {
                    result[resultIndex] = left[leftIndex];
                    leftIndex++;
                    resultIndex++;
                }
                else
                {
                    result[resultIndex] = right[rightIndex];
                    rightIndex++;
                    resultIndex++;
                }
            }
            else if (leftIndex < left.Length)
            {
                result[resultIndex] = left[leftIndex];
                leftIndex++;
                resultIndex++;
            }
            else if (rightIndex < right.Length)
            {
                result[resultIndex] = right[rightIndex];
                rightIndex++;
                resultIndex++;
            }
        }

        return result;
    }
}
