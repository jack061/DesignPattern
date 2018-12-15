using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 在O_1_时间删除链表结点
{
    class Program
    {
        //给定单向链表的头指针和一个结点指针，定义一个函数在O(1)时间删除该结点。
        static void Main(string[] args)
        {
        }
        #region old
        ////把下一个结点的内容复制到需要删除的结点上覆盖原有的内容，再把下一个结点删除，就相当于把当前需要删除的结点删除了。
        //public static void DeleteNode(Node<int> headNode, Node<int> deleteNode)
        //{
        //    if (headNode == null || deleteNode == null)
        //    {
        //        return;
        //    }

        //    if (deleteNode.Next != null) // 链表有多个节点，要删除的不是尾节点:O(1)时间
        //    {
        //        Node<int> tempNode = deleteNode.Next;
        //        deleteNode.Item = tempNode.Item;
        //        deleteNode.Next = tempNode.Next;

        //        tempNode = null;
        //    }
        //    else if (headNode == deleteNode) // 链表只有一个结点，删除头结点（也是尾结点）:O(1)时间
        //    {
        //        deleteNode = null;
        //        headNode = null;
        //    }
        //    else // 链表有多个节点，要删除的是尾节点:O(n)时间
        //    {
        //        Node<int> tempNode = headNode;
        //        while (tempNode.Next != deleteNode)
        //        {
        //            tempNode = tempNode.Next;
        //        }

        //        tempNode.Next = null;
        //        deleteNode = null;
        //    }
        //} 
        #endregion

        //把下一个结点的内容复制到需要删除的结点上覆盖原有的内容，再把下一个结点删除，就相当于把当前需要删除的结点删除了。
        public static void DeleteNode(Node<int> headNode, Node<int> deleteNode)
        {
            // 链表有多个节点，要删除的不是尾节点:O(1)时间
            if (deleteNode.Next != null)
            {
                Node<int> tempNode = deleteNode.Next;
                deleteNode.Item = tempNode.Item;
                deleteNode.Next = tempNode.Next;
                tempNode = null;
            }
            // 链表只有一个结点，删除头结点（也是尾结点）:O(1)时间
            else if (headNode == deleteNode)
            {
                headNode = null;
                deleteNode = null;
            }
            // 链表有多个节点，要删除的是尾节点:O(n)时间
            else
            {
                while (headNode.Next != deleteNode)
                {
                    headNode = headNode.Next;
                }
                headNode.Next = null;
                deleteNode = null;
            }
        }

    }
    class Node<T>
    {
        public T Item { get; set; }
        public Node<T> Next { get; set; }
        public Node(T item)
        {
            this.Item = item;
        }
        public Node(T item, Node<T> Next)
        {
            this.Item = item;
            this.Next = Next;
        }
    }
}
