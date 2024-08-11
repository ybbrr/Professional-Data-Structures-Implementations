using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using DataStructures.Tree.BST;
using DataStructures.Tree.BinaryTree;

namespace Apps
{
    internal class BinaryTreeExamples
    {
        public static void BinarySearchTreeExample_01()
        {
            var btt = new BST<char>();
            btt.Root = new Node<char>('F');
            btt.Root.Left = new Node<char>('A');
            btt.Root.Right = new Node<char>('T');
            btt.Root.Left.Left = new Node<char>('D');
            btt.Root.Left.Right = new Node<char>('Z');

            Console.WriteLine($"Max Depth : {BinaryTree<char>.MaxDepth(btt.Root)}");
            Console.WriteLine($"Leaf Number : {BinaryTree<char>.NumberOfLeafs(btt.Root)}");
            Console.WriteLine($"Full Node Number : {BinaryTree<char>.NumberOfFullNodes(btt.Root)}");
            Console.WriteLine($"Half Node Number : {BinaryTree<char>.NumberOfHalfNodes(btt.Root)}");

            Console.WriteLine("Enumerator kulalnılıyor.");

            foreach (var item in btt)
            {
                Console.WriteLine(item);
            }
        }

        public static void BinarySearchTreeExample_02()
        {
            var bst = new BST<byte>(new byte[] { 60, 40, 70, 20, 45, 65, 85, 90 });

            Console.WriteLine();
            new BinaryTree<byte>().InOrder(bst.Root).ForEach(node => Console.Write(node + " "));

            Console.WriteLine($"\nMin : {bst.FindMin(bst.Root)}");
            Console.WriteLine($"Max : {bst.FindMax(bst.Root)}");
            Console.WriteLine($"Depth : {BinaryTree<byte>.MaxDepth(bst.Root)}");
        }

        public static void BinarySearchTreeExample_03()
        {
            var BST = new BST<int>(new int[] { 60, 40, 70, 20, 45, 65, 85 });

            var bt = new BinaryTree<int>().InOrder(BST.Root);

            foreach (var node in bt)
            {
                Console.Write(node + " ");
            }

            //Yukarıdaki foreach ile aynı işi yapar.
            //new BinaryTree<int>().InOrder(BST.Root).ForEach(node => Console.Write(node + " "));
            Console.WriteLine();
            new BinaryTree<int>().InOrderNonRecursiveTraversal(BST.Root).ForEach(node => Console.Write(node + " "));

            Console.WriteLine();
            new BinaryTree<int>().PreOrder(BST.Root).ForEach(node => Console.Write(node + " "));

            Console.WriteLine();
            new BinaryTree<int>().PreOrderNonRecursiveTraversal(BST.Root).ForEach(node => Console.Write(node + " "));

            Console.WriteLine();
            new BinaryTree<int>().PostOrder(BST.Root).ForEach(node => Console.Write(node + " "));

            Console.WriteLine();
            new BinaryTree<int>().LevelOrderNonRecursiveTraversal(BST.Root).ForEach(node => Console.Write(node + " "));

            Console.WriteLine($"\nMinimum value : {BST.FindMin(BST.Root)}");
            Console.WriteLine($"Minimum value : {BST.FindMax(BST.Root)}");

            //var keyNode = BST.Find(BST.Root, 16);
            //Console.WriteLine($"Düğüm: {keyNode} -- Left: {keyNode.Left} -- Right: {keyNode.Right}");

            BST.Remove(BST.Root, 20);
            BST.Remove(BST.Root, 40);
            BST.Remove(BST.Root, 60);

            Console.WriteLine();
            new BinaryTree<int>().InOrder(BST.Root).ForEach(node => Console.Write(node + " "));
        }
    }
}
