using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Benim Queue'mun dizini
using DataStructures.Queue;

namespace Apps
{
    public class QueueExamples
    {
        public static void QueueExample_01()
        {
            var numbers = new int[] { 10, 20, 30, 40, 50 };

            var q1 = new DataStructures.Queue.Queue_<int>();
            var q2 = new DataStructures.Queue.Queue_<int>(QueueType.LinkedList);

            foreach (var number in numbers)
            {
                Console.Write(number + " ");
                q1.EnQueue(number);
                q2.EnQueue(number);
            }

            Console.WriteLine("\n\nCount");
            Console.WriteLine($"Q1 : {q1.Count}");
            Console.WriteLine($"Q2 : {q2.Count}");

            Console.WriteLine("\n\nDeQueue");
            Console.WriteLine($"{q1.DeQueue()} has been removed from q1.");
            Console.WriteLine($"{q2.DeQueue()} has been removed from q2.");
            Console.WriteLine("\nCount after DeQueue");
            Console.WriteLine($"Q1 : {q1.Count}");
            Console.WriteLine($"Q2 : {q2.Count}");

            Console.WriteLine("\n\nPeek");
            Console.WriteLine($"Q1 : {q1.Peek()}");
            Console.WriteLine($"Q2 : {q2.Peek()}");
            Console.WriteLine("\nCount after Peek");
            Console.WriteLine($"Q1 : {q1.Count}");
            Console.WriteLine($"Q2 : {q2.Count}");
        }
    }
}
