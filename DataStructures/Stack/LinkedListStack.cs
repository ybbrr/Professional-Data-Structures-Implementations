
//Benim Singly Linked List'imin dizini
using DataStructures.LinkedList.SinglyLinkedList;

namespace DataStructures.Stack
{
    public class LinkedListStack<T> : IStack<T>
    {
        private readonly SinglyLinkedList<T> List = new SinglyLinkedList<T>();
        public int Count { get; private set; }

        public void Push(T value)
        {
            if (value == null) throw new ArgumentNullException("value");
            List.AddFirst(value);
            Count++;
        }
        public T Pop()
        {
            if (Count == 0) throw new Exception("Empty Stack");
            var temp = List.RemoveFirst();
            Count--;

            return temp;
        }
        public T Peek()
        {
            if (Count == 0) throw new Exception("Empty Stack");

            return List.Head.Value;
        }
    }
}