using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 二叉排序树创建
{
    class MyBinarySearchTree
    {
        //二叉树的根节点
        private Node root;
        public Node Root
        {
            get
            {
                return this.root;
            }
        }
        public MyBinarySearchTree()
        {

        }
        public MyBinarySearchTree(int data)
        {
            this.root = new Node(data);
        }
        #region 二叉排序树的创建和移除节点
        //判断二叉树是否为空树
        public bool IsEmpty()
        {
            return this.root == null;
        }
        //插入一个新节点
        public void InsertNode(int data)
        {
            #region old
            //Node newNode = new Node();
            //newNode.data = data;
            //if (this.root == null)
            //{
            //    root = newNode;
            //}
            //else
            //{
            //    Node currentNode = this.root;
            //    Node parentNode = null;
            //    while (currentNode != null)
            //    {
            //        parentNode = currentNode;
            //        if (currentNode.data < data)
            //        {
            //            currentNode = currentNode.rchild;
            //        }
            //        else
            //        {
            //            currentNode = currentNode.lchild;
            //        }

            //    }
            //    if (parentNode.data < data)
            //    {
            //        parentNode.rchild = newNode;
            //    }
            //    else
            //    {
            //        parentNode.lchild = newNode;
            //    }

            //} 
            #endregion

            Node newNode = new Node(data);
            if (this.root == null)
            {
                this.root = newNode;
            }
            else
            {
                Node currentNode = this.root;
                Node parentNode = null;
                while (currentNode != null)
                {
                    parentNode = currentNode;
                    if (currentNode.data < data)
                    {
                        currentNode = currentNode.rchild;
                    }
                    else
                    {
                        currentNode = currentNode.lchild;
                    }
                }
                if (parentNode.data < data)
                {
                    parentNode.rchild = newNode;
                }
                else
                {
                    parentNode.lchild = newNode;
                }


            }
        }
        //移除一个旧节点
        public void RemoveNode(int key)
        {
            Node current = null, parent = null;
            //定位节点的位置
            current = FindNode(key);
            parent = FindParentNode(key);
            if (current == null)
            {
                Console.WriteLine("没有找到节点");
                return;
            }
            #region 叶子节点
            if (current.lchild == null && current.rchild == null)
            {
                if (current == this.root)
                {
                    this.root = null;
                }
                else if (parent.lchild == current)
                {
                    parent.lchild = null;
                }
                else if (parent.rchild == current)
                {
                    parent.rchild = null;
                }

            }


            #endregion

            #region 单支节点
            else if (current.lchild == null || current.rchild == null)
            {
                //该节点为根节点
                if (current == this.root)
                {
                    if (current.lchild == null)
                    {
                        this.root = current.rchild;
                    }
                    else
                    {
                        this.root = current.lchild;
                    }
                }
                else
                {
                    if (parent.lchild == current && current.lchild != null)
                    {
                        parent.lchild = current.lchild;
                    }
                    else if (parent.lchild == current && current.rchild != null)
                    {
                        parent.lchild = current.rchild;
                    }
                    else if (parent.rchild == current && current.lchild != null)
                    {
                        parent.rchild = current.lchild;
                    }
                    else if (parent.rchild==current&&current.rchild!=null)
                    {
                        parent.rchild = current.rchild;
                    }
                }

            }
            #endregion

            #region 左右节点均不为空
            else // 如果该p节点的左右子树均不为空 
            {
                Node t = current;
                Node s = current.rchild; // 从p的右子节点开始 
                // 找到p的后继，即p右子树中值最小的节点 
                while (s.lchild != null)
                {
                    t = s;
                    s = s.lchild;
                }
                current.data = s.data; // 把节点s的值赋给p
                t.lchild = s.rchild;
            } 

            #endregion
        }
        //根据key查找某个节点
        public Node FindNode(int key)
        {
            Node currentNode = this.root;
            while (currentNode != null && currentNode.data != key)
            {

                if (currentNode.data < key)
                {
                    currentNode = currentNode.rchild;
                }
                else if (currentNode.data > key)
                {
                    currentNode = currentNode.lchild;
                }
                else
                {
                    break;
                }
            }
            return currentNode;

        }
        //获取父节点
        public Node FindParentNode(int key)
        {
            Node currentNode = this.root;
            Node parent = null;
            while (currentNode != null && currentNode.data != key)
            {
                parent = currentNode;
                if (currentNode.data < key)
                {
                    currentNode = currentNode.rchild;
                }
                else if (currentNode.data > key)
                {
                    currentNode = currentNode.lchild;
                }
                else
                {
                    break;
                }

            }
            return parent;
        }
        #endregion
        //嵌套类:节点
        public class Node
        {
            public int data { get; set; }
            public Node lchild { get; set; }
            public Node rchild { get; set; }
            public Node()
            {

            }
            public Node(int data)
            {
                this.data = data;
            }
            public Node(int data, Node lchild, Node rchild)
            {
                this.data = data;
                this.lchild = lchild;
                this.rchild = rchild;
            }
        }

        #region 遍历节点
        //层序遍历
        public void LevelOrder(Node node)
        {
            if (root == null)
            {
                return;
            }

            Queue<Node> queueNodes = new Queue<Node>();
            queueNodes.Enqueue(node);
            Node tempNode = null;
            // 利用队列先进先出的特性存储节点并输出
            while (queueNodes.Count > 0)
            {
                tempNode = queueNodes.Dequeue();
                Console.Write(tempNode.data + " ");

                if (tempNode.lchild != null)
                {
                    queueNodes.Enqueue(tempNode.lchild);
                }

                if (tempNode.rchild != null)
                {
                    queueNodes.Enqueue(tempNode.rchild);
                }
            }
        }
        //中序遍历
        public void MidOrder(Node node)
        {
            if (node != null)
            {
                MidOrder(node.lchild);
                Console.WriteLine(node.data);
                MidOrder(node.rchild);
            }
        }
        #endregion
    }
}
