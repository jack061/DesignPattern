using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 二叉树四则运算
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入四则运算表达式:");
            string constructor = Console.ReadLine();
            MyBinaryExprTree expTree = new MyBinaryExprTree(constructor);
            Console.WriteLine(expTree.GetResult());
            Console.ReadKey();
        }
    }
}
