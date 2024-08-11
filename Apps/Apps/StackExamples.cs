using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Benim Stack'imin dizini
using DataStructures.Stack;

namespace Apps
{
    public class StackExamples
    {
        public static void Pushing_Popping_Peeking_getting_Count()
        {
            var dummy_array = new char[] { 'a', 'b', 'c', 'd', 'e' };

            var my_stack1 = new Stack_<char>();
            var my_stack2 = new Stack_<char>(StackType.LinkedList);

            my_stack1.Push('f');
            my_stack1.Push('g');
            my_stack1.Push('h');

            my_stack2.Push('f');
            my_stack2.Push('g');
            my_stack2.Push('h');

            Console.WriteLine("The characters in my dummy array.");

            foreach (var c in dummy_array)
            {
                Console.Write(c + " ");
                my_stack1.Push(c);
                my_stack2.Push(c);
            }

            Console.WriteLine("\n\nPeek");
            Console.WriteLine($"Stack1: {my_stack1.Peek()}");
            Console.WriteLine($"Stack2: {my_stack2.Peek()}");

            Console.WriteLine("\nCount");
            Console.WriteLine($"Stack1: {my_stack1.Count}");
            Console.WriteLine($"Stack2: {my_stack2.Count}");

            Console.WriteLine("\nPop");
            Console.WriteLine($"Stack1: {my_stack1.Pop()} has been removed.");
            Console.WriteLine($"Stack2: {my_stack2.Pop()} has been removed.");

            Console.WriteLine("\nCount");
            Console.WriteLine($"Stack1: {my_stack1.Count}");
            Console.WriteLine($"Stack2: {my_stack2.Count}");
        }
    }
}
