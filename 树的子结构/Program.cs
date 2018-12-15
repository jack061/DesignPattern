using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 树的子结构
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTreeNode nodeA1 = new BinaryTreeNode(8);
            BinaryTreeNode nodeA2 = new BinaryTreeNode(8);
            BinaryTreeNode nodeA3 = new BinaryTreeNode(7);
            BinaryTreeNode nodeA4 = new BinaryTreeNode(9);
            BinaryTreeNode nodeA5 = new BinaryTreeNode(2);
            BinaryTreeNode nodeA6 = new BinaryTreeNode(4);
            BinaryTreeNode nodeA7 = new BinaryTreeNode(7);

            SetSubTreeNode(nodeA1, nodeA2, nodeA3);
            SetSubTreeNode(nodeA2, nodeA4, nodeA5);
            SetSubTreeNode(nodeA5, nodeA6, nodeA7);

            BinaryTreeNode nodeB1 = new BinaryTreeNode(8);
            BinaryTreeNode nodeB2 = new BinaryTreeNode(9);
            BinaryTreeNode nodeB3 = new BinaryTreeNode(2);

            SetSubTreeNode(nodeB1, nodeB2, nodeB3);

            Console.WriteLine(HasSubTree(nodeA1,nodeB1));
            Console.ReadKey();
        }
        public static void SetSubTreeNode(BinaryTreeNode root, BinaryTreeNode lChild, BinaryTreeNode rChild)
        {
            if (root == null)
            {
                return;
            }

            root.leftChild = lChild;
            root.rightChild = rChild;
        }
        public static bool HasSubTree(BinaryTreeNode root1, BinaryTreeNode root2)
        {
           bool result = false;
            if (root1 != null && root2 != null)
            {
                result = DoesTreeHasTree2(root1, root2);
            }
            //从根节点的左子树开始匹配
            if (!result)
            {
                result = HasSubTree(root1.leftChild, root2);
            }
            //左子树匹配失败,右子树匹配
            if (!result)
            {
                result = HasSubTree(root1.rightChild, root2);
            }
            return result;
        }
        public static bool DoesTreeHasTree2(BinaryTreeNode root1, BinaryTreeNode root2)
        {
            if (root2 == null)
            {
                //root2以遍历结束,匹配成功
                return true;
            }
            if (root1 == null)
            {
                return false;
            }
            if (root1.Data != root2.Data)
            {
                return false;
            }
            return DoesTreeHasTree2(root1.leftChild, root2.leftChild) && DoesTreeHasTree2(root1.rightChild, root2.rightChild);
        }
    }
    public class BinaryTreeNode
    {
        public int Data { get; set; }
        public BinaryTreeNode leftChild { get; set; }
        public BinaryTreeNode rightChild { get; set; }
        public BinaryTreeNode(int Data)
        {
            this.Data = Data;
        }
        public BinaryTreeNode(int Data, BinaryTreeNode leftChild, BinaryTreeNode rightChild)
        {
            this.Data = Data;
            this.leftChild = leftChild;
            this.rightChild = rightChild;
        }

    }


}
