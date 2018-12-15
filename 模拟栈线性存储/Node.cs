using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 模拟栈线性存储
{
    class Node<T>
    {
        public T Item { get; set; }
        public Node<T> Next { get; set; }
        public Node(T item)
        {
            this.Item = item;
        }
        public Node()
        {

        }
    }
}
