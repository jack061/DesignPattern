using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 反转链表
{
    class Program
    {
        static void Main(string[] args)
        {
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);
            Node node5 = new Node(5);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;

            Node newhead = ReverseList2(node1);
            Console.WriteLine(GetNodeString(newhead));
            Console.ReadKey();
        }

        public static Node ReverseList1(Node head)
        {
            if (head == null)
            {
                return null;
            }

            List<Node> nodeList = new List<Node>();
            while (head != null)
            {
                nodeList.Add(head);
                head = head.Next;
            }

            int startIndex = nodeList.Count - 1;
            for (int i = startIndex; i >= 0; i--)
            {
                Node node = nodeList[i];
                if (i == 0)
                {
                    node.Next = null;
                }
                else
                {
                    node.Next = nodeList[i - 1];
                }
            }
            // 现在头结点是原来的尾节点
            head = nodeList[startIndex];
            return head;
        }

        //定义3个指针，分别指向当前遍历到的结点、它的前一个结点及后一个结点。在遍历过程中，首先记录当前节点的后一个节点，然后将当前节点的后一个节点指向前一个节点，其次前一个节点再指向当前节点，最后再将当前节点指向最初记录的后一个节点，如此反复，直到当前节点的后一个节点为NULL时，则代表当前节点时反转后的头结点了。
        //整个过程只需遍历链表一次，效率提高不少，且需要的外部空间也较第一种方法要少很多
        public static Node ReverseList2(Node head)
        {
            if (head == null)
            {
                return null;
            }

            Node reverseHead = null;
            // 指针1：当前节点
            Node currentNode = head;
            // 指针2：当前节点的前一个节点
            Node prevNode = null;

            while (currentNode != null)
            {
                // 指针3：当前节点的后一个节点
                 Node nextNode = currentNode.Next;
                if (nextNode == null)
                {
                    reverseHead = currentNode;
                }
                // 将当前节点的后一个节点指向前一个节点
                currentNode.Next = prevNode;
                // 将前一个节点指向当前节点
                prevNode = currentNode;
                // 将当前节点指向后一个节点
                currentNode = nextNode;
                
            }

            return reverseHead;
        }

        public static string GetNodeString(Node head)
        {
            if (head == null)
            {
                return null;
            }
            StringBuilder sbResult = new StringBuilder();
            Node temp = head;
            while (head != null)
            {
                sbResult.Append(head.Data.ToString());
                head = head.Next;
            }
            return sbResult.ToString();

        }
    }
    class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }

        public Node(int Data)
        {
            this.Data = Data;
        }
        public Node(int Data, Node Next)
        {
            this.Data = Data;
            this.Next = Next;
        }
    }
}
