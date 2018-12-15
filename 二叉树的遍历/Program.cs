using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 二叉树的遍历
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> node = new Node<int>(62);
            Node<int> node2 = new Node<int>(58);
            Node<int> node3 = new Node<int>(88);
            Node<int> node4 = new Node<int>(47);
            Node<int> node5 = new Node<int>(35);
            Node<int> node6 = new Node<int>(51);
            Node<int> node7 = new Node<int>(37);
            Node<int> node8 = new Node<int>(73);
            Node<int> node9 = new Node<int>(99);
            Node<int> node10 = new Node<int>(93);
            node.lchild = node2;
            node.rchild = node3;
            node2.lchild = node4;
            node4.lchild = node5;
            node4.rchild = node6;
            node5.lchild = node7;
            node3.lchild = node8;
            node3.rchild = node9;
            node9.lchild = node10;
            node.PreOrderNoRecurise(node);
            Console.ReadKey();
        }
    }
    //二叉树结点定义
    class Node<T>
    {
        public T data;
        public Node<T> lchild { get; set; }
        public Node<T> rchild { get; set; }
        public Node(T data)
        {
            this.data = data;
        }
        public Node(T data, Node<T> lchild, Node<T> rchild)
        {
            this.data = data;
            this.lchild = lchild;
            this.rchild = rchild;
        }
        //在节点p下插入左孩子节点的data
        public void InsertLeft(Node<T> p, T data)
        {
            Node<T> tempNode = new Node<T>(data);
            p.lchild = tempNode;
        }
        //前序遍历
        public void PreOrder(Node<T> node)
        {
            if (node != null)
            {
                Console.WriteLine(node.data + " ");
                PreOrder(node.lchild);
                PreOrder(node.rchild);
            }
        }
        //中序遍历
        public void MinOrder(Node<T> node)
        {
            if (node != null)
            {
                MinOrder(node.lchild);
                Console.WriteLine(node.data + " ");
                MinOrder(node.rchild);
            }
        }
        //后序遍历
        public void PostOrder(Node<T> node)
        {
            if (node != null)
            {
                PostOrder(node.lchild);
                PostOrder(node.rchild);
                Console.WriteLine(node.data + " ");
            }
        }

        //前序遍历(循环非递归)
        // Method01:前序遍历
        public void PreOrderNoRecurise(Node<T> node)
        {
            if (node == null)
            {
                return;
            }
            // 根->左->右
            Stack<Node<T>> stack = new Stack<Node<T>>();
            stack.Push(node);
            Node<T> tempNode = null;

            while (stack.Count > 0)
            {
                // 1.遍历根节点
                tempNode = stack.Pop();
                Console.Write(tempNode.data);
                // 2.右子树压栈
                if (tempNode.rchild != null)
                {
                    stack.Push(tempNode.rchild);
                }
                // 3.左子树压栈(目的：保证下一个出栈的是左子树的节点)
                if (tempNode.lchild != null)
                {
                    stack.Push(tempNode.lchild);
                }
            }
        }

        //中序遍历(循环非递归)
        public void MidOrderNoRecurise(Node<T> node)
        {
            if (node == null)
            {
                return;
            }
            // 左->根->右
            Stack<Node<T>> stack = new Stack<Node<T>>();
            Node<T> tempNode = node;
            while (tempNode != null || stack.Count > 0)
            {
                // 1.依次将所有左子树节点压栈
                while (tempNode != null)
                {
                    stack.Push(tempNode);
                    tempNode = tempNode.lchild;
                }
                // 2.出栈遍历节点
                tempNode = stack.Pop();
                Console.Write(tempNode.data);
                // 3.左子树遍历结束则跳转到右子树
                tempNode = tempNode.rchild;
            }
        }
        


    }
}
