using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataStructures.Shared;

namespace DataStructures.Heap
{
    public class BinaryHeap<T> : IEnumerable<T> where T : IComparable
    {
        public T[] Array { get; private set; }
        private int position;
        public int Count { get; private set; }

        private readonly IComparer<T> comparer;
        private readonly bool isMax;

        public BinaryHeap()
        {
            Count = 0;
            Array = new T[128]; //Default size
            position = 0;
        }
        public BinaryHeap(int _size)
        {
            Count = 0;
            Array = new T[_size];
            position = 0;
        }

        public BinaryHeap(IEnumerable<T> collection)
        {
            Count = 0;
            Array = new T[collection.Count()]; //Default size
            position = 0;
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public BinaryHeap(SortDirection sortDirection, IEnumerable<T> initial, IComparer<T> comparer)
        {
            position = 0;
            Count = 0;

            this.isMax = sortDirection == SortDirection.Descending;
            if (comparer != null) this.comparer = new CustomComparer<T>(sortDirection, comparer);
            else this.comparer = new CustomComparer<T>(sortDirection, Comparer<T>.Default);

            if (initial != null)
            {
                var items = initial as T[] ?? initial.ToArray();
                //initial parametresi null değilse initial daki değerlere generic olarak bak ve
                //bu değerler bull değilse (?? kısmı) başlangış değerlerini diziye dönüştür.
                Array = new T[items.Count()];

                foreach (var item in items)
                {
                    Add(item);
                }
            }
            else
            {
                Array = new T[128];
            }
        }

        public BinaryHeap(SortDirection sortDirection = SortDirection.Ascending) : this(sortDirection, null, null) //Bu this ifadesi bir yukardaki yazdığımız contructor'a götürür.
        {

        }

        public BinaryHeap(SortDirection sortDirection, IEnumerable<T> initial) : this(sortDirection, initial, null) //Bu this ifadesi bir yukardaki yazdığımız contructor'a götürür.
        {

        }

        public BinaryHeap(SortDirection sortDirection, IComparer<T> comparer) : this(sortDirection, null, comparer) //Bu this ifadesi bir yukardaki yazdığımız contructor'a götürür.
        {

        }

        private int GetLeftChildIndex(int i) => 2 * i + 1;
        private int GetRightChildIndex(int i) => 2 * i + 2;
        private int GetParentIndex(int i) => (i - 1) / 2;

        private bool HasLeftChild(int i) => GetLeftChildIndex(i) < position; //Burası bir karşılaştırma ifadesidir, bu ifadeye göre true ya da false döner.
        private bool HasRightChild(int i) => GetRightChildIndex(i) < position;
        private bool IsRoot(int i) => i == 0;

        private T GetLeftChild(int i) => Array[GetLeftChildIndex(i)];
        //i parametresine verilen indis değeri bulunmuyor olabilir bunun için bir kontrol ifadesi ekleyebilirsin.
        private T GetRightChild(int i) => Array[GetRightChildIndex(i)];
        private T GetParent(int i) => Array[GetParentIndex(i)];

        public bool IsEmpty() => position == 0;

        public T Peek()
        {
            if (IsEmpty()) throw new Exception("Empty Heap!");

            return Array[0];
        }

        public void Swap(int first, int second)
        {
            var temp = Array[first];
            Array[first] = Array[second];
            Array[second] = temp;
        }

        public void Add(T value)
        {
            if (position == Array.Length) throw new IndexOutOfRangeException("Overflow");
            Array[position++] = value;
            Count++;
            HeapifyUp();
        }

        public T DeleteMinMax()
        {
            if (position == 0) throw new IndexOutOfRangeException("Underflow");
            var temp = Array[0];
            Array[0] = Array[position - 1];
            position--;
            Count--;
            HeapifyDown();
            return temp;
        }
        protected void HeapifyDown()
        {
            int index = 0;

            while (HasLeftChild(index)) //Complete Tree üzerinde hareket ettiğimi için hep sola bakarak ilerleyeceğim.
            {
                var smallerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && comparer.Compare(GetRightChild(index), GetLeftChild(index)) < 0)//CopareTo'nun dönüş değerleri 1.)küçüklük durumu -1 2.)Eşitlik durumu 0 3.)Büyüklük durumu 1
                {
                    smallerIndex = GetRightChildIndex(index);
                }

                if (comparer.Compare(Array[smallerIndex], Array[index]) >= 0) //CopareTo'nun dönüş değerleri 1.)küçüklük durumu -1 2.)Eşitlik durumu 0 3.)Büyüklük durumu 1
                {
                    break;
                }

                Swap(smallerIndex, index);
                index = smallerIndex;
            }
        }

        protected void HeapifyUp()
        {
            var index = position - 1;
            while (!IsRoot(index) && comparer.Compare(Array[index], GetParent(index)) < 0)
            {
                var parentIndex = GetParentIndex(index);
                Swap(parentIndex, index);
                index = parentIndex;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Array.Take(position).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
