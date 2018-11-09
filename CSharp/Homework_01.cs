using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkList<int> linkList = new LinkList<int>();
            for (int i = 0; i < 7; i++)
            {
                linkList.Add(i);
            }
            linkList.PrintLinkList();
            Console.WriteLine(" ");
            linkList.ToArrary();
            Console.WriteLine("");
            linkList.RemoveAt(4);
            linkList.PrintLinkList();
            Console.WriteLine(" ");
            linkList.Insert(10, 3);
            linkList.PrintLinkList();
            Console.WriteLine(" ");
            linkList.Reverse();
            linkList.PrintLinkList();
            Console.WriteLine("");
            Console.WriteLine(linkList.GetItem(4));
        }
    }
}
