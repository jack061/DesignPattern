using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 二叉树的创建和遍历
{
    class Program
    {
        static void Main(string[] args)
        {
            MyBinaryTreeBasicTest();
        }

        static void MyBinaryTreeBasicTest()
        {
            //构造一颗二叉树,根节点为"A"
            MyBinaryTree<string> bTree = new MyBinaryTree<string>("A");
            Node<string> rootNode = bTree.Root;
            //向根节点"A"插入左孩子节点"B"和右孩子节点"C"
            bTree.InsertNodeLeft(rootNode, "B");
            bTree.InsertNodeRight(rootNode, "C");
            //向节点"B"插入左孩子节点"D"和右孩子节点"E"
            Node<string> nodeB = rootNode.lchild;
            bTree.InsertNodeLeft(nodeB, "D");
            bTree.InsertNodeRight(nodeB, "E");
            //向节点"CF
            Node<string> nodeC = rootNode.rchild;
            bTree.InsertNodeRight(nodeC, "F");
            //前序遍历
            Console.WriteLine("-------PreOrder-------");
            bTree.PreOrder(rootNode);
            //中序遍历
            Console.WriteLine("----------MidOrder---------");
            bTree.MidOrder(rootNode);
            //后序遍历
            Console.WriteLine("---------PostOrder----------");
            bTree.PostOrder(rootNode);
            //层序遍历
            Console.WriteLine("----------LevelOrder-----------");
            bTree.LevelOrder(rootNode);
            Console.ReadKey();
        }
    }
}
