using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Benim Stack'imin dizini
using DataStructures.Stack;
//Benim Queue'mun dizini
using DataStructures.Queue;

namespace DataStructures.Tree.BinaryTree
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        public Node<T> Root { get; set; }
        public List<Node<T>> list { get; private set; }

        public BinaryTree()
        {
            list = new List<Node<T>>();
        }
        public List<Node<T>> InOrder(Node<T> root)
        {
            if (root != null)
            {
                InOrder(root.Left);
                list.Add(root); //Console.WriteLine(root);
                InOrder(root.Right);
            }

            return list;
        }
        public List<Node<T>> PreOrder(Node<T> root)
        {
            if (root != null)
            {
                list.Add(root); //Console.WriteLine(root);
                PreOrder(root.Left);
                PreOrder(root.Right);
            }

            return list;
        }

        public List<Node<T>> PostOrder(Node<T> root)
        {
            if (root != null)
            {
                PostOrder(root.Left);
                PostOrder(root.Right);
                list.Add(root); //Console.WriteLine(root);
            }

            return list;
        }
        public List<Node<T>> InOrderNonRecursiveTraversal(Node<T> root)
        {
            var listInOrder = new List<Node<T>>();
            var S = new Stack_<Node<T>>();
            Node<T> currentNode = root;
            bool done = false;
            while (!done)
            {
                if (currentNode != null)
                {
                    S.Push(currentNode);
                    currentNode = currentNode.Left;
                }
                else
                {
                    if (S.Count == 0)
                    {
                        done = true;
                    }
                    else
                    {
                        currentNode = S.Pop();
                        listInOrder.Add(currentNode);
                        currentNode = currentNode.Right;
                    }
                }
            }
            return listInOrder;
        }
        public List<Node<T>> PreOrderNonRecursiveTraversal(Node<T> root)
        {
            var listPreOrder = new List<Node<T>>();
            var S = new Stack_<Node<T>>();

            if (root == null) throw new Exception("Tree is empty.");

            S.Push(root);
            while (S.Count != 0)
            {
                var temp = S.Pop();
                listPreOrder.Add(temp);
                if (temp.Right != null) S.Push(temp.Right);
                if (temp.Left != null) S.Push(temp.Left);
            }
            return listPreOrder;
        }
        public List<Node<T>> PostOrderNonRecursiveTraversal(Node<T> root)
        {
            var listInOrder = new List<Node<T>>();
            var S = new Stack_<Node<T>>();
            Node<T> currentNode = root;
            bool done = false;
            while (!done)
            {
                if (currentNode != null)
                {
                    S.Push(currentNode);
                    S.Push(currentNode);
                    currentNode = currentNode.Left;
                }
                else
                {
                    if (S.Count == 0)
                    {
                        done = true;
                    }
                    else
                    {
                        currentNode = S.Pop();

                        if (S.Count != 0 && S.Peek().Value.Equals(currentNode.Value))
                        {
                            currentNode = currentNode.Right;
                        }
                        else
                        {
                            listInOrder.Add(currentNode);
                            currentNode = null;
                        }
                    }
                }
            }
            return listInOrder;
        }
        public List<Node<T>> LevelOrderNonRecursiveTraversal(Node<T> root)
        {
            var listLevelOrder = new List<Node<T>>();
            var Q = new Queue_<Node<T>>();
            Q.EnQueue(root);

            while (Q.Count > 0)
            {
                var temp = Q.DeQueue();
                listLevelOrder.Add(temp); 

                if (temp.Left != null) Q.EnQueue(temp.Left);
                if (temp.Right != null) Q.EnQueue(temp.Right);
            }

            return listLevelOrder;
        }

        public static int MaxDepth(Node<T> root)
        {
            if (root == null) return 0;

            int leftDepth = MaxDepth(root.Left);
            int rightDepth = MaxDepth(root.Right);

            return (leftDepth > rightDepth) ? leftDepth + 1 : rightDepth + 1;
        }

        public Node<T> DeepestNode(Node<T> root)
        {
            if (root == null) throw new Exception("Tree is empty.");

            Node<T> temp = null;

            var q = new Queue_<Node<T>>();

            q.EnQueue(root);

            while (q.Count > 0)
            {
                temp = q.DeQueue();

                if (temp.Left != null) q.EnQueue(temp.Left);
                if (temp.Right != null) q.EnQueue(temp.Right);
            }

            return temp;
        }

        public Node<T> DeepestNode() //alternatif bir çözüm ama hafızayı fazla kullanıyor.
        {
            var list = LevelOrderNonRecursiveTraversal(Root);

            return list[list.Count - 1];
        }
        public static int NumberOfLeafs(Node<T> root)
        {
            int count = 0;
            if (root == null) return count;

            var q = new Queue_<Node<T>>();
            q.EnQueue(root);
            while (q.Count > 0)
            {
                var temp = q.DeQueue();
                if (temp.Left == null && temp.Right == null) count++;
                if (temp.Left != null) q.EnQueue(temp.Left);
                if (temp.Right != null) q.EnQueue(temp.Right);
            }

            return count;

            /*
             Algoritmayı zaten yukarda çözdüm ama şöyle değişik bir alternatif yol göstermek istiyorum.
             LevelOrder sıralamadan dönen listemiz üzerinden LinQ sorgusu yaratarak da yaprak sayısını bulabilirim.
             LinQ'yu using System.Linq; ifadesi ile proje eklemeyi unutma.
             Bunun hafızayı kısa süreliğine de olsa israf ettiği aşikardır.
            
            return new BinaryTree<T>().LevelOrderNonRecursiveTraversal(root).Where(node => node.Left == null && node.Right==null).ToList().Count;
             */
        }
        public static int NumberOfFullNodes(Node<T> root)
        {
            int count = 0;
            if (root == null) return count;

            var q = new Queue_<Node<T>>();
            q.EnQueue(root);
            while (q.Count > 0)
            {
                var temp = q.DeQueue();
                if (temp.Left != null && temp.Right != null) count++;
                if (temp.Left != null) q.EnQueue(temp.Left);
                if (temp.Right != null) q.EnQueue(temp.Right);
            }

            return count;

            /*
             Algoritmayı zaten yukarda çözdüm ama şöyle değişik bir alternatif yol göstermek istiyorum.
             LevelOrder sıralamadan dönen listemiz üzerinden LinQ sorgusu yaratarak da yaprak sayısını bulabilirim.
             LinQ'yu using System.Linq; ifadesi ile proje eklemeyi unutma.
             Bunun hafızayı kısa süreliğine de olsa israf ettiği aşikardır.
            
            return new BinaryTree<T>().LevelOrderNonRecursiveTraversal(root).Where(node => node.Left != null && node.Right!=null).ToList().Count;
             */
        }
        public static int NumberOfHalfNodes(Node<T> root)
        {
            int count = 0;
            if (root == null) return count;

            var q = new Queue_<Node<T>>();
            q.EnQueue(root);
            while (q.Count > 0)
            {
                var temp = q.DeQueue();
                if (temp.Left != null && temp.Right == null) count++;
                if (temp.Left == null && temp.Right != null) count++;
                if (temp.Left != null) q.EnQueue(temp.Left);
                if (temp.Right != null) q.EnQueue(temp.Right);
            }

            return count;

            /*
             Algoritmayı zaten yukarda çözdüm ama şöyle değişik bir alternatif yol göstermek istiyorum.
             LevelOrder sıralamadan dönen listemiz üzerinden LinQ sorgusu yaratarak da yaprak sayısını bulabilirim.
             LinQ'yu using System.Linq; ifadesi ile proje eklemeyi unutma.
             Bunun hafızayı kısa süreliğine de olsa israf ettiği aşikardır.
            
            return new BinaryTree<T>().LevelOrderNonRecursiveTraversal(root).Where(node => (node.Left != null && node.Right == null) || (node.Left == null && node.Right != null)).ToList().Count;
             */
        }
        public void PrintPaths(Node<T> root)
        {
            var path = new T[256]; //Olabilecek en uzun yolun 256 tane düğümden oluşacağını söyledim.
            PrintPaths(root, path, 0);
        }

        private void PrintPaths(Node<T> root, T[] path, int pathLen)
        {
            if (root == null) return;

            path[pathLen++] = root.Value;

            if (root.Left == null && root.Right == null) //Bir yaprağın üzerindeysem.
            {
                PrintArray(path, pathLen);
            }
            else //Bir yaprağın üzerinde değilsem.
            {
                PrintPaths(root.Left, path, pathLen);
                PrintPaths(root.Right, path, pathLen);
            }
        }

        private void PrintArray(T[] path, int len)
        {
            for (int i = 0; i < len; i++)
                Console.Write($"{path[i]} --> ");

            Console.WriteLine();
        }

        public void ClearList() => list.Clear();
    }
}
