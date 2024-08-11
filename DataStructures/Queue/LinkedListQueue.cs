//Benim Doubly Linked List'imin dizini
using DataStructures.LinkedList.DoublyLinkedList;

namespace DataStructures.Queue
{
    internal class LinkedListQueue<T> : IQueue<T>
    {
        private readonly DoublyLinkedList<T> list = new DoublyLinkedList<T>();
        public int Count { get; private set; }

        public void EnQueue(T value)
        {
            if (value == null) throw new ArgumentNullException("value");
            list.AddLast(value);
            Count++;
        }
        public T DeQueue()
        {
            if (Count == 0) throw new Exception("Queue is empty");
            var temp = list.RemoveFirst();
            Count--;
            return temp;
        }
        public T Peek() => Count == 0 ? throw new Exception("Queue is empty") : list.Head.Value;
        /*
        public T Peek()
        {
            if (Count == 0) throw new Exception("Queue is empty");
            return list.Head.Value;
        }
        */
    }
}