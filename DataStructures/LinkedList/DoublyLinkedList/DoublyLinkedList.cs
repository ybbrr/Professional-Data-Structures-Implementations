using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.DoublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable
    {
        public DoublyLinkedListNode<T> Head { get; set; }
        public DoublyLinkedListNode<T> Tail { get; set; }
        private bool isHeadNull => Head == null ? true : false;
        private bool isTailNull => Tail == null ? true : false;
        public DoublyLinkedList()
        {
            Head = null;
        }

        public DoublyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                AddFirst(item);
            }
        }

        public void AddFirst(T value)
        {
            var newNode = new DoublyLinkedListNode<T>(value);

            if (Head != null)
            {
                Head.Prev = newNode;
            }

            newNode.Next = Head;
            newNode.Prev = null;
            Head = newNode;

            if (Tail == null)
            {
                Tail = Head;
            }
        }

        public void AddLast(T value)
        {
            if (Tail == null) //Linked List tamamen boşsa.
            {
                AddFirst(value);
                return;
            }

            var newNode = new DoublyLinkedListNode<T>(value);
            Tail.Next = newNode;
            newNode.Next = null;
            newNode.Prev = Tail;
            Tail = newNode;
        }

        public void AddAfter(DoublyLinkedListNode<T> refNode, DoublyLinkedListNode<T> newNode)
        {
            if (refNode == null) throw new ArgumentNullException(nameof(refNode));

            if (newNode == null) throw new ArgumentNullException(nameof(newNode));

            if (refNode == Head && newNode == Tail) //Linked List'te tek düğüm varsa
            {
                Head.Next = newNode;
                //Head.Prev = null;

                newNode.Prev = Head;
                newNode.Next = null;

                Tail = newNode;
                return;
            }

            if (refNode != Tail) //Linked List'te birden fazla düğüm varsa
            {
                newNode.Prev = refNode;
                newNode.Next = refNode.Next;

                refNode.Next.Prev = newNode;
                refNode.Next = newNode;
                return;
            }
            else //Son düğümün sonrasına ekliyorsak.
            {
                newNode.Prev = refNode;
                newNode.Next = null;

                refNode.Next = newNode;
                Tail = newNode;
            }
        }

        public void AddBefore(DoublyLinkedListNode<T> refNode, DoublyLinkedListNode<T> newNode)
        {
            throw new NotImplementedException(); //Bunu yap
        }

        public T RemoveFirst()
        {
            if (isHeadNull) throw new Exception("Underflow! Linked List is empty!");

            var temp = Head.Value;

            if (Head == Tail) //Linked List'te tek düğüm var.
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Head = Head.Next;
                Head.Prev = null;
            }

            return temp;
        }

        public T RemoveLast()
        {
            if (isTailNull) throw new Exception("Underflow! Linked List is empty!");

            var temp = Tail.Value;

            if (Head == Tail) //Linked List'te tek düğüm var.
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail.Prev.Next = null;
                Tail = Tail.Prev;
            }

            return temp;
        }

        public void Remove(T value)
        {
            if (isHeadNull) throw new Exception("Underflow! Linked List is empty!");

            if (Head == Tail) //Liste tek elemanlı.
            {
                if (Head.Value.Equals(value)) RemoveFirst();
                return;
            }

            var current = Head;

            while (current != null) //Linked List'te birden fazla eleman var.
            {
                if (current.Value.Equals(value))
                {
                    if (current.Prev == null) //Listenin başındayız.
                    {
                        current.Next.Prev = null;
                        Head = current.Next;
                    }
                    else if (current.Next == null) //Listenin sonundayız.
                    {
                        current.Prev.Next = null;
                        Tail = current.Prev;
                    }
                    else //Listenin aradaki elemanlarında.
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                    }
                    break;
                }
                current = current.Next;
            }
        }

        

        private List<DoublyLinkedListNode<T>> GetAllNodes()
        {
            var list = new List<DoublyLinkedListNode<T>>();

            var current = Head;

            while (current != null)
            {
                list.Add(current);
                current = current.Next;
            }
            return list;
        }

        public IEnumerator GetEnumerator()
        {
            return GetAllNodes().GetEnumerator();
        }
    }
}
