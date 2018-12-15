using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 丑数
{
    class Program
    {
        static void Main(string[] args)
        {
            int uglyNumber = GetUglyNumber(8);
            Console.WriteLine(uglyNumber);
            Console.ReadKey();
        }

        #region old
        //public static int GetUglyNumber(int index)
        //{
        //    if (index <= 0)
        //    {
        //        return 0;
        //    }
        //    int uglyCount = 0;
        //    int number = 0;
        //    while (uglyCount < index)
        //    {
        //        number++;
        //        if (IsUgly(number))
        //        {
        //            uglyCount++;
        //        }
        //    }
        //    return number;
        //}

        //private static bool IsUgly(int number)
        //{
        //    while (number % 2 == 0)
        //    {
        //        number = number/ 2;
        //    }
        //    while (number % 3 == 0)
        //    {
        //        number = number / 3;
        //    }
        //    while (number % 5 == 0)
        //    {
        //        number = number / 5;
        //    }
        //    return number == 1 ? true : false;
        //} 
        #endregion

        public static int GetUglyNumber(int index)
        {
            if (index <= 0)
            {
                return 0;
            }
            int[] uglyNumbers = new int[index];
            uglyNumbers[0] = 1;
            int nextUglyIndex = 1;
            int multiply2 = 0;
            int multiply3 = 0;
            int multiply5 = 0;
            int min = 0;
            while (nextUglyIndex < index)
            {
                min = Min(uglyNumbers[multiply2] * 2, uglyNumbers[multiply3] * 3, uglyNumbers[multiply5] * 5);
                uglyNumbers[nextUglyIndex] = min;

                if (uglyNumbers[multiply2] * 2 <= uglyNumbers[nextUglyIndex])
                {
                    multiply2++;
                }

                if (uglyNumbers[multiply3] * 3 <= uglyNumbers[nextUglyIndex])
                {
                    multiply3++;
                }

                if (uglyNumbers[multiply5] * 5 <= uglyNumbers[nextUglyIndex])
                {
                    multiply5++;
                }

                nextUglyIndex++;
            }

            int result = uglyNumbers[index - 1];
            uglyNumbers = null;

            return result;
        }

        private static int Min(int num1, int num2, int num3)
        {
            int min = num1 < num2 ? num1 : num2;
            min = min < num3 ? min : num3;

            return min;
        }
    }
}
