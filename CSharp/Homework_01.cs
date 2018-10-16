using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nixushu
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4, 5, 6 };
            PrintArray(a);

            GetReveseNumber(a);
            int[] b = { 3, 1, 4, 2, 6, 7 };
            PrintArray(b);

            GetReveseNumber(b);
            Console.ReadKey();
        }

        static void PrintArray(int[] a)
        {
            foreach (var i in a)
            {
                Console.Write(i.ToString() + " ");
            }
            Console.WriteLine();
        }

        static void GetReveseNumber(int[] a)
        {
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length - 1; j++)
                {
                    if (a[i] > a[j])
                    {
                        Console.Write("({0},{1})", a[i], a[j]);
                        count += 1;
                    }
                }
            }
            Console.WriteLine(@"
逆序数对数为{0}", count);
        }
    }
}