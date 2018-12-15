using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 二叉排序树创建
{
    class Program
    {
        static void Main(string[] args)
        {
            MyBinarySearchTreeTest();
        }
        static void MyBinarySearchTreeTest()
        {
            MyBinarySearchTree bst = new MyBinarySearchTree(8);
            bst.InsertNode(3);
            bst.InsertNode(10);
            bst.InsertNode(1);
            bst.InsertNode(6);
            bst.InsertNode(14);
            bst.InsertNode(4);
            bst.InsertNode(7);
            bst.InsertNode(13);
            bst.RemoveNode(7);
            Console.WriteLine("----------First LevelOrder----------");
            bst.MidOrder(bst.Root);
            Console.WriteLine();
            Console.ReadKey();

        }
    }
}
