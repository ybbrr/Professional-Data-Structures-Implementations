using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.SortingAlgorithms
{
    public class MergeSort
    {
        private static void Merge<T>(T[] array, int left, int middle, int right) where T : IComparable
        {
            T[] leftArray = new T[middle - left + 1];
            T[] rightArray = new T[right - middle];

            System.Array.Copy(array, left, leftArray, 0, middle - left + 1);
            System.Array.Copy(array, middle + 1, rightArray, 0, right - middle);

            int i = 0;
            int j = 0;

            for (int k = left; k < right + 1; k++)
            {
                if (i == leftArray.Length) array[k] = rightArray[j++];
                else if (j == rightArray.Length) array[k] = leftArray[i++];
                else if (leftArray[i].CompareTo(rightArray[j]) < 0) array[k] = leftArray[i++];
                else array[k] = rightArray[j++];
            }
        }

        private static void Sort<T>(T[] array, int left, int right) where T : IComparable
        {
            int middle = 0;
            if (left < right)
            {
                middle = (left + right) / 2;
                Sort(array, left, middle);
                Sort(array, middle + 1, right);
                Merge(array, left, middle, right);
            }
        }

        public static void Sort<T>(T[] array) where T : IComparable
        {
            Sort(array, 0, array.Length - 1);
        }
    }
}
