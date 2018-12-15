using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图的结构
{
    class Program
    {
        static void Main(string[] args)
        {
            #region old
            //Console.WriteLine("---------无向图-----------");
            //MyAdjencyList<string> adjList = new MyAdjencyList<string>();
            ////添加顶点
            //adjList.AddVertex("A");
            //adjList.AddVertex("B");
            //adjList.AddVertex("C");
            //adjList.AddVertex("D");
            ////添加无向边
            //adjList.AddEdge("A", "B");
            //adjList.AddEdge("A", "C");
            //adjList.AddEdge("A", "D");
            //adjList.AddEdge("B", "D");
            //Console.WriteLine(adjList.GetGraphInfo());
            ////添加有向边
            //Console.WriteLine("-----------有向图--------------");
            //MyAdjencyList<string> dirList = new MyAdjencyList<string>();
            //dirList.AddVertex("A");
            //dirList.AddVertex("B");
            //dirList.AddVertex("C");
            //dirList.AddVertex("D");
            //dirList.AddDirectedEdge("A", "B");
            //dirList.AddDirectedEdge("A", "C");
            //dirList.AddDirectedEdge("A", "D");
            //dirList.AddDirectedEdge("B", "D");
            //Console.WriteLine(dirList.GetGraphInfo(true));
            //Console.Write("深度优先遍历：");
            MyAdjencyList<string> adjList = new MyAdjencyList<string>();
            // 添加顶点
            adjList.AddVertex("V1");
            adjList.AddVertex("V2");
            adjList.AddVertex("V3");
            adjList.AddVertex("V4");
            adjList.AddVertex("V5");
            adjList.AddVertex("V6");
            adjList.AddVertex("V7");
            adjList.AddVertex("V8");
            // 添加边
            adjList.AddEdge("V1", "V2");
            adjList.AddEdge("V1", "V3");
            adjList.AddEdge("V2", "V4");
            adjList.AddEdge("V2", "V5");
            adjList.AddEdge("V3", "V6");
            adjList.AddEdge("V3", "V7");
            adjList.AddEdge("V4", "V8");
            adjList.AddEdge("V5", "V8");
            adjList.AddEdge("V6", "V8");
            adjList.AddEdge("V7", "V8");
            // DFS遍历
            adjList.BFSTraverse();
            Console.WriteLine();
            #endregion

            //PrimTest();
            Console.ReadKey();
        }

        #region 最小生成树
        static void PrimTest()
        {
            int[,] cost = new int[6, 6];
            // 模拟图的邻接矩阵初始化
            cost[0, 1] = cost[1, 0] = 6;
            cost[0, 2] = cost[2, 0] = 6;
            cost[0, 3] = cost[3, 0] = 1;
            cost[1, 3] = cost[3, 1] = 5;
            cost[2, 3] = cost[3, 2] = 5;
            cost[1, 4] = cost[4, 1] = 3;
            cost[3, 4] = cost[4, 3] = 6;
            cost[3, 5] = cost[5, 3] = 4;
            cost[4, 5] = cost[5, 4] = 6;
            cost[2, 5] = cost[5, 2] = 2;
            // Prim算法构造最小生成树:从顶点0开始
            Console.WriteLine("Prim算法构造最小生成树：（从顶点0开始）");
            double sum = 0;
            Prim(cost, 0, ref sum);
            Console.WriteLine("最小生成树权值和为：{0}", sum);
        }

        static void Prim(int[,] V, int vertex, ref double sum)
        {
            int length = V.GetLength(1);  // 获取元素个数
            int[] lowcost = new int[length]; // 待选边的权值集合V
            int[] U = new int[length]; // 最终生成树值集合U

            for (int i = 0; i < length; i++)
            {
                lowcost[i] = V[vertex, i]; // 将邻接矩阵起始点矩阵中所在行的值加入V
                U[i] = vertex; // U集合中的值全为起始顶点
            }

            lowcost[vertex] = -1; // 起始节点标记为已使用:-1代表已使用，后续不再判断

            for (int i = 1; i < length; i++)
            {
                int k = 0;  // k标识V集合中最小值索引
                int min = int.MaxValue; // 辅助变量：记录最小权值
                // 下面for循环中寻找V集合中权值最小的与顶点i邻接的顶点j
                for (int j = 0; j < length; j++)
                {
                    if (lowcost[j] > 0 && lowcost[j] < min) // 寻找范围不包括0、-1以及无穷大值
                    {
                        min = lowcost[j];
                        k = j; // k记录最小权值索引
                    }
                }
                // 找到了并进行打印输出
                Console.WriteLine("找到边({0},{1})权为：{2}", U[k], k, min);
                lowcost[k] = -1;  // 标志为已使用
                sum += min; // 累加权值

                for (int j = 0; j < length; j++)
                {
                    // 如果集合U中有多个顶点与集合V中某一顶点存在边
                    // 则选取最小权值边加入lowcost集合中
                    if (V[k, j] != 0 && (lowcost[j] == 0 || V[k, j] < lowcost[j]))
                    {
                        lowcost[j] = V[k, j]; // 更新集合lowcost
                        U[j] = k; // 更新集合U
                    }
                }
            }
        }
        #endregion
    }



}
