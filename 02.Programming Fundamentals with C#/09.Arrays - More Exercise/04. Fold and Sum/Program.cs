using System;
using System.Linq;

namespace _04._Fold_and_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //reading an array of integers
            int[] integers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            //giving length for the new arrays
            //since the integer array has k*4 elements => 4,8,12,...
            //the length of the folded arrays would be half the length of the initial array
            //top array = topleft + topright
            // 8 elements = 2 topleft + 4 bottom + 2 topright
            //foldIndex is where each array is getting split
            // length 8 / 4 = 2, at index 2 and index 6
            int[] bottom = new int[integers.Length / 2];
            int[] topLeft = new int[integers.Length / 4];
            int[] topRight = new int[integers.Length / 4];
            int foldIndex = integers.Length / 4;
            int indexTopRight = 0;
            //index for filling the topRight array

            for (int i = 0; i < integers.Length; i++)
            {
                //bottom array, range from index 2 to 6 ( if we have length 8)
                if (i >= foldIndex && i < (integers.Length - foldIndex))
                {
                    bottom[i - foldIndex] = integers[i];
                }

                if (i < foldIndex)
                {
                    topLeft[i] = integers[i];
                }

                if (i >= (integers.Length - foldIndex))
                {
                    topRight[indexTopRight] = integers[i];
                    indexTopRight++;
                }
            }
            //Reversing top arrays
            Array.Reverse(topLeft);
            Array.Reverse(topRight);
            //Joing top arrays
            int[] top = topLeft.Concat(topRight).ToArray();

            //creating and printing the sum of the new arrays
            int[] result = new int[integers.Length / 2];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = top[i] + bottom[i];
            }

            foreach (int sum in result)
            {
                Console.Write(sum + " ");
            }
        }
    }
}