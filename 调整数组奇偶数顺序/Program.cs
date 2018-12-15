using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 调整数组奇偶数顺序
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 2, 1, 5, 4, 24, 12, 323, 456, 34, 22, 13, 45, 67, 49 };
            ReorderOddEven(list, u => u % 2 == 0);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        #region old
        //public static void ReorderOddEven(List<int> list, Predicate<int> func)
        //{
        //    int left = 0;
        //    int right = list.Count - 1;
        //    while (left < right)
        //    {
        //        if (func(list[left+1]))
        //        {
        //            int temp = list[left + 1];
        //            list[left + 1] = list[left];
        //            list[left] = temp;
        //            left++;
        //        }
        //        else
        //        {
        //            int temp2 = list[right];
        //            list[right] = list[left + 1];
        //            list[left + 1] = temp2;
        //            right--;
        //        }
        //    }
        //} 
        #endregion

        public static void ReorderOddEven(List<int> list, Predicate<int> func)
        {
            int left = 0;
            int right = list.Count - 1;
            while (left < right)
            {
                if (func(list[left+1]))
                {
                    int temp = list[left];
                    list[left] = list[left + 1];
                    list[left + 1] = temp;
                    left++;
                }
                else
                {
                    int temp2 = list[left + 1];
                    list[left + 1] = list[right];
                    list[right] = temp2;
                    right--;

                }
            }
        }
        public static void Swap<T>(ref T i, ref T j)
        {
            T temp = i;
            i = j;
            j = temp;
        }
    }
}
