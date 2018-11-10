using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkList
{
    class SingleLinkList
    {
        private Node head = null;
        public int Size { get; private set; }
        public class Node
        {
            public int Data { get; set; }
            public Node next;
            public Node(int _data)
            {
                this.Data = _data;
            }
        }
        private SingleLinkList() { }
        public SingleLinkList(params int[] nums)
        {
            Node cur = new Node(nums[0]);
            Node next = null;
            head = cur;
            for (int i = 1; i < nums.Length; i++)
            {
                next = new Node(nums[i]);
                cur.next = next;
                cur = next;
            }
            Size = nums.Length;
        }

        //if x is null,insert d as first node
        public Node InsertBefore(Node x, int d)
        {
            Size += 1;
            Node prev = FindPrevious(x);
            if (x == null || prev == null)
            {
                return InsertBeforeHead(d);
            }
            else
            {
                Node newNode = new Node(d);
                newNode.next = prev.next;
                prev.next = newNode;
                return newNode;
            }
        }
        public Node InsertAfter(Node x, int d)
        {
            if(x==null)
            {
                Size += 1;
                return InsertBeforeHead(d);
            }
            if(x.next==null)
            {
                Size += 1;
                Node newNode = new Node(d);
                x.next = newNode;
                return newNode;
            }
            return InsertBefore(x.next, d);
        }
        private Node InsertBeforeHead(int d)
        {
            Node newNode = new Node(d);
            newNode.next = head;
            head = newNode;
            return newNode;
        }
        public Node Find(int d)
        {
            Node cur = head;
            while (cur != null)
            {
                if (cur.Data == d)
                    return cur;
                cur = cur.next;
            }
            return null;
        }
        private Node Find(Node startNode, int d)
        {
            Node cur = startNode;
            while (cur != null)
            {
                if (cur.Data == d)
                    return cur;
                cur = cur.next;
            }
            return null;
        }
        public Node FindPrevious(Node x)
        {
            Node prev = null;
            Node cur = head;
            while (cur != null)
            {
                if (cur == x)
                    return prev;
                prev = cur;
                cur = cur.next;
            }
            return null;
        }

        public void Delete(Node x)
        {
            if (x == null)
                return;
            if (x == head)
            {
                head = x.next;
            }
            else
            {
                Node prev = FindPrevious(x);
                if (prev != null)
                    prev.next = x.next;
                else
                    return;
            }
            Size -= 1;
        }
        //remove add nodes contains d
        public void Delete(int d)
        {
            Node deletaNode = Find(head, d);
            while (deletaNode != null)
            {
                Delete(deletaNode);
                deletaNode = Find(deletaNode.next, d);
            }
        }

        public void Display()
        {
            Console.Write($"LinkList Size:{Size}\t\t");
            Node cur = head;
            while (cur != null)
            {
                Console.Write($"{cur.Data}->");
                cur = cur.next;
            }
            Console.WriteLine();
        }

        public void Reverse()
        {
            Node prev = null;
            Node cur = head;
            while (head.next != null)
            {
                head = head.next;
                cur.next = prev;
                prev = cur;
                cur = head;
            }
            cur.next = prev;
        }
    }
}
