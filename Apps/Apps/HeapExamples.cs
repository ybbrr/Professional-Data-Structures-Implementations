using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Benim Heap'min dizini
using DataStructures.Heap;
using DataStructures.Shared;

namespace Apps
{
    public class HeapExamples
    {
        public static void MinHeapExample_01()
        {
            Console.WriteLine("\n*MinHeapExample_01\n");

            var minHeap = new BinaryHeap<int>(SortDirection.Ascending,
                                              new int[] { 54, 45, 36, 27, 29, 18, 21, 99 });

            Console.WriteLine("All elements in the heap: ");
            foreach (var item in minHeap)
            {
                Console.Write(item + " ");
            }

            minHeap.DeleteMinMax();

            Console.WriteLine("\nAfter min value deleted: ");
            foreach (var item in minHeap)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nMinHeapExample_01*\n");
        }

        public static void MinHeapExample_02()
        {
            Console.WriteLine("\n*MinHeapExample_02\n");

            var minHeap = new MinHeap<int>(new int[]{ 54, 45, 36, 27, 29, 18, 21, 99 });

            Console.WriteLine("All elements in the heap: ");
            foreach (var item in minHeap)
            {
                Console.Write(item + " ");
            }

            minHeap.DeleteMinMax();

            Console.WriteLine("\nAfter min value deleted: ");
            foreach (var item in minHeap)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nMinHeapExample_02*\n");
        }

        public static void MaxHeapExample_01()
        {
            Console.WriteLine("\n*MaxHeapExample_01\n");

            var maxHeap = new BinaryHeap<int>(SortDirection.Descending,
                                              new int[] { 54, 45, 36, 27, 29, 18, 21, 99 });

            Console.WriteLine("All elements in the heap: ");
            foreach (var item in maxHeap)
            {
                Console.Write(item + " ");
            }

            maxHeap.DeleteMinMax();

            Console.WriteLine("\nAfter max value deleted: ");
            foreach (var item in maxHeap)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nMaxHeapExample_01*\n");
        }

        public static void MaxHeapExample_02()
        {
            Console.WriteLine("\n*MaxHeapExample_02\n");

            var maxHeap = new MaxHeap<int>(new int[] { 54, 45, 36, 27, 29, 18, 21, 99 });

            Console.WriteLine("All elements in the heap: ");
            foreach (var item in maxHeap)
            {
                Console.Write(item + " ");
            }

            maxHeap.DeleteMinMax();

            Console.WriteLine("\nAfter max value deleted: ");
            foreach (var item in maxHeap)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nMaxHeapExample_02*\n");
        }
    }
}
