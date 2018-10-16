using System;

namespace CSharp
{
    class Homework_01
    {
        private static int x, y;
        private static int a;
        static void Main(string[] args)
        {
            int n = 123;
            int ret = ReverseNumber(n);
            Console.WriteLine($"Reverse 123 :{ret}");
            n = -123;
            ret = ReverseNumber(n);
            Console.WriteLine($"Reverse -123:{ret}");
            n = 123456789;
            ret = ReverseNumber(n);
            Console.WriteLine($"Reverse 123456789:{ret}");


            int[] a = { 1, 2, 3, 4, 5, 6 };
            PrintArray(a);

            int count = GetReveseNumber(a);//0
            Console.WriteLine($"The number of  reverse sequence is:{count}");

            int[] b = { 3, 1, 4, 2, 6, 7 };
            PrintArray(b);

            count = GetReveseNumber(b);//3
            Console.WriteLine($"The number of  reverse sequence is:{count}");
        }

        static void PrintArray(int[] a)
        {
            foreach (var i in a)
            {
                Console.Write(i.ToString() + " ");
            }

            Console.WriteLine();
        }

        static int GetReveseNumber(int[] a)
        {
            int c = 0;

            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = i; j < a.Length - 1; j++)
                {
                    if (a[i] > a[j + 1])
                    {
                        c++;
                        Console.WriteLine("逆序数对为：" + a[i] + " " + a[j + 1]);
                    }
                }
            }
            return c;
        }

        static int ReverseNumber(int n)
        {
            int res = 0;
            do
            {
                a = n % 10;
                n /= 10;
                res = res * 10 + a;
            } while (n != 0);

            return res;

        }
    }
}