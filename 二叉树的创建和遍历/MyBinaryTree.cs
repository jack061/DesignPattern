using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 二叉树的创建和遍历
{
    class MyBinaryTree<T>
    {
        //二叉树的根节点
        private Node<T> root;
        public Node<T> Root
        {
            get
            {
                return root;
            }
        }
        public MyBinaryTree()
        {

        }
        public MyBinaryTree(T data)
        {
            root = new Node<T>(data);
        }
        #region 基本的创建和移除方法
        //判断二叉树是否为空属
        public bool IsEmpty()
        {
            return this.root == null;
        }
        //在节点p下插入左孩子节点的data
        public void InsertNodeLeft(Node<T> p, T data)
        {
            Node<T> tempNode = new Node<T>(data);
            p.lchild = tempNode;
        }
        //在节点p下插入右孩子节点的data
        public void InsertNodeRight(Node<T> p, T data)
        {
            Node<T> tempNode = new Node<T>(data);
            p.rchild = tempNode;
        }
        //删除p节点下的左子树
        public Node<T> RemoveLeft(Node<T> p)
        {
            if (p == null || p.lchild == null)
            {
                return null;
            }
            Node<T> tempNode = p.lchild;
            p.lchild = null;
            return tempNode;

        }
        //删除p节点下的右子树
        public Node<T> RemoveRight(Node<T> p)
        {
            if (p == null || p.rchild == null)
            {
                return null;
            }
            Node<T> tempNode = p.rchild;
            p.rchild = null;
            return tempNode;
        }
        //判断节点p是否为叶子节点
        public bool IsLeafNode(Node<T> p)
        {
            if (p == null)
            {
                return false;
            }
            return p.lchild == null && p.rchild == null;
        }
        #endregion

        #region 基本的递归遍历方法
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
        public void MidOrder(Node<T> node)
        {
            if (node != null)
            {
                MidOrder(node.lchild);
                Console.WriteLine(node.data + " ");
                MidOrder(node.rchild);
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

        #endregion

        #region 循环遍历非递归
        //前序遍历
        public void PreOrderNoRecurise(Node<T> node)
        {
            if (node == null)
            {
                return;
            }
            Stack<Node<T>> stack = new Stack<Node<T>>();
            stack.Push(node);
            Node<T> tempNode = null;
            while (stack.Count > 0)
            {
                //遍历根节点
                tempNode = stack.Pop();
                Console.WriteLine(tempNode.data);
                //右子树压栈
                if (tempNode.rchild != null)
                {
                    stack.Push(tempNode.rchild);
                }
                //左子树压栈
                if (tempNode.lchild != null)
                {
                    stack.Push(tempNode.lchild);
                }
            }
        }
        //层序遍历
        public void LevelOrder(Node<T> node)
        {
            if (node == null)
            {
                return;

            }
            Queue<Node<T>> queueNodes = new Queue<Node<T>>();
            queueNodes.Enqueue(node);
            Node<T> tempNode = null;
            while (queueNodes.Count > 0)
            {
                tempNode = queueNodes.Dequeue();
                Console.WriteLine(tempNode.data);
                if (tempNode.lchild != null)
                {
                    queueNodes.Enqueue(tempNode.lchild);
                }
                if (tempNode.rchild!=null)
                {
                    queueNodes.Enqueue(tempNode.rchild);
                }
            }
        }
        #endregion
    }
}
