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
            //string[] result1;
            int count = GetReverseNumber(a);//0
            Console.WriteLine("The Reverse Sequence is {0}", count);

            int[] b = { 3, 1, 4, 2, 6, 7 };
            PrintArray(b);
            count = GetReverseNumber(b);//3
            Console.WriteLine("The Reverse Sequence is {0}", count);

            Console.ReadKey();

        }

        public static void PrintArray(int[] x)
        {
            foreach (var i in x)
            {
                Console.Write(i+" ");
            }
        }

        public static int GetReverseNumber(int[] x)
        {
            int count = 0;
            for (int i = 1; i < x.Length-1; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (x[j] > x[i])
                    {
                        count++;
                    }
                }
            }
            return count;
        }




    }
}
