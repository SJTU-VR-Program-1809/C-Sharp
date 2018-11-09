using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linklist
{
    class program
    {
        static void Main(string[] args)
        {
            int[] num = { 1, 3, 5, 7 };
            LinkList list = new LinkList(num);
            list.Display();
            LinkList.Node X = list.Find(3);
            var n1 = list.InsertBefore(X, 10);
            list.Display();
            list.InsertAfter(n1, 3);
            list.Display();
            list.Delete(3);
            list.Display();
            Console.ReadKey();
        }
    }

    public class LinkList
    {
        private Node head;
        public class Node
        {
            public int data;
            public Node next;
            public Node(int Data)
            {
                data = Data;
            }
        }
        public LinkList(params int[] nums)
        {
            head = new Node(nums[0]);
            Node current = head ;
            Node next = null;
            for (int i = 0; i < nums.Length-1; i++)
            {
                next = new Node(nums[i+1]);
                current.next = next;
                    current = next;
            }
        }
        //if x is null, insert d as first node
        public Node InsertBefore(Node x, int d)
        {
            Node next;
            Node temp = new Node(0) ;
            Node current = head;
            if(x==null)
            {
                temp.next = head.next;
                temp.data = head.data;
                head.data = d;
                head.next = temp;
                return head;
            }
            while(current.next!=x)
            {
                next = current.next;
                current = next;
            }
            temp.next = current.next;
            current.next = temp;
            temp.data = d;
            return temp;
        }

        public Node InsertAfter(Node x, int d)
        {
            Node current = head;
            Node temp = new Node(0);
            Node next = null;
            if(x==null)
            {
                Console.WriteLine("Error Syntax");
                return null;
            }
            while(current!=x)
            {
                next = current.next;
                current = next;
            }
            temp.next = current.next;
            current.next = temp;
            temp.data = d;
            return temp;
        }

        public Node Find(int d)
        {
            Node current = head;
            Node next = null;
            while(current.data!=d)
            {
                next = current.next;
                current = next;
                if(current.next==null)
                {
                    Console.WriteLine("Your finding Node isn't existed");
                    return null;
                }
            }
            return current;
            
        }

        public void Delete(Node x)
        {
            Node current = head;
            Node next;
            if(head==x)
            {
                head = head.next;
                return;
            }
            while(current.next!=x)
            {
                next = current.next;
                current = next;
                if(current.next==null)
                {
                    Console.WriteLine("The Node you want to delete isn't existed");
                    return;
                }
            }
            current.next = current.next.next;

        }

        ////remove all nodes contain d
        public void Delete(int d)
        {
            Node current = head;
            Node next;
            if(head.data==d)
            {
                head = head.next;
                return;
            }
            while(current.next!=null)
            {
                if(current.next.data==d)
                {
                    next = current.next;
                    current.next = next.next;

                }
                else
                {
                    next = current.next;
                    current = next;
                }
            }
        }

        public void Display()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine("节点数据： " + current.data);
                current = current.next;
            }
        }
        ////optional retuen new linklist
        public void Reverse()
        {
            Node prev=head;
            Node current = head ;
            Node next;
            while(current.next!=null)
            {
                if(current.next==null)
                {
                    head = current;
                }
                next = current.next;
                current = current.next;
                next.next = prev;
            }
            
        }
    }
}



