using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 计算连续子数组的最大和
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, -2, 3, 10, -4, 7, 2, -5 };
            int maxSum = FindGreatestSumOfSubArray(array);
            Console.WriteLine(maxSum);
            Console.ReadKey();
        }
        /// <summary>
        /// 计算连续子数组的最大和
        /// </summary>
        public static int FindGreatestSumOfSubArray(int[] array)
        {
        
            int currSum = 0;
            int greatestSum = int.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (currSum <= 0)
                {
                    currSum = array[i];
                }
                else
                {
                    currSum += array[i];
                }

                if (currSum > greatestSum)
                {
                    greatestSum = currSum;
                }
            }

            return greatestSum;
        }
    }
}
