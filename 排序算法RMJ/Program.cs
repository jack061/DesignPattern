using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 排序算法RMJ
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 2,8,7,9,6,5 };
            SortAlgorithm.MergeSort(array, 0, array.Length - 1);
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
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = array.Length - 2; j >= i; j--)
                {
                    if (array[j + 1] < array[j])
                    {
                        Swap<int>(ref array[j + 1], ref array[j]);
                    }
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

        #region 直接插入排序
        public static void InsertSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                while (j > 0 && array[j] < array[j - 1])
                {
                    Swap<int>(ref array[j - 1], ref array[j]);
                    j--;
                }
            }
        }
        #endregion

        #region 快速排序

        public static int Division(int[] array, int left, int right)
        {

            while (left < right)
            {
                if (array[left] > array[left + 1])
                {
                    Swap<int>(ref array[left], ref array[left + 1]);
                    left++;
                }
                else
                {
                    Swap<int>(ref array[left + 1], ref array[right]);
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

        #region 堆排序

        public static void HeapSort(int[] array)
        {
            for (int i = array.Length / 2 - 1; i >= 0; i--)
            {
                MaxHeap(array, i, array.Length);
            }
            for (int i = array.Length - 1; i >= 0; i--)
            {
                Swap<int>(ref array[i], ref array[0]);
                MaxHeap(array, 0, i);
            }
        }
        //获取大顶堆
        public static void MaxHeap(int[] array, int currentIndex, int heapSize)
        {
            int left = currentIndex * 2 + 1;
            int right = currentIndex * 2 + 2;
            int large = currentIndex;
            if (left < heapSize && array[large] < array[left])
            {
                large = left;
            }
            if (right < heapSize && array[large] < array[right])
            {
                large = right;
            }
            if (large != currentIndex)
            {
                Swap<int>(ref array[large], ref array[currentIndex]);
                MaxHeap(array, large, heapSize);
            }
        }
        #endregion

        #region 归并排序
        public static void MergeSort(int[] array, int first, int last)
        {
            if (first < last)
            {
                int mid = (first + last) / 2;
                MergeSort(array, first, mid);
                MergeSort(array, mid + 1, last);
                MergeSortCore(array, first, mid, last);
            }
        }
        //核心方法,将两个有序子表,以mid区分,合并成一个有序表
        public static void MergeSortCore(int[] array, int first, int mid, int last)
        {
            int indexA = first;
            int indexB = mid + 1;
            int tempIndex = 0;
            int[] temp = new int[last + 1];
            while (indexA <= mid && indexB <= last)//左右子表一张便利完成后即跳出循环
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
            //未遍历完成的子表一次性写入到暂存表中
            while (indexA <= mid)
            {
                temp[tempIndex++] = array[indexA++];
            }
            while (indexB <= last)
            {
                temp[tempIndex++] = array[indexB++];
            }
            //用暂存表中数据替换原数组中数据
            tempIndex = 0;
            for (int i = first; i <= last; i++)
            {
                array[i] = temp[tempIndex++];
            }

        }
        #endregion

        #region 两元素交换
        public static void Swap<T>(ref T t1, ref T t2) where T : IComparable
        {
            T temp = t1;
            t1 = t2;
            t2 = temp;
        }
        #endregion

        #region 冒泡排序RMJ
        public static void BubbleSortRMJ(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = array.Length - 2; j >= i; j--)
                {
                    if (array[j + 1] > array[j])
                    {
                        Swap<int>(ref array[j + 1], ref array[j]);
                    }
                }
            }
        }
        #endregion

        #region 简单选择排序RMJ
        public static void SimpleChooseSortRMJ(int[] array)
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
                    Swap<int>(ref array[min], ref array[i]);
                }
            }
        }
        #endregion

        #region 直接插入排序RMJ
        public static void InsertSortRMJ(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                while (j > 0 && array[j] < array[j - 1])
                {
                    Swap<int>(ref array[j], ref array[j - 1]);
                    j--;
                }
            }
        }
        #endregion

        #region 快速排序RMJ
        public static void QuickSortRMJ(int[] array, int left, int right)
        {
            int pivot = DivisionRMJ(array, left, right);
            if (left < right)
            {
                QuickSortRMJ(array, 0, pivot - 1);
                QuickSortRMJ(array, pivot + 1, right);
            }

        }
        public static int DivisionRMJ(int[] array, int left, int right)
        {
            while (left < right)
            {
                int pivot = left;
                if (array[left] > array[left + 1])
                {
                    Swap<int>(ref array[left], ref array[left + 1]);
                    left++;
                }
                else
                {
                    Swap<int>(ref array[left + 1], ref array[right]);
                    right--;
                }
            }
            return left;
        }
        #endregion

        #region 堆排序RMJ
        public static void HeapSort(int[] array, int left, int right)
        {
            int mid = array.Length / 2 - 1;
            for (int i = mid; i >= 0; i--)
            {
                MaxHeapRMJ(array, i, array.Length);
            }
            for (int i = array.Length - 1; i >= 0; i--)
            {
                Swap<int>(ref array[i], ref array[0]);
                MaxHeapRMJ(array, 0, i);
            }

        }
        //获取大顶堆
        public static void MaxHeapRMJ(int[] array, int currentIndex, int heapSize)
        {
            int left = currentIndex * 2 + 1;
            int right = currentIndex * 2 + 2;
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
                Swap<int>(ref array[large], ref array[currentIndex]);
                MaxHeapRMJ(array, large, heapSize);
            }
        }
        #endregion

        #region 归并排序
        public static void MergeSortRMJ(int[] array,int first,int last)
        {
            if (first<last)
            {
                int mid = (first + last) / 2;
                MergeSortRMJ(array, first, mid);
                MergeSortRMJ(array, mid + 1, last);
                MergeSortCoreRMJ(array, first, mid, last);
               
            }
        }
        //核心方法,将两个有序子表,根据mid划分,合并成一个有序子表
        public static void MergeSortCoreRMJ(int[] array, int first, int mid, int last)
        {
            int indexA = first ;
            int indexB = mid + 1;
            int tempIndex = 0;
            int[] temp = new int[last + 1];
            while (indexA <= mid && indexB <= last)//左右子表只要有一张表结束就结束循环
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
            while (indexB<=last)
            {
                temp[tempIndex++] = array[indexB++];
            }
            tempIndex = 0;
            for (int i = first; i <=last; i++)
            {
                array[i] = temp[tempIndex++];
            }
        }
        #endregion

    }
}
