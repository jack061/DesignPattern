using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 从上到下打印二叉树
{
    class Program
    {
        //从上往下打印出二叉树的每个结点，同一层的结点按照从左到右的顺序打印
        static void Main(string[] args)
        {
            BinaryTreeNode node5 = new BinaryTreeNode(5);
            BinaryTreeNode node4 = new BinaryTreeNode(4);
            BinaryTreeNode node3 = new BinaryTreeNode(3);
            BinaryTreeNode node2 = new BinaryTreeNode(2);
            BinaryTreeNode node1 = new BinaryTreeNode(1);
            node1.rightChild = node2;
            node2.rightChild = node3;
            node3.rightChild = node4;
            node4.rightChild = node5;

            PrintFromTopToBottom(node1);
            Console.ReadKey();

        }

        static void PrintFromTopToBottom(BinaryTreeNode root)
        {
            if (root == null)
            {
                return;
            }
            Queue<BinaryTreeNode> queue = new Queue<BinaryTreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                BinaryTreeNode node = queue.Dequeue();
                Console.WriteLine(node.Data + "");
                if (node.leftChild != null)
                {
                    queue.Enqueue(node.leftChild);
                }
                if (node.rightChild != null)
                {
                    queue.Enqueue(node.rightChild);
                }
            }
        }

    }
    class BinaryTreeNode
    {
        public int Data { get; set; }

        public BinaryTreeNode leftChild { get; set; }

        public BinaryTreeNode rightChild { get; set; }

        public BinaryTreeNode(int data)
        {
            this.Data = data;
        }
        public BinaryTreeNode(int data, BinaryTreeNode leftChild, BinaryTreeNode rightChild)
        {
            this.Data = data;
            this.leftChild = leftChild;
            this.rightChild = rightChild;
        }
    }
}
