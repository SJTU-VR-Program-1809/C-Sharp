using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLinkList;

namespace CSharp
{
    class Homework_03
    {
        static void Main()
        {
            int[] num = { 1, 3, 5, 6, 6, 6 };
            SingleLinkList singleList = new SingleLinkList(num);
            SingleLinkList.Node x = singleList.Find(6);

            var n1 = singleList.InsertBefore(x, 10);
            singleList.Display();
            singleList.InsertAfter(n1, 3);
            singleList.Display();
            singleList.Delete(6);
            singleList.Display();
            singleList.Reverse();
            singleList.Display();
        }
    }
}
