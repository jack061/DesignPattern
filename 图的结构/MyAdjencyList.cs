using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图的结构
{
    class MyAdjencyList<T> where T : class
    {
        public List<Vertex<T>> items;//图的顶点集合
        public MyAdjencyList(int capacity)
        {
            this.items = new List<Vertex<T>>(10);
        }
        public MyAdjencyList()
            : this(10)
        {

        }

        #region 基本方法
        //添加一个顶点
        public void AddVertex(T item)
        {
            if (IsContains(item))
            {
                throw new ArgumentException("不可添加重复顶点");
            }
            items.Add(new Vertex<T>(item));
        }
        //添加边
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
        public void AddDirectedEdge(Vertex<T> fromVertex, Vertex<T> toVertex)
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

        //打印每个顶点和邻接点
        public string GetGraphInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Vertex<T> v in items)
            {
                sb.Append(v.data.ToString() + ": ");
                if (v.firstEdge != null)
                {
                    Node temp = v.firstEdge;
                    while (temp!=null)
                    {
                        sb.Append(temp.adjvex.data.ToString());
                    
                        temp = temp.next;
                    }
                    sb.Append("\r\n");
                }
            }
            return sb.ToString();
        }
        #endregion

        #region 遍历
        //深度优先遍历
        public void DFSTraverse()
        {
            InitVisited();
            DFS(items[0]);

        }
        private void DFS(Vertex<T> v)
        {
            v.isVisited = true;
            Console.WriteLine(v.data.ToString()+" ");
            Node node = v.firstEdge;
            while (node!=null)
            {
                if (node.adjvex.isVisited==false)
                {
                    DFS(node.adjvex);
                }
                node = node.next;
            }

        }
        //广度优先遍历
        public void BFSTraverse()
        {
            InitVisited();
            BFS(items[0]);
        }
        private void BFS(Vertex<T> v)
        {
            v.isVisited = true;
            Console.WriteLine(v.data.ToString()+" ");
            Queue<Vertex<T>> verQueue = new Queue<Vertex<T>>();
            verQueue.Enqueue(v);
            while (verQueue.Count>0)
            {
                Vertex<T> w = verQueue.Dequeue();
                Node node = w.firstEdge;
                while (node!=null)
                {
                    if (node.adjvex.isVisited==false)
                    {
                        node.adjvex.isVisited = true;
                        Console.WriteLine(node.adjvex.data+" ");
                        verQueue.Enqueue(node.adjvex);
                    }
                    node = node.next;
                }
            }
        }
        #endregion

        #region 辅助方法
        private bool IsContains(T item)
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

        private void InitVisited()
        {
            foreach (Vertex<T> v in items)
            {
                v.isVisited = false;
            }
        }
        #endregion

        #region 嵌套类
       public class Vertex<TValue>
        {
            public TValue data;
            public Node firstEdge;
            public bool isVisited;
            public Vertex()
            {
                this.data = default(TValue);
            }
            public Vertex(TValue value)
            {
                this.data = value;
            }
        }
       public class Node
        {
            public Vertex<T> adjvex;
            public Node next;
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
