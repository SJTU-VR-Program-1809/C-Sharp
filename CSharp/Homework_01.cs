using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    class Homework_01
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4, 5, 6 };
            PrintArray(a);
            GetReveseNumber(a);

            int[] b = { 3, 1, 4, 2, 6, 7 };
            PrintArray(b);
            GetReveseNumber(b);

            Console.ReadLine();

        }

        private static void GetReveseNumber(int[] b)
        {
            Console.WriteLine("逆序分别为： ");
            for (int i = 0; i < b.Length - 1; i++)
            {
                for (int j = i + 1; j < b.Length; j++)
                {
                    if (b[i] > b[j])
                    {
                        Console.WriteLine(" ( " + b[i] + " , " + b[j] + " ) ");
                    }
                }
            }
            Console.WriteLine();
        }

        private static void PrintArray(int[] a)
        {
            Console.WriteLine("排列顺序为： ");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }
    }
}