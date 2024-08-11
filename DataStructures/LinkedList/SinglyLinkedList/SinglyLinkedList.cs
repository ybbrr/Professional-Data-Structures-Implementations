using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        public SinglyLinkedListNode<T> Head { get; set; }
        private bool isHeadNull => Head == null ? true : false;

        public SinglyLinkedList()
        {
            Head = null;
        }

        public SinglyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection) //Collection'larda GetEnumerator() ifadesi vardır. Foreach kullanabilirim.
            {
                this.AddFirst(item);
            }
        }

        public SinglyLinkedList(ArrayList collection)
        {

            foreach (var item in collection)
            {
                this.AddFirst((T)item);
            }
        }

        public SinglyLinkedList(params T[] initial)
        {
            foreach (T item in initial)
            {
                this.AddFirst(item);
            }
        }
        public void AddFirst(T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);
            newNode.Next = Head;
            Head = newNode;
        }

        public void AddLast(T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);

            if (isHeadNull)
            {
                Head = newNode;
                return;
            }

            var current = Head;

            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = null;
        }

        public void AddAfter(SinglyLinkedListNode<T> refNode, T value)
        {
            if (refNode == null) throw new ArgumentNullException(nameof(refNode));

            if (isHeadNull)
            {
                AddFirst(value);
                return;
            }

            var newNode = new SinglyLinkedListNode<T>(value);
            var current = Head;

            while (current != null)
            {
                if (current.Equals(refNode))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }

            throw new ArgumentException("The reference node not in the linked list.");
        }

        public void AddAfter(SinglyLinkedListNode<T> refNode, SinglyLinkedListNode<T> newNode)
        {
            if (refNode == null) throw new ArgumentNullException(nameof(refNode));

            if (isHeadNull)
            {
                Head = newNode;
                return;
            }

            var current = Head;

            while (current != null)
            {
                if (current.Equals(refNode))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }

            throw new ArgumentException("The reference node not in the linked list.");
        }

        public void AddBefore(SinglyLinkedListNode<T> refNode, T value)
        {
            if (isHeadNull) throw new Exception("Linked List is empty!");

            if (value == null) throw new ArgumentNullException("value");

            if (refNode == null) throw new ArgumentNullException(nameof(refNode));

            if (refNode == Head)
            {
                AddFirst(value);
                return;
            }

            var newNode = new SinglyLinkedListNode<T>(value);
            var current = Head;

            while (current != null)
            {
                if (current.Next.Equals(refNode))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }

            throw new ArgumentException("The reference node not in the linked list.");
        }

        public void AddBefore(SinglyLinkedListNode<T> refNode, SinglyLinkedListNode<T> newNode)
        {
            if (isHeadNull) throw new Exception("Linked List is empty!");

            if (newNode == null) throw new ArgumentNullException(nameof(newNode));

            if (refNode == null) throw new ArgumentNullException(nameof(refNode));

            if (refNode == Head)
            {
                newNode.Next = Head;
                Head = newNode;
                return;
            }

            var current = Head;

            while (current != null)
            {
                if (current.Next.Equals(refNode))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }

            throw new ArgumentException("The reference node not in the linked list.");
        }

        public T RemoveFirst()
        {
            if (isHeadNull) throw new Exception("Underflow! Linked List is empty!");

            var firstValue = Head.Value;
            Head = Head.Next;

            return firstValue;
        }

        public T RemoveLast()
        {
            var current = Head;
            SinglyLinkedListNode<T> prev = null;
            while (current.Next != null)
            {
                prev = current;
                current = current.Next;
            }
            var lastValue = prev.Next.Value;
            prev.Next = null;

            return lastValue;
        }

        public void Remove(T value)
        {
            if (isHeadNull) throw new Exception("Underflow! Linked List is empty!");

            if (value == null) throw new ArgumentNullException("value");

            var current = Head;
            SinglyLinkedListNode<T> prev = null;

            do
            {
                if (current.Value.Equals(value)) //Generic programlama gereği değişkenleri T ile tanımladım.
                                                 //T ile tanımlanan değişkenlerin birbirine eşit olup olmadığı Equals metodu ile kontrol edilir.
                {
                    if (current.Next == null) //Bu şart oluşmuşsa sondaki düğüm silinmek isteniyordur.
                    {
                        //Bağıl liste tek elemanlı olabilir.
                        if (prev == null) //Silinmek istenen düğüm Head.
                        {
                            Head = null;
                            return;
                        }
                        else //Liste tek elemanlı değil ve son düğüm silinmek isteniyor.
                        {
                            prev.Next = null;
                            return;
                        }
                    }
                    else //Silinmek istenen düğüm son düğüm değilse.
                    {
                        if (prev == null) //Silinmek istenen düğüm Head.
                        {
                            Head = Head.Next;
                            return;
                        }
                        else //Silinmek istenen düğüm ara düğüm.
                        {
                            prev.Next = current.Next;
                            return;
                        }
                    }
                }

                prev = current;
                current = current.Next;

            } while (current != null);

            throw new ArgumentException("The value could not be found in the Linked List.");
        }

        public SinglyLinkedListNode<T> FindNode(T value)
        {
            if (isHeadNull) throw new Exception("The Linked List is empty!");

            if (value == null) throw new ArgumentNullException("value");

            var current = Head;

            while (current != null)
            {
                if (current.Value.Equals(value)) return current;
                current = current.Next;
            }

            throw new ArgumentException("The value could not be found in the Linked List.");
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
