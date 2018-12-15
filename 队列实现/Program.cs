using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 队列实现
{
    class Program
    {
        static void Main(string[] args)
        {
            MyArrayQueue<int> stack = new MyArrayQueue<int>(10);
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                stack.EnQueue(rand.Next(1, 10));
            }
            for (int i = 0; i < 9; i++)
            {
                int node = stack.DeQueue();
                Console.WriteLine(node + " ");
            }
            stack.EnQueue(23);
            Console.ReadKey();
        }
    }
}
