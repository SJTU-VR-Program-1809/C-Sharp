using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    class Program
    {
            static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4, 5, 6 };
            PrintArray(a);
            //string[] result1;
            int count = GetReverseNumber(a);//0
            Console.WriteLine("The reverse sequence is {0}",count);

            int[] b = { 3, 1, 4, 2, 6, 7 };
            PrintArray(b);
            count = GetReverseNumber(b);//3
            Console.WriteLine("The reverse sequence is {0}", count);

            Console.ReadKey();
        }

        static void PrintArray(int[] a)
        {
            foreach (var i in a)
            {
                Console.Write(i.ToString()+" ");
            }
            Console.WriteLine();
        }

        static int GetReverseNumber(int[] a)
        {
            int rev=0;//计数器
            Console.Write("逆序数对有：");
            for (int i = 0;i<(a.Length-1) ;i++ )
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] > a[j])
                    {
                        rev++;
                        Console.Write("(" + a[i] + "," + a[j] + ")");
                        Console.Write("({0},{1})",a[i],a[j]);
                    }
                        
                }
            }
            if(rev>0)
                Console.WriteLine();
                return rev;
        }
        
    }
}

