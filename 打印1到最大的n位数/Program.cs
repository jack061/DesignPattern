using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 打印1到最大的n位数
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintMaxDigits(2);
            Console.ReadKey();
        }

        public static void PrintMaxDigits(int number)
        {
            int t =1;
            for (int i = 1; i <= number; i++)
            {
                t = t * 10;
            }
            for (int i = 1; i < t; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
