using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4, 5, 6 };
            PrintArray(a);
            GetReverseNumber(a); //
            int[] b = { 3, 1, 4, 2, 5, 6, 7 };
            PrintArray(b);
            GetReverseNumber(b);
            Console.ReadKey();
        }
        static void PrintArray(int[] a)
        {
            foreach (int c in a)  // 从最开始的开始排序
            {
                Console.Write(c + " ");

                Console.WriteLine();
            }
        }

        static void GetReverseNumber(int[] d)
        {
            int rev = 0;//计数器
            Console.Write("逆序数对:");
            for (int i = 0; i < (d.Length - 1); i++)
            {
                for (int j = i + 1; j < d.Length; j++)
                {
                    if (d[i] > d[j])
                    {
                        Console.Write("(" + d[i] + ", " + d[j] + ")");
                        rev = rev + 1;
                    }

                }

            }
            Console.WriteLine(rev);


        }


    }
}
