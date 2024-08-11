using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Queue
{
    public enum QueueType
    {
        Array = 0,      // List<T>
        LinkedList = 1, // DoublyLinkedList<T>
    }

    public interface IQueue<T>
    {
        int Count { get; }
        void EnQueue(T value);
        T DeQueue();
        T Peek();
    }
    public class Queue_<T>
    {
        private readonly IQueue<T> queue;
        public int Count => queue.Count;
        public Queue_(QueueType type = QueueType.Array)
        {
            if (type == QueueType.Array) queue = new ArrayQueue<T>();
            else queue = new LinkedListQueue<T>();
        }

        public void EnQueue(T value)
        {
            queue.EnQueue(value);
        }

        public T DeQueue()
        {
            return queue.DeQueue();
        }

        public T Peek()
        {
            return queue.Peek();
        }
    }
}
