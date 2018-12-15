using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 模拟栈线性存储
{
    class MyLinkStack<T>
    {
        private Node<T> first;
        private int index;
        public MyLinkStack()
        {
            this.first = null;
            this.index = 0;
        }
        //入栈
        public void Push(T item)
        {
            Node<T> oldNode = first;
            first = new Node<T>();
            first.Item = item;
            first.Next = oldNode;
            index++;
        }
        //出栈
        public T Pop()
        {
            T item = first.Item;
            first = first.Next;
            index--;
            return item;
        }
    }
}
