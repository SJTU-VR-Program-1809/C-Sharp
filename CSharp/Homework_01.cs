using System;

namespace CSharp
{
    class Homework_01
    {
        static void Main(string[] args)
        {
            //求这两组数的逆序数对
            int reverse_num_a = 0;
            int reverse_num_b = 0;
            int[] a = { 1, 2, 3, 4, 5, 6 };
            
            int[] b = { 3, 1, 4, 2, 6, 7 };
            for (int j = 0; j < 6; j++)
            {
                for (int k = 0; k <j; k++)
                {
                    if (a[j] < a[k]) { reverse_num_a++; }
                    if (b[j] < b[k]) { reverse_num_b++; }
                }
            }
            Console.WriteLine("zqx a: "+ reverse_num_a);
            Console.WriteLine("zqx b: " + reverse_num_b);
            Console.ReadKey();
        }
    }
}