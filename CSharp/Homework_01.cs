using System;

namespace CSharp
{
    class Homework_01
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4, 5, 6 };
            PrintArray(a);
            GetReverseNumber(a);

            int[] b = { 3, 1, 4, 2, 6, 7 };
            PrintArray(b);
            GetReverseNumber(b);
            
        }
        static void PrintArray(int[] a)
        {
            foreach (var i in a)
            {
                Console.Write(i.ToString() + " ");
            }
            Console.WriteLine();
        } 
        static void GetReverseNumber(int[] a)
        {
            int i = 0, j = 1;

            while (i < 6)
            {
                while (i < j && j < 6)
                {
                    if (a[i] > a[j])
                    {
                        Console.WriteLine("(" + a[i] + "," + a[j] + ")");
                    }
                    j++;
                }

                i++;
                j = i + 1;
            }

        }
    }
}