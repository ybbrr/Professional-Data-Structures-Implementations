using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataStructures.Tree.BinaryTree;

namespace DataStructures.Tree.BST
{
    public class BST<T> : IEnumerable<T> where T : IComparable<T> //Eğer bir type IComparable interface'inin içindeki
                                                               //CompareTo metoduna sahip değilse o type, bu class içinde kullanılamaz.
                                                               //T şeklinde yazılan Generic ifadeler ==, < , >, ... operatörleri ile karşılaştırılamaz
                                                               //Bu yüzden IComparable interface'nin sağladığı CompareTo'yu implemente eden
                                                               //type'lara ihtiyacım var.
                                                               //CopareTo'nun dönüş değerleri --> küçüklük durumu -1
                                                               //                             --> Eşitlik durumu 0
                                                               //                             --> Büyüklük durumu 1
    {

        public Node<T> Root { get; set; }
        public BST()
        {
            Root = null;
        }

        public BST(IEnumerable<T> collection) 
        {
            foreach (var item in collection) Add(item);
        }

        public void Add(T value)
        {
            if (value == null) throw new ArgumentNullException("value");

            var newNode = new Node<T>(value);

            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                var current = Root;
                Node<T> parent;
                while (true) //Ağaç sonsuza kadar uzuyormuş gibi düşünemceğim, uygun ekleme pozisyonunu bulunca döngüyü kıracağım.
                {
                    parent = current;
                    if (value.CompareTo(current.Value) < 0) //Sol alt ağaçtan mı ilerleyeceğim?
                    {
                        current = current.Left;
                        if(current == null)
                        {
                            parent.Left = newNode;
                            break;
                        }
                    }
                    else //Sağ alt ağaçran mı ilerleyeceğim?
                    {
                        current = current.Right;
                        if(current == null)
                        {
                            parent.Right = newNode;
                            break;
                        }
                    }
                }
            }
        }

        public Node<T> FindMin(Node<T> root)
        {
            if (root == null) throw new ArgumentNullException("root");

            var current = root;
            while (current.Left != null) current = current.Left;

            return current;
        }

        public Node<T> FindMax(Node<T> root)
        {
            if (root == null) throw new ArgumentNullException("root");

            var current = root;
            while (current.Right != null) current = current.Right;

            return current;
        }

        public Node<T> Find(Node<T> root, T key)
        {
            var current = root;

            while (key.CompareTo(current.Value) != 0) //CopareTo'nun dönüş değerleri 1.)küçüklük durumu -1 2.)Eşitlik durumu 0 3.)Büyüklük durumu 1
            {
                if (key.CompareTo(current.Value) < 0) //Sola gidiş//
                    current = current.Left;
                else //Sağa gidiş//
                    current = current.Right;

                if (current == null)
                    throw new Exception("Could not found!");
                    //return default(Node<T>); //Node<T>'nin default değerini de döndürebilirim. Ama programın diğer yerlerinde null olmadığını denetlerim.
            }

            return current;
        }

        public Node<T> Remove(Node<T> root, T key)
        {
            if (root == null) throw new ArgumentNullException("root");

            if (key.CompareTo(root.Value) < 0) //CopareTo'nun dönüş değerleri 1.)küçüklük durumu -1 2.)Eşitlik durumu 0 3.)Büyüklük durumu 1
            {
                root.Left = Remove(root.Left, key);
            }
            else if (key.CompareTo(root.Value) > 0)
            {
                root.Right = Remove(root.Right, key);
            }
            else //eşitlik durumu
            {
                //silme işlemi

                
                if (root.Left == null) //Tek çocuk ya da çocuksuz ise//
                {
                    return root.Right;
                }
                else if (root.Right == null)
                {
                    return root.Left;
                } //Tek çocuk ya da çocuksuz ise//

                // iki çocuk varsa //
                root.Value = FindMin(root.Right).Value;
                root.Right = Remove(root.Right, root.Value);

            }

            return root;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new BSTEnumerator<T>(Root);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
