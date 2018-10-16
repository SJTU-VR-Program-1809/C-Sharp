using System;


namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4, 5, 6 };
            PrintArry(a);
            GetReverseNumber(a);

            int[] b = { 3, 1, 4, 2, 5, 6, 7 };
            PrintArry(b);
            GetReverseNumber(b);
        }
        static void PrintArry(int[] a)
        {
            foreach(var i in a)
            {
                Console.Write(i.ToString() + "");
            }
            Console.WriteLine();
        }
        static void GetReverseNumber(int[] n)
        {
            int j = n.Length;
            int[] k=new int[j];
            for (int i= 0;i< n.Length; i++)
            {
                j--;
                k[j]=n[i];
                   
               
            
            }
            foreach (var b in k)
            {
                Console.Write(b.ToString() + "");
            }
            Console.WriteLine();

           
        }
        
    }
}
