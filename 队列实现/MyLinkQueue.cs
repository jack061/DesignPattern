using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 队列实现
{
    class MyLinkQueue<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int size;
        public MyLinkQueue()
        {
            this.head = null;
            this.tail = null;
            this.size = 0;
        }
        //入队
        public void EnQueue(T item)
        {
            Node<T> oldLastNode = tail;
            tail = new Node<T>();
            tail.Item = item;
            if (IsEmpty())
            {
                head = tail;
            }
            else
            {
                oldLastNode.Next = tail;
            }
            size++;
        }
        //出队
        public T DeQueue()
        {
            T result = head.Item;
            head = head.Next;
            size--;
            if (IsEmpty())
            {
                tail = null;
            }
            return result;

        }
        //是否为空队列
        public bool IsEmpty()
        {
            return this.size == 0;
        }
    }
}
