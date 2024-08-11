using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Benim Heap'min dizini
using DataStructures.Heap;
//Benin Shared Özelliklerimin dizini.
using DataStructures.Shared;
//Benim Algoritmalar'ımın dizini.
using DataStructures.SortingAlgorithms;

namespace Apps
{
    public class SortingExamples
    {
        public static void HEAP_SORT()
        {
            var arr = new int[] { 16, 22, 44, 12, 55, 50, 6 };

            foreach (var item in arr)
            {
                Console.Write($"{item,-5}");
            }

            Console.WriteLine();

            var heap = new MinHeap<int>(arr);
            foreach (var item in heap)
            {
                Console.Write($"{heap.DeleteMinMax(),-5}");
            }
        }
        public static void MERGE_SORT()
        {
            var arr = new int[] { 16, 22, 44, 12, 55, 50, 6 };

            foreach (var item in arr)
            {
                Console.Write($"{item,-5}");
            }

            Console.WriteLine();

            MergeSort.Sort<int>(arr);
            foreach (var item in arr)
            {
                Console.Write($"{item,-5}");
            }
        }
        public static void QUICK_SORT()
        {
            var arr = new int[] { 16, 22, 44, 12, 55, 50, 6 };

            foreach (var item in arr)
            {
                Console.Write($"{item,-5}");
            }

            Console.WriteLine();

            QuickSort.Sort<int>(arr);
            foreach (var item in arr)
            {
                Console.Write($"{item,-5}");
            }

        }
        public static void INSERTION_SORT()
        {
            var arr = new int[] { 16, 22, 44, 12, 55, 50, 6 };

            foreach (var item in arr)
            {
                Console.Write($"{item,-5}");
            }

            Console.WriteLine();

            InsertionSort.Sort<int>(arr, SortDirection.Descending);
            foreach (var item in arr)
            {
                Console.Write($"{item,-5}");
            }

            Console.WriteLine();

            InsertionSort.Sort<int>(arr, SortDirection.Ascending);
            foreach (var item in arr)
            {
                Console.Write($"{item,-5}");
            }
        }
        public static void BUBBLE_SORT()
        {
            var arr = new int[] { 16, 22, 44, 12, 55, 50, 6 };

            foreach (var item in arr)
            {
                Console.Write($"{item,-5}");
            }

            Console.WriteLine();

            BubbleSort.Sort<int>(arr, SortDirection.Descending);
            foreach (var item in arr)
            {
                Console.Write($"{item,-5}");
            }

            Console.WriteLine();

            BubbleSort.Sort<int>(arr, SortDirection.Ascending);
            foreach (var item in arr)
            {
                Console.Write($"{item,-5}");
            }
        }
        public static void SELECTON_SORT()
        {
            var arr = new int[] { 16, 22, 44, 12, 55, 50, 6 };

            foreach (var item in arr)
            {
                Console.Write($"{item,-5}");
            }

            Console.WriteLine();

            SelectionSort.Sort<int>(arr, SortDirection.Descending);
            foreach (var item in arr)
            {
                Console.Write($"{item,-5}");
            }

            Console.WriteLine();

            SelectionSort.Sort<int>(arr, SortDirection.Ascending);
            foreach (var item in arr)
            {
                Console.Write($"{item,-5}");
            }
        }
    }
}
