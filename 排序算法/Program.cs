using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 排序算法
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] array = new int[] { 10, 12, 44, 22, 1, 230, 40, 60, 80, 20, 30, 90, 100 };
            //SortAlgorithm.shellsort(array);
            SortAlgorithm.MergeSortFunction(array, 0, array.Length - 1);
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.ReadKey();
        }
    }
    class SortAlgorithm
    {
        #region 冒泡排序
        public static void BubbleSort(int[] array)
        {
            bool isSorted = false;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = array.Length - 2; j >= i; j--)
                {
                    if (array[j + 1] > array[j])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        isSorted = true;
                    }
                }
                if (!isSorted)
                {
                    break;
                }
            }
        }

        #endregion

        #region 简单选择排序
        public static void SimpleChooseSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[min] > array[j])
                    {
                        min = j;
                    }
                }
                if (i != min)
                {
                    int temp = array[i];
                    array[i] = array[min];
                    array[min] = temp;
                }
            }
        }
        #endregion

        #region 快速排序

        #region old
        //public static int Divison(int[] array, int left, int right)
        //{

        //    while (left < right)
        //    {
        //        if (array[left] > array[left + 1])
        //        {
        //            int temp = array[left];
        //            array[left] = array[left + 1];
        //            array[left + 1] = temp;
        //            left++;
        //        }
        //        else
        //        {
        //            int temp = array[left + 1];
        //            array[left + 1] = array[right];
        //            array[right] = temp;
        //            right--;
        //        }
        //    }
        //    return left;
        //}
        //public static void QuickSort(int[] array, int left, int right)
        //{
        //    if (left < right)
        //    {
        //        int division = Divison(array, left, right);
        //        QuickSort(array, left, division - 1);
        //        QuickSort(array, division + 1, right);
        //    }
        //} 
        #endregion

        public static int Division(int[] array, int left, int right)
        {
            while (left < right)
            {
                int division = left;
                if (array[division] > array[left + 1])
                {
                    int temp = array[division];
                    array[division] = array[left + 1];
                    array[left + 1] = temp;
                    left++;
                }
                else
                {
                    int temp = array[left + 1];
                    array[left + 1] = array[right];
                    array[right] = temp;
                    right--;
                }
            }
            return left;
        }
        public static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivot = Division(array, left, right);
                QuickSort(array, left, pivot - 1);
                QuickSort(array, pivot + 1, right);

            }
        }


        #endregion

        #region 直接插入排序
        public static void InsertSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                while (j > 0 && array[j] < array[j - 1])
                {
                    int temp = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = temp;
                    j--;
                }
            }

        }
        #endregion

        #region 希尔排序
        public static void shellsort(int[] a)
        {
            int d = a.Length / 2;
            while (d >= 1)
            {
                for (int i = 0; i < d; i++)
                {
                    for (int j = i + d; j < a.Length; j += d)
                    {
                        int temp = a[j];//存储和其比较的上一个a[x];
                        int loc = j;
                        while (loc - d >= i && temp < a[loc - d])//&&j-d>=i
                        {
                            a[loc] = a[loc - d];
                            loc = loc - d;
                        }
                        a[loc] = temp;
                    }
                }
                //一次插入排序结束，缩小d的值
                d = d / 2;
            }
        }
        #endregion

        #region 堆排序

        #region old
        ////堆排序算法（传递待排数组名，即：数组的地址。故形参数组的各种操作反应到实参数组上）
        //public static void HeapSortFunction(int[] array)
        //{
        //    try
        //    {
        //        //根据大顶堆的性质可知：数组的前半段的元素为根节点，其余元素都为叶节点
        //        for (int i = array.Length / 2 - 1; i >= 0; i--) //从最底层的最后一个根节点开始进行大顶推的调整
        //        {
        //            MaxHeapify(array, i, array.Length); //调整大顶堆
        //        }
        //        for (int i = array.Length - 1; i > 0; i--)
        //        {
        //            Swap(ref array[0], ref array[i]); //将堆顶元素依次与无序区的最后一位交换（使堆顶元素进入有序区）
        //            MaxHeapify(array, 0, i); //重新将无序区调整为大顶堆
        //        }
        //    }
        //    catch (Exception ex)
        //    { }
        //}

        /////<summary>
        ///// 创建大顶推（根节点大于左右子节点）
        /////</summary>
        /////<param name="array">待排数组</param>
        //private static void BuildMaxHeap(int[] array)
        //{
        //    try
        //    {
        //        //根据大顶堆的性质可知：数组的前半段的元素为根节点，其余元素都为叶节点
        //        for (int i = array.Length / 2 - 1; i >= 0; i--) //从最底层的最后一个根节点开始进行大顶推的调整
        //        {
        //            MaxHeapify(array, i, array.Length); //调整大顶堆
        //        }
        //    }
        //    catch (Exception ex)
        //    { }
        //}

        /////<summary>
        ///// 大顶推的调整过程
        /////</summary>
        /////<param name="array">待调整的数组</param>
        /////<param name="currentIndex">待调整元素在数组中的位置（即：根节点）</param>
        /////<param name="heapSize">堆中所有元素的个数</param>
        //private static void MaxHeapify(int[] array, int currentIndex, int heapSize)
        //{
        //    try
        //    {
        //        int left = 2 * currentIndex + 1;    //左子节点在数组中的位置
        //        int right = 2 * currentIndex + 2;   //右子节点在数组中的位置
        //        int large = currentIndex;   //记录此根节点、左子节点、右子节点 三者中最大值的位置

        //        if (left < heapSize && array[left] > array[large])  //与左子节点进行比较
        //        {
        //            large = left;
        //        }
        //        if (right < heapSize && array[right] > array[large])    //与右子节点进行比较
        //        {
        //            large = right;
        //        }
        //        if (currentIndex != large)  //如果 currentIndex != large 则表明 large 发生变化（即：左右子节点中有大于根节点的情况）
        //        {
        //            Swap(ref array[currentIndex], ref array[large]);    //将左右节点中的大者与根节点进行交换（即：实现局部大顶堆）
        //            MaxHeapify(array, large, heapSize); //以上次调整动作的large位置（为此次调整的根节点位置），进行递归调整
        //        }
        //    }
        //    catch (Exception ex)
        //    { }
        //} 
        #endregion

        public static void HeapSort(int[] array)
        {
            //初始化大顶堆
            for (int i = array.Length / 2 - 1; i >= 0; i--)
            {
                MaxHeap(array, i, array.Length);
            }
            for (int i = array.Length - 1; i >= 0; i--)
            {
                int temp = array[i];
                array[i] = array[0];
                array[0] = temp;
                MaxHeap(array, 0, i);
            }
        }

        /// <summary>
        /// 获取大顶堆
        /// </summary>
        /// <param name="array"></param>
        /// <param name="currentIndex">待调整的元素在数组中的位置,即根节点</param>
        /// <param name="heapSize">堆中所有元素的个数</param>
        public static void MaxHeap(int[] array, int currentIndex, int heapSize)
        {
            int left = 2 * currentIndex + 1;
            int right = 2 * currentIndex + 2;
            int large = currentIndex;
            if (left < heapSize && array[left] > array[large])
            {
                large = left;
            }
            if (right < heapSize && array[right] > array[large])
            {
                large = right;
            }
            if (large != currentIndex)
            {
                int temp = array[large];
                array[large] = array[currentIndex];
                array[currentIndex] = temp;
                MaxHeap(array, large, heapSize);
            }
        }

        ///<summary>
        /// 交换函数
        ///</summary>
        ///<param name="a">元素a</param>
        ///<param name="b">元素b</param>
        private static void Swap(ref int a, ref int b)
        {
            int temp = 0;
            temp = a;
            a = b;
            b = temp;
        }
        #endregion

        #region 归并排序
        //归并排序（目标数组，子表的起始位置，子表的终止位置）
        public static void MergeSortFunction(int[] array, int first, int last)
        {
            #region old
            //if (first < last)   //子表的长度大于1，则进入下面的递归处理
            //{
            //    int mid = (first + last) / 2;   //子表划分的位置
            //    MergeSortFunction(array, first, mid);   //对划分出来的左侧子表进行递归划分
            //    MergeSortFunction(array, mid + 1, last);    //对划分出来的右侧子表进行递归划分
            //    MergeSortCore(array, first, mid, last); //对左右子表进行有序的整合（归并排序的核心部分）
            //} 
            #endregion

            if (first < last)//子表长度大于1,进入递归处理
            {
                int mid = (first + last) / 2;
                MergeSortFunction(array, first, mid);
                MergeSortFunction(array, mid + 1, last);
                MergeSortCore2(array, first, mid, last);
            }
        }
        //归并排序的核心部分：将两个有序的左右子表（以mid区分），合并成一个有序的表
        public static void MergeSortCore(int[] array, int first, int mid, int last)
        {
            #region old
            //try
            //{
            //    int indexA = first; //左侧子表的起始位置
            //    int indexB = mid + 1;   //右侧子表的起始位置
            //    int[] temp = new int[last + 1]; //声明数组（暂存左右子表的所有有序数列）：长度等于左右子表的长度之和。
            //    int tempIndex = 0;
            //    while (indexA <= mid && indexB <= last) //进行左右子表的遍历，如果其中有一个子表遍历完，则跳出循环
            //    {
            //        if (array[indexA] <= array[indexB]) //此时左子表的数 <= 右子表的数
            //        {
            //            temp[tempIndex++] = array[indexA++];    //将左子表的数放入暂存数组中，遍历左子表下标++
            //        }
            //        else//此时左子表的数 > 右子表的数
            //        {
            //            temp[tempIndex++] = array[indexB++];    //将右子表的数放入暂存数组中，遍历右子表下标++
            //        }
            //    }
            //    //有一侧子表遍历完后，跳出循环，将另外一侧子表剩下的数一次放入暂存数组中（有序）
            //    while (indexA <= mid)
            //    {
            //        temp[tempIndex++] = array[indexA++];
            //    }
            //    while (indexB <= last)
            //    {
            //        temp[tempIndex++] = array[indexB++];
            //    }

            //    //将暂存数组中有序的数列写入目标数组的制定位置，使进行归并的数组段有序
            //    tempIndex = 0;
            //    for (int i = first; i <= last; i++)
            //    {
            //        array[i] = temp[tempIndex++];
            //    }
            //}
            //catch (Exception ex)
            //{ } 
            #endregion

            int indexA = first;//左子表起始位置
            int indexB = mid + 1;//右子表起始位置
            int tempindex = 0;
            int[] temp = new int[last + 1];//暂存表
            while (indexA <= mid && indexB <= last)//左右子表有一个遍历完成后即跳出循环
            {
                if (array[indexA] <= array[indexB])
                {
                    temp[tempindex++] = array[indexA++];
                }
                else
                {
                    temp[tempindex++] = array[indexB++];
                }
            }
            //未遍历完成的子表一次性写入暂存表中
            while (indexA <= mid)
            {
                temp[tempindex++] = array[indexA++];
            }
            while (indexB <= last)
            {
                temp[tempindex++] = array[indexB++];
            }
            //把暂存表中的数据写入到数组内
            tempindex = 0;
            for (int i = first; i <= last; i++)
            {
                array[i] = temp[tempindex++];
            }

        }

        public static void MergeSortCore2(int[] array, int first, int mid, int last)
        {
            int indexA = first;
            int indexB = mid + 1;
            int[] temp = new int[last+1];
            int tempIndex = 0;
            while (indexA <= mid && indexB <= last)
            {
                if (array[indexA] <= array[indexB])
                {
                    temp[tempIndex++] = array[indexA++];
                }
                else
                {
                    temp[tempIndex++] = array[indexB++];
                }
            }
            while (indexA <= mid)
            {
                temp[tempIndex++] = array[indexA++];
            }
            while (indexB <= last)
            {
                temp[tempIndex++] = array[indexB++];
            }
            tempIndex = 0;
            for (int i = first; i <= last; i++)
            {
                array[i] = temp[tempIndex++];
            }

        }
        #endregion

    }

}
