using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Stack
{
    public enum StackType
    {
        Array = 0,      //List<T>
        LinkedList = 1, //SinglyLinkedList<T>
    }
    public interface IStack<T> //Her bir Type için bu özellikleri implemente edeceğim.
    {
        int Count { get; }
        void Push(T value);
        T Pop();
        T Peek();
    }

    public class Stack_<T>
    {
        private readonly IStack<T> stack; //ReadOnly ifadeleri ancak ve ancak tanımlandığı yerde veya consturctor içinde başlatabiliriz.
        //Bir ifadeyi başlatmak o ifadeyi new'lemektir. Soyut olan bir şey new'lenemez. Soyut ifadenin concrate bir ifadeye bağlanması gerekir.
        //Alt sınıfları temsiz etmek üzere polymorphizm gereği bir interface tanımı bu şekilde kullanılabilir.

        public int Count => stack.Count;//Yukarıdaki enum içinde tanımladığım type'ların Count'u olur,
                                        //öyleyse Interface yapım(IStack<T>) sayesinde Count'u döndürürüm.

        public Stack_(StackType type = StackType.Array) //Kullanıcı bir type seçmezse Default olarak Array'i belirledim.
        {
            if (type == StackType.Array)
            {
                stack = new ArrayStack<T>();
            }
            else
            {
                stack = new LinkedListStack<T>();
            }
        }

        public void Push(T value)
        {
            stack.Push(value);
        }

        public T Pop()
        {
            return stack.Pop();
        }

        public T Peek()
        {
            return stack.Peek();
        }
    }
}
