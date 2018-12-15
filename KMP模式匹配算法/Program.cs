using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMP模式匹配算法
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "ABCABCDHEFVBS";
            string match = "ABCABCF";
            int k = KMPAlgorithm.KMPMatchBase(str, match);
            Console.WriteLine(k);
            Console.ReadKey();
        }
    }
    class KMPAlgorithm
    {
        //基础解法,复杂度o((n-1)*m)
        public static int KMPMatchBase(string str, string match)
        {
            char[] s = str.ToCharArray();
            char[] m = match.ToCharArray();
            int i = 0;//主串的位置
            int j = 0;//匹配串的位置
            int[] next = getNext(match);
            while (i < s.Length && j < m.Length)
            {
                if (j == -1 || s[i] == m[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    //i = i - j + 1;
                    j = next[j];

                }

            }
            if (j == m.Length)
            {
                return i - j;
            }
            else
            {
                return 0;
            }
        }

        public static int[] getNext(String ps)
        {

            char[] p = ps.ToCharArray();

            int[] next = new int[p.Length];

            next[0] = -1;

            int j = 0;

            int k = -1;

            while (j < p.Length - 1)
            {

                if (k == -1 || p[j] == p[k])
                {
                    j++;
                    k++;
                    next[j] = k;

                }
                else
                {

                    k = next[k];

                }

            }

            return next;

        }
        public static int[] getNext2(string ps)
        {
            #region old
            //char[] p = ps.ToCharArray();
            //int[] next = new int[p.Length];
            //next[0] = -1;
            //int j = 0;
            //int k = -1;
            //while (j < p.Length - 1)
            //{
            //    if (k == -1 || p[k] == p[j])
            //    {
            //        next[++j] = ++k;
            //    }
            //    else
            //    {
            //        k = next[k];
            //    }
            //}
            //return next; 
            #endregion

            char[] p = ps.ToCharArray();
            int j = 0;
            int k = -1;
            int[] next = new int[p.Length];
            while (j < p.Length - 1)
            {
                if (k == -1 || p[j] == p[k])
                {
                    next[++j] = ++k;
                }
                else
                {
                    k = next[k];
                }
            }
            return next;

        }
        //朴素算法
        public static int NaiveMatch(string str, string match)
        {
            char[] s = str.ToCharArray();
            char[] m = match.ToCharArray();
            int i = 0;
            int j = 0;
            while (i < s.Length && j < m.Length)
            {
                if (s[i] == m[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    i = i - j + 1;
                    j = 0;
                }
            }
            if (j == m.Length)
            {
                return i - j;
            }
            else
            {
                return -1;
            }
        }
    }
}
