using System;

namespace CSharp
{
    class Homework_01
    {
        static void Main(string[] args)
        {
            //求这两组数的逆序数对
            int[] a = { 1, 2, 3, 4, 5, 6 };
            int[] b = { 3, 1, 4, 2, 6, 7 };

            Compute(a);
            Compute(b);

            Console.WriteLine("按任意键结束");
            Console.ReadKey();
        }

        /// <summary>
        /// 计算逆序数对
        /// </summary>
        /// <param name="a">要计算的数组</param>
        static void Compute(int[] a)
        {
            //列出数组内容
            Console.Write("当前数组：(");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i]);
                if ( i < a.Length -1)
                {
                    Console.Write(",");
                }
            }
            Console.WriteLine(")");
            Console.WriteLine("正在列出逆序数对......");

            //逆序数对计数器
            int n = 0;
            //遍历列出逆序数对
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length - i; j++)
                {
                    if (a[i] > a[j])
                    {
                        n += 1;
                        Console.WriteLine($"({a[i]},{a[j]})");
                    }
                }
            }

            Console.WriteLine($"共计逆序数{n}对。");
            Console.WriteLine("-------------------------");
        }
    }
}