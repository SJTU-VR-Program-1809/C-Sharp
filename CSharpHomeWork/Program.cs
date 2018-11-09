using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HomeWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = { 1, 3, 5, 7 };
            LinkList list = new LinkList(num);
            LinkList.Node x = list.Find(3);
            var n1 = list.InsertBefore(x, 10);
            list.Display();
            list.Insertafter(n1, 3);
            list.Display();
            list.Delete(3);
            list.Display();

            
        }
    }
}
