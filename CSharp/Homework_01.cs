using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a;
            int[] b;
            int i = 0;
            int j = 0;
            a = new int[] { 3, 1, 4, 2, 6, 7 };
            b = new int[] { 1, 2, 3, 4, 5, 6 };
            foreach (int c in a)
            {
                i++;
                if (i < 6)
                {
                    ASd(c, a, i);
                    //Console.WriteLine(i);
                }
            }
            foreach (int d in b)
            {
                j++;
                if (j < 6)
                {
                    BSd(d, b, j);
                    //Console.WriteLine(i);
                }
            }
        }
        static void ASd(int c, int[] a, int i)
        {
            for (int x = i; x < 6; x++)
            {
                if (c > a[x])
                {
                    Console.WriteLine($"序列a的逆序数对是{c}{a[x]}");
                }
            }
        }
        static void BSd(int d, int[] b, int j)
        {
            for (int y = j; y < 6; y++)
            {
                if (d > b[y])
                {
                    Console.WriteLine($"序列b的逆序数对是{d}{b[y]}");
                }
            }
        }
    }
}
