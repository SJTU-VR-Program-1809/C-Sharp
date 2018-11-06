using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkList
{
    class SingleLinkList
    {
        private Node head;
        public int Size { get; private set; }
        public class Node
        {
            public int Data { get; set; }
            public Node next;
            //public Node front;
            public Node(int _data)
            {
                this.Data = _data;
            }
        }
        public SingleLinkList(params int[] nums)
        {
            Node cur = null;
            Node next = null;
            for (int i = 0; i < nums.Length; i++)
            {
                if (next == null)
                {
                    cur = new Node(nums[i]);
                    head = cur;
                }
                else
                {
                    cur = next;
                }
                if (i + 1 < nums.Length)
                {
                    next = new Node(nums[i + 1]);
                }
                else
                {
                    next = null;
                }
                cur.next = next;
            }
            Size = nums.Length;
        }

        //if x is null,insert d as first node
        public Node InsertBefore(Node x, int d)
        {
            Node newNode = new Node(d);
            Node prev = FindPrevious(x);
            if (x == null || prev == null)
            {
                newNode.next = head;
                head = newNode;
            }
            else
            {
                newNode.next = prev.next;
                prev.next = newNode;
            }
            Size += 1;
            return newNode;
        }
        public Node InsertAfter(Node x, int d)
        {
            Node newNode = new Node(d);
            if (x == null)
            {
                newNode.next = head;
                head = newNode;
            }
            else
            {
                newNode.next = x.next;
                x.next = newNode;
            }
            Size += 1;
            return newNode;
        }
        public Node Find(int d)
        {
            Node cur = head;
            Node next = head.next;
            while (true)
            {
                if (cur.Data == d)
                    return cur;
                if (next == null)
                    return null;
                cur = next;
                next = next.next;
            }
        }

        public Node FindPrevious(Node x)
        {
            Node prev = null;
            Node cur = head;
            while (true)
            {
                if (cur == x)
                    return prev;
                if (cur.next == null)
                    return null;
                prev = cur;
                cur = cur.next;
            }
        }

        public void Delete(Node x)
        {
            if (x == null)
                return;
            Node prev = FindPrevious(x);
            prev.next = x.next;
            Size -= 1;
        }
        //remove add nodes contains d
        public void Delete(int d)
        {
            Node deletaNode = null;
            Node prev = null;
            int deleteCount = 0;
            while (true)
            {
                deletaNode = Find(d);
                if (deletaNode == null)
                    break;
                deleteCount++;
                prev = FindPrevious(deletaNode);
                if (prev == null)
                {
                    head = deletaNode.next;
                }
                else
                {
                    prev.next = deletaNode.next;
                }
            }
            Size -= deleteCount;
        }

        public void Display()
        {
            Node cur = head;
            Node next = head.next;
            while (true)
            {
                if (next != null)
                {
                    Console.Write($"{cur.Data}->");
                    cur = next;
                    next = next.next;
                }
                else
                {
                    break;
                }
            }
            Console.Write($"{cur.Data}");
            Console.WriteLine();
        }

        public void Reverse()
        {
            Node prev = null;
            Node temp = head;
            while (true)
            {
                if (head.next == null)
                    break;
                head = head.next;
                temp.next = prev;
                prev = temp;
                temp = head;
            }
            temp.next = prev;
        }
    }
}
