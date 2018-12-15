using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 模拟栈线性存储
{
    class Program
    {
        static void Main(string[] args)
        {
            StackWithArrayTest();
        }
        static void StackWithArrayTest()
        {
            MyLinkStack<int> stack = new MyLinkStack<int>();
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                stack.Push(rand.Next(1, 10));
            }
            for (int i = 0; i < 10; i++)
            {
                int node = stack.Pop();
                Console.WriteLine(node+" ");
            }
            Console.ReadKey();
        }
    }
}
