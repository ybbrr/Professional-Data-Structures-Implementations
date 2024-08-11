using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Benim Linked List'imin dizini
using DataStructures.LinkedList.SinglyLinkedList;

namespace Apps
{
    public class LinkedListExamples
    {

        public static void Addding_Value_to_my_Linked_List()
        {
            var my_linkedList = new SinglyLinkedList<int>(11, 22, 33, 44);

            Console.WriteLine("\nThe values that has been already in the Linked List.\n");

            foreach (var item in my_linkedList)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n\nThe value 55 was added before value 44 in the Linked List.\n");

            my_linkedList.AddBefore(my_linkedList.FindNode(44), 55);

            foreach (var item in my_linkedList)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n\nThe value 234 was added before value 11 in the Linked List.\n");

            my_linkedList.AddBefore(my_linkedList.FindNode(11), 234);

            foreach (var item in my_linkedList)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n\nThe value 66 was added after value 22 in the Linked List.\n");

            my_linkedList.AddAfter(my_linkedList.FindNode(22), 66);

            foreach (var item in my_linkedList)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n\nThe value 999 was added after value 11 in the Linked List.\n");

            my_linkedList.AddAfter(my_linkedList.FindNode(11), 999);

            foreach (var item in my_linkedList)
            {
                Console.Write(item + " ");
            }
        }
        public static void Addding_Node_to_my_Linked_List()
        {
            var my_linkedList = new SinglyLinkedList<int>(11, 22, 33, 44);

            Console.WriteLine("\nThe nodes that has been already in the Linked List.\n");

            foreach (var item in my_linkedList)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n\nThe node with value 55 was added before value 44 in the Linked List.\n");

            var newNode = new SinglyLinkedListNode<int>(55);

            my_linkedList.AddBefore(my_linkedList.FindNode(44), newNode);

            foreach (var item in my_linkedList)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n\nThe node with value 234 was added before value 11 in the Linked List.\n");

            var newNode2 = new SinglyLinkedListNode<int>(234);

            my_linkedList.AddBefore(my_linkedList.FindNode(11), newNode2);

            foreach (var item in my_linkedList)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n\nThe node with value 66 was added after value 22 in the Linked List.\n");

            var newNode3 = new SinglyLinkedListNode<int>(66);

            my_linkedList.AddAfter(my_linkedList.FindNode(22), newNode3);

            foreach (var item in my_linkedList)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n\nThe node with value 999 was added after value 11 in the Linked List.\n");

            var newNode4 = new SinglyLinkedListNode<int>(999);

            my_linkedList.AddAfter(my_linkedList.FindNode(11), newNode4);

            foreach (var item in my_linkedList)
            {
                Console.Write(item + " ");
            }
        }

        public static void Different_Constructor_Designs_for_my_Linked_List()
        {
            int[] arr = new int[]{ 1, 2, 3 };
            var arrList = new ArrayList(arr);
            var list = new List<int>(arr);
            var linkedList = new LinkedList<int>(arr);

            var my_linkedList = new SinglyLinkedList<int>(arr);

            Console.WriteLine("\nInteger Array Passed as Argument to the Constructor.\n");

            my_linkedList.AddFirst(55);
            my_linkedList.AddFirst(44);

            foreach (var item in my_linkedList)
            {
                Console.Write(item + " ");
            }

            my_linkedList = new SinglyLinkedList<int>(arrList);

            Console.WriteLine("\n\nArrayList Passed as Argument to the Constructor.\n");

            my_linkedList.AddFirst(55);
            my_linkedList.AddFirst(44);

            foreach (var item in my_linkedList)
            {
                Console.Write(item + " ");
            }

            my_linkedList = new SinglyLinkedList<int>(list);

            Console.WriteLine("\n\nGeneric int List Passed as Argument to the Constructor.\n");

            my_linkedList.AddFirst(55);
            my_linkedList.AddFirst(44);

            foreach (var item in my_linkedList)
            {
                Console.Write(item + " ");
            }


            my_linkedList = new SinglyLinkedList<int>(linkedList);

            Console.WriteLine("\n\nGeneric int Linked List Passed as Argument to the Constructor.\n");

            my_linkedList.AddFirst(55);
            my_linkedList.AddFirst(44);

            foreach (var item in my_linkedList)
            {
                Console.Write(item + " ");
            }

            my_linkedList.AddFirst(11);
            my_linkedList.AddFirst(22);
            my_linkedList.AddFirst(33);
            my_linkedList.AddFirst(44);
        }

