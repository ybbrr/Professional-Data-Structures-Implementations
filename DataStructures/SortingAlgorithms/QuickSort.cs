using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Benin Shared Özelliklerimin dizini.
using DataStructures.Shared;

namespace DataStructures.SortingAlgorithms
{
    public class QuickSort
    {
        private static int Partition<T>(T[] array, int lower, int upper ) where T : IComparable
        {
            int i = lower;
            int j = upper;

            T pivot = array[lower];

            do
            {
                while (array[i].CompareTo(pivot) < 0) i++;
                while (array[j].CompareTo(pivot) > 0) j--;
                if (i >= j) break;
                Sorting.Swap<T>(array, i, j);
            } while (i <= j);

            return j;
        }

        private static void Sort<T>(T[] array, int lower, int upper) where T : IComparable
        {
            if (lower < upper)
            {
                int partition_index = Partition(array, lower, upper);
                Sort(array, lower, partition_index);
                Sort(array, partition_index + 1, upper);
            }
        }
        public static void Sort<T>(T[] array) where T : IComparable
        {
            Sort(array, 0, array.Length - 1);
        }
    }
}
