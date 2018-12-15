using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 重建二叉树
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] preOrder = new int[] { 1, 2, 4, 7, 3, 5, 6, 8 };
            int[] inOrder = new int[] { 4, 7, 2, 1, 5, 3, 8, 6 };
            Node<int> node = Construct(preOrder, inOrder, 8);
            Console.WriteLine(node.data);
            Console.ReadKey();
        }
        public static Node<int> Construct(int[] preOrder, int[] inOrder, int length)
        {
            // 空指针判断
            if (preOrder == null || inOrder == null || length <= 0)
            {
                return null;
            }

            return ConstructCore(preOrder, 0, preOrder.Length - 1, inOrder, 0, inOrder.Length - 1);
        }

        public static Node<int> ConstructCore(int[] preOrder, int startPreOrder, int endPreOrder, int[] inOrder, int startInOrder, int endInOrder)
        {
            // 前序遍历序列的第一个数字是根结点的值
            int rootValue = preOrder[startPreOrder];
            Node<int> root = new Node<int>();
            root.data = rootValue;
            root.lchild = root.rchild = null;

            if (startPreOrder == endPreOrder)
            {
                if (startInOrder == endInOrder &&
                    preOrder[startPreOrder] == inOrder[startInOrder])
                {
                    return root;
                }
                else
                {
                    throw new Exception("Invalid input!");
                }
            }

            // 在中序遍历中找到根结点的值
            int rootInOrder = startInOrder;
            while (rootInOrder <= endInOrder && inOrder[rootInOrder] != rootValue)
            {
                rootInOrder++;
            }

            // 输入的两个序列不匹配的情况
            if (rootInOrder == endInOrder && inOrder[rootInOrder] != rootValue)
            {
                throw new Exception("Invalid input!");
            }
            int leftLength = rootInOrder - startInOrder;
            int leftPreOrderEnd = startPreOrder + leftLength;
            if (leftLength > 0)
            {
                // 构建左子树
                root.lchild = ConstructCore(preOrder, startPreOrder + 1, leftPreOrderEnd, inOrder, startInOrder, rootInOrder - 1);
            }
            if (leftLength < endPreOrder - startPreOrder)
            {
                // 构建右子树
                root.rchild = ConstructCore(preOrder, leftPreOrderEnd + 1, endPreOrder, inOrder, rootInOrder + 1, endInOrder);
            }

            return root;
        }
    }

    class Node<T> where T : struct
    {
        public int data { get; set; }
        public Node<T> lchild { get; set; }
        public Node<T> rchild { get; set; }
    }
}