        public static void LinQ_with_my_Linked_List()
        {
            var rnd = new Random();
            var initial = Enumerable.Range(1, 10).OrderBy(x => rnd.Next()).ToList();
            //Lamda expression. x'in bir örneğini aldım, her bir x ifadesi için random bir sayı dönecek.

            var my_linkedList = new SinglyLinkedList<int>(initial);

            var q = from item in my_linkedList
                    where item % 2 == 1
                    select item;
            //Bu sorgu LinkedList'imin içinden tek sayıları döndürecek.

            my_linkedList.AddFirst(11);
            my_linkedList.AddFirst(22);
            my_linkedList.AddFirst(33);
            my_linkedList.AddFirst(44);

            Console.WriteLine("\nThe Result of the LinQ Query is below.\n" +
                "Odd numbers query.\n");

            foreach (var item in q)
            {
                Console.Write(item + " ");
            }

            //my_linkedList.Where(x => x % 2 == 1).ToList().ForEach(x => Console.Write(x + " "));
            //Yukarıdaki Sorgunun ve Foreach'in aynısı.
        }

        public static void RemoveFirst_Feature()
        {
            var rnd = new Random();
            var initial = Enumerable.Range(1, 5).OrderBy(x => rnd.Next()).ToList();
            //Lamda expression. x'in bir örneğini aldım, her bir x ifadesi için random bir sayı dönecek.

            var my_linkedList = new SinglyLinkedList<int>(initial);

            my_linkedList.AddFirst(11);
            my_linkedList.AddFirst(22);
            my_linkedList.AddFirst(33);
            my_linkedList.AddFirst(44);

            foreach (var item in my_linkedList)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n\nFirst two node has been removed.\n");

            Console.WriteLine($"{my_linkedList.RemoveFirst()} removed from the Linked List.");
            Console.WriteLine($"{my_linkedList.RemoveFirst()} removed from the Linked List.\n");

            foreach (var item in my_linkedList)
            {
                Console.Write(item + " ");
            }
        }

        public static void RemoveLast_Feature()
        {
            var rnd = new Random();
            var initial = Enumerable.Range(1, 5).OrderBy(x => rnd.Next()).ToList();
            //Lamda expression. x'in bir örneğini aldım, her bir x ifadesi için random bir sayı dönecek.

            var my_linkedList = new SinglyLinkedList<int>(initial);

            my_linkedList.AddFirst(11);
            my_linkedList.AddFirst(22);
            my_linkedList.AddFirst(33);
            my_linkedList.AddFirst(44);

            foreach (var item in my_linkedList)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n\nLast two node has been removed.\n");

            Console.WriteLine($"{my_linkedList.RemoveLast()} removed from the Linked List.");
            Console.WriteLine($"{my_linkedList.RemoveLast()} removed from the Linked List.\n");

            foreach (var item in my_linkedList)
            {
                Console.Write(item + " ");
            }
        }

        public static void Remove_Implementation()
        {
            var my_linkedList = new SinglyLinkedList<int>(new int[] { 1, 2, 3, 4, 5, 6, 7 });

            my_linkedList.AddFirst(11);
            my_linkedList.AddFirst(22);
            my_linkedList.AddFirst(33);
            my_linkedList.AddFirst(44);

            foreach (var item in my_linkedList)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n\nThe node with value 33 has been removed.\n");
            my_linkedList.Remove(33);

            Console.WriteLine("The node with value 1 has been removed.(Last Node)\n");
            my_linkedList.Remove(1);

            Console.WriteLine("The node with value 44 has been removed.(First Node)\n");
            my_linkedList.Remove(44);

            foreach (var item in my_linkedList)
            {
                Console.Write(item + " ");
            }
        }
    }
}
