using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图的结构
{
   public class AdjencyList<T> where T : class
    {

        private List<Vertex<T>> items;//图的顶点集合
        public AdjencyList()
            : this(10)
        {

        }
        public AdjencyList(int capacity)
        {
            this.items = new List<Vertex<T>>(10);
        }


        #region 基本方法
        //添加一个顶点
        public void AddVertex(T item)
        {
            if (Contains(item))
            {
                throw new ArgumentException("添加了重复顶点");
            }
            Vertex<T> newVertex = new Vertex<T>(item);
            items.Add(newVertex);
        }
        //添加一条无向边
        public void AddEdge(T from, T to)
        {
            Vertex<T> fromVertex = Find(from);
            if (fromVertex == null)
            {
                throw new ArgumentException();
            }
            Vertex<T> toVertex = Find(to);
            if (toVertex == null)
            {
                throw new ArgumentException();
            }
            AddDirectedEdge(fromVertex, toVertex);
            AddDirectedEdge(toVertex, fromVertex);
        }
        private void AddDirectedEdge(Vertex<T> fromVertex, Vertex<T> toVertex)
        {
            if (fromVertex.firstEdge == null)
            {
                fromVertex.firstEdge = new Node(toVertex);
            }
            else
            {
                Node temp = null;
                Node node = fromVertex.firstEdge;
                do
                {
                    //检查是否添加了重复边
                    if (node.adjvex.data.Equals(toVertex.data))
                    {
                        throw new ArgumentException("添加了重复边");
                    }
                    temp = node;
                    node = node.next;
                } while (node != null);
                Node newNode = new Node(toVertex);
                temp.next = newNode;
            }
        }
        //打印每个顶点和它的邻接点
        public string GetGraphInfo(bool isDirectedGraph = false)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Vertex<T> v in items)
            {
                sb.Append(v.data.ToString() + ":");
                if (v.firstEdge!=null)
                {
                    Node temp = v.firstEdge;
                    while (temp!=null)
                    {
                        if (isDirectedGraph)
                        {
                            sb.Append(v.data.ToString() + "->" + temp.adjvex.data.ToString() + " ");
                        }
                        else
                        {
                            sb.Append(temp.adjvex.data.ToString());
                        }
                        temp = temp.next;
                    }
                }
                sb.Append("\r\n");
            }
            return sb.ToString();
        }
        #endregion

        #region 辅助方法
        //查找图中是否包含某个元素
        private bool Contains(T item)
        {
            foreach (Vertex<T> v in items)
            {
                if (v.data.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }
        //查找指定项并返回
        private Vertex<T> Find(T item)
        {
            foreach (Vertex<T> v in items)
            {
                if (v.data.Equals(item))
                {
                    return v;
                }
            }
            return null;
        }
        #endregion

        #region 嵌套类
        //存放表头节点
        class Vertex<TValue>
        {
            public TValue data;
            public Node firstEdge;//邻接点表头指针
            public bool isVisited;//访问标志,遍历时使用
            public Vertex()
            {
                this.data = default(TValue);
            }
            public Vertex(TValue value)
            {
                this.data =  value;
            }

        }
        //存放链表中的表节点
        class Node
        {
            public Vertex<T> adjvex;
            public Node next;//下一个邻接点域
            public Node()
            {
                this.adjvex = null;
            }
            public Node(Vertex<T> value)
            {
                this.adjvex = value;
            }
        }
        #endregion
    }
}
