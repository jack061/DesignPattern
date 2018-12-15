using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 最小的K个数
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 7, 2, 9, 6, 8 };
            SortedDictionary<int, int> sortDic = new SortedDictionary<int, int>();
            GetLeastNumbersByRedBlackTree(list, sortDic, 4);
            foreach (var item in sortDic)
            {
                Console.WriteLine(item.Value);
            }
            Console.ReadKey();
        }

        public static void GetLeastNumbersByRedBlackTree(List<int> data, SortedDictionary<int, int> leastNumbers, int k)
        {
            leastNumbers.Clear();

            if (k < 1 || data.Count < k)
            {
                return;
            }

            for (int i = 0; i < data.Count; i++)
            {
                int num = data[i];
                if (leastNumbers.Count < k)
                {
                    leastNumbers.Add(num, num);
                }
                else
                {
                    int greastNum = leastNumbers.ElementAt(leastNumbers.Count - 1).Value;
                    if (num < greastNum)
                    {
                        leastNumbers.Remove(greastNum);
                        leastNumbers.Add(num, num);
                    }
                }
            }
        }
    }
}
