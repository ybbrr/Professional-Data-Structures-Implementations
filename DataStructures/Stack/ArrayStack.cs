using System.Collections.Generic;

namespace DataStructures.Stack
{
    public class ArrayStack<T> : IStack<T>
    {
        public int Count { get; private set; } //Dışarıya değer döndürebilir ama yazma işlemi sadece sınıf içinde yapılabilir.
        private readonly List<T> List = new List<T>();

        public void Push(T value)
        {
            if (value == null) throw new ArgumentNullException("value");
            List.Add(value);
            Count++;
        }
        public T Pop()
        {
            if (Count == 0) throw new Exception("Empty Stack");

            var temp = List[List.Count - 1];
            List.RemoveAt(List.Count - 1);
            Count--;

            return temp;
        }
        public T Peek()
        {
            if (Count == 0) throw new Exception("Empty Stack");

            return List[List.Count - 1];
        }
    }
}