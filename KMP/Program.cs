using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMP
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "ABACBCDHI";
            string match = "CBC";
            int i = KMPMatch(str, match);
            Console.WriteLine(i);
            Console.ReadKey();
        }

        public static int KMPMatch(string str, string match)
        {
            char[] s = str.ToCharArray();
            char[] m = match.ToCharArray();
            int[] next = GetNext(match);
            int i = 0;
            int j = 0;
            while (i < str.Length && j < match.Length)
            {
                if (j == -1 || s[i] == m[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    j = next[j];
                }
            }
            if (j == m.Length)
            {
                return i - j;
            }
            return -1;
        }

        public static int[] GetNext(string ps)
        {
            char[] p = ps.ToCharArray();
            int[] next = new int[p.Length];
            int j = 0;
            int k = -1;
            next[0] = -1;
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
    }
}
