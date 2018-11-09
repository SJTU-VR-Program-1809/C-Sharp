using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkList
{

    public class LinList
    {
        private Node head = new Node();
        public class Node
        {
            public int data;
            public Node next;
            public Node prev;
            public Node()
            {
                this.next = this;
                this.prev = this;
            }
        }

        public int Size { get; }
        public LinList(params int[] nums)
        {
            Node current = head;
            Size = nums.Length;
            for (int i = 0; i < nums.Length; i++)
            {
                Node node = new Node();
                node.data = nums[i];
                current.next = node;
                node.prev = current;
                current = node;
            }
            current.next = head;
            head.prev = current;
        }

        //if x is null,insert d as first
        public void InsertBefore(Node x, int d)
        {
            Node p = head;
            Node q = head.next;
            if (x == null)
            {
                Node n = new Node();
                n.data = d;
                n.next = q;
                n.prev = p;
                p.next = n;
                q.prev = n;
            }
            else
            {
                while (q.next != head)
                {
                    if (q == x)
                    {
                        Node n = new Node();
                        n.data = d;
                        n.next = q;
                        n.prev = p;
                        p.next = n;
                        q.prev = n;
                    }
                    p = q;
                    q = q.next;
                }
            }

        }
        public void InsertAfter(Node x, int d)
        {
            Node p = head;
            Node q = head.next;
            if (x == null)
            {
                Node n = new Node();
                n.data = d;
                n.next = q;
                n.prev = p;
                p.next = n;
                q.prev = n;
            }
            else
            {
                while (q != head)
                {
                    if (p == x)
                    {
                        Node n = new Node();
                        n.data = d;
                        n.next = q;
                        n.prev = p;
                        p.next = n;
                        q.prev = n;
                    }
                    p = q;
                    q = q.next;
                }
            }
        }
        public Node Find(int d)
        {
            Node p = head;
            while (p.next != head)
            {
                if (p.next.data == d)
                {
                    Node find = new Node();
                    find = p.next;
                    return find;
                }
                p = p.next;
            }
            return null;
        }

        public void Delete(Node x)
        {
            Node p = head;
            Node q = head.next;
            if (x != null)
            {
                while (q.next != head)
                {
                    if (q == x)
                    {
                        q = q.next;
                        p.next = q;
                        q.prev = p;
                        break;
                    }
                    p = q;
                    q = q.next;
                }
            }
            else
            {
                Console.WriteLine("this LinkedList doesn't contain the x node");
            }
        }

        //remove all nodes contain d
        public void Delete(int d)
        {
            Node p = head;
            Node q = head.next;
            while (q.next != head)
            {
                if (q.data == d)
                {
                    q = q.next;
                    p.next = q;
                    q.prev = p;
                }
                else
                {
                    p = q;
                    q = q.next;
                }
            }
        }
        public void Display()
        {
            Node p = head;
            Console.Write("the LinkedList is:");
            while (p.next != head)
            {
                if (p.next.next == head)
                {
                    Console.Write(p.next.data);
                }
                else
                    Console.Write(p.next.data + "->");

                p = p.next;

            }
            Console.WriteLine();
        }
        //optional
        public void Reverse()
        {
            Node p = head;
            Node q = head.next;
            Node n = head;
            p.next = n.prev;
            p.prev = q;
            p = q;
            n = p;
            q = q.next;
            while (p != head)
            {
                p.next = n.prev;
                p.prev = q;
                p = q;
                n = p;
                q = q.next;
            }
        }

    }
}

