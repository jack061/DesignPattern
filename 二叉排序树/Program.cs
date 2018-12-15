using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 二叉排序树
{
    class Program
    {
        static void Main(string[] args)
        {
            Node node = new Node(62);
            Node node2 = new Node(58);
            Node node3 = new Node(88);
            Node node4 = new Node(47);
            Node node5 = new Node(35);
            Node node6 = new Node(51);
            Node node7 = new Node(37);
            Node node8 = new Node(73);
            Node node9 = new Node(99);
            Node node10 = new Node(93);
            node.lchild = node2;
            node.rchild = node3;
            node2.lchild = node4;
            node4.lchild = node5;
            node4.rchild = node6;
            node5.lchild = node7;
            node3.lchild = node8;
            node3.rchild = node9;
            node9.lchild = node10;
            BSTree bs = new BSTree();
            Node pre = null;
            Node n = null;
            bool b = bs.Search(node, 1, pre, n);
            Console.WriteLine(b + "上一节点:");
            Console.ReadKey();
        }
    }
    class BSTree
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="T"> 根节点</param>
        /// <param name="key">查找的元素</param>
        /// <param name="pre">查找元素前一个节点的指针,初始值为null</param>
        /// <param name="n">返回真就把目标元素的指针指向n,返回假,就把f复制给p</param>
        /// <returns></returns>
        /// 
        public bool Search(Node T, int key, Node pre, Node n)
        {
            if (T == null)
            {
                n = pre;
                return false;
            }
            else if (key == T.Data)
            {
                n = T;
                return true;
            }
            else if (key < T.Data)
            {
                return Search(T.lchild, key, T, n);
            }
            else
            {
                return Search(T.rchild, key, T, n);
            }

        }
    }
    class Node
    {
        public int Data;
        public Node lchild { get; set; }
        public Node rchild { get; set; }

        public Node(int Data, Node lchild, Node rchild)
        {
            this.Data = Data;
            this.lchild = lchild;
            this.rchild = rchild;
        }
        public Node(int Data)
            : this(Data, null, null)
        {

        }
        public Node()
        {

        }
    }   
}
