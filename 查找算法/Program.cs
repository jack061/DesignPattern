using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 查找算法
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        //二分查找
        public static int BinarySearch(int[] array, int value)
        {
            int low = 0;
            int high = array.Length - 1;
            int mid = 0;
            while (low <= high)
            {
                mid = (low + high) / 2;
                if (array[mid]==value)
                {
                    return mid;
                }
                else if (array[mid]<value)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return low + (high - low) >> 1;
        }


    }
}
