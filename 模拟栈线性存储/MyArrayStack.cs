using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 模拟栈线性存储
{
    class MyArrayStack<T>
    {
        private T[] nodes;
        private int index;
        public MyArrayStack(int capacity)
        {
            this.nodes = new T[capacity];
            this.index = 0;
        }
        //入栈
        public void Push(T node)
        {
            if (index==nodes.Length)
            {
                //扩容
                ResizeCapacity(nodes.Length * 2);
            }
            nodes[index] = node;
            index++;
        }
        //出栈
        public T pop()
        {
            if (index==0)
            {
                return default(T);
            }
            T node = nodes[index - 1];
            index--;
            nodes[index] = default(T);
            if (index>0&&index==nodes.Length/4)
            {
                //缩小容量
                ResizeCapacity(nodes.Length / 2);
            }
            return node;
        }
        //重置数组大小
        private void ResizeCapacity(int newCapacity)
        {
            T[] newNodes = new T[newCapacity];
            if (newCapacity > nodes.Length)
            {
                for (int i = 0; i < nodes.Length; i++)
                {
                    newNodes[i] = nodes[i];
                }
            }
            else
            {
                for (int i = 0; i < newNodes.Length; i++)
                {
                    newNodes[i] = nodes[i];
                }
            }
            nodes = newNodes;
        }
        //栈是否为空
        public bool isEmpty()
        {
            return this.index == 0;
        }
        //栈中节点个数
        public int Size
        {
            get
            {
                return this.index;
            }
        }
    }
}
