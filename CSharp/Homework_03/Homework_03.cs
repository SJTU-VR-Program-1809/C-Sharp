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
            Console.WriteLine("-------------------------Single LinkList-------------------");
            int[] num_0 = { 1, 3, 5, 6, 6, 6 };
            SingleLinkList singleList = new SingleLinkList(num_0);
            singleList.Display();
            SingleLinkList.Node x = singleList.Find(6);
            var n1 = singleList.InsertBefore(x, 10);
            singleList.Display();
            singleList.InsertAfter(n1, 3);
            singleList.Display();
            singleList.Delete(6);
            singleList.Display();
            singleList.Reverse();
            singleList.Display();

            Console.WriteLine("-------------------------Double LinkList-------------------");
            int[] num_1 = { 1, 3, 5, 6, 6, 6 };
            DoubleLinkList doubleList = new DoubleLinkList(num_1);
            doubleList.Display();
            DoubleLinkList.Node xx = doubleList.Find(3);
            var n2 = doubleList.InsertBefore(xx, 10);
            doubleList.Display();
            doubleList.InsertAfter(n2, 3);
            doubleList.Display();
            doubleList.Delete(6);
            doubleList.Display();
            doubleList.Reverse();
            doubleList.Display();
            doubleList.Delete(5);
            doubleList.Display();
        }
    }
}
