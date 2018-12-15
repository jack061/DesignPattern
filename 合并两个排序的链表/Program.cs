using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 合并两个排序的链表
{
    class Program
    {
        //输入两个递增排序的链表，合并这两个链表并使新链表中的结点仍然是按照递增排序的。
        static void Main(string[] args)
        {
            Node node1 = new Node(1);
            Node node3 = new Node(3);
            Node node5 = new Node(5);
            node1.Next = node3;
            node3.Next = node5;
            Node node2 = new Node(2);
            Node node4 = new Node(4);
            Node node6 = new Node(6);
            node2.Next = node4;
            node4.Next = node6;
            Node newHead = Merge(node1, node2);
            Console.WriteLine(GetListString(newHead));
            Console.ReadKey();
        }
        //Step1.定义一个指向新链表的指针，暂且让它指向NULL；

        //Step2.比较两个链表的头结点，让较小的头结点作为新链表的头结点；

        //Step3.递归比较两个链表的其余节点，让较小的节点作为上一个新节点的后一个节点；
        public static Node Merge(Node head1, Node head2)
        {
            if (head1 == null)
            {
                return head2;
            }
            else if (head2 == null)
            {
                return head1;
            }
            Node newHead = null;
            if (head1.Data <= head2.Data)
            {
                newHead = head1;
                newHead.Next = Merge(head1.Next, head2);
            }
            else
            {
                newHead = head2;
                newHead.Next = Merge(head1, head2.Next);
            }
            return newHead;
        }
        public static string GetListString(Node head)
        {
            if (head == null)
            {
                return null;
            }

            StringBuilder sbList = new StringBuilder();
            while (head != null)
            {
                sbList.Append(head.Data.ToString());
                head = head.Next;
            }

            return sbList.ToString();
        }
    }
    public class Node
    {
        public int Data { get; set; }
        // 指向后一个节点
        public Node Next { get; set; }

        public Node(int data)
        {
            this.Data = data;
        }

        public Node(int data, Node next)
        {
            this.Data = data;
            this.Next = next;
        }
    }
}
