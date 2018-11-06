using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkList
{
    class DoubleLinkList
    {
        private Node head;
        private Node tail;
        public int Size { get; private set; }
        public class Node
        {
            public int Data { get; set; }
            public Node next;
            public Node rear;
            public Node(int _data)
            {
                this.Data = _data;
            }
        }
        public DoubleLinkList(params int[] nums)
        {
            Node cur = null;
            Node next = null;
            Node rear = null;
            for (int i = 0; i < nums.Length; i++)
            {
                if (next == null)
                {
                    cur = new Node(nums[i]);
                    head = cur;
                }
                else
                {
                    rear = cur;
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
                cur.rear = rear;
            }
            Size = nums.Length;
            tail = cur;
        }

        //if x is null,insert d as first node
        public Node InsertBefore(Node x, int d)
        {
            Node newNode = new Node(d);
            Node rear = x.rear;
            if (x == null || rear == null)
            {
                newNode.next = head;
                newNode.rear = null;
                head.rear = newNode;
                head = newNode;
            }
            else
            {
                newNode.next = x;
                newNode.rear = x.rear;
                x.rear.next = newNode;
                x.rear = newNode;
            }
            Size += 1;
            return newNode;
        }
        public Node InsertAfter(Node x, int d)
        {
            if (x == null)
            {
                return InsertBefore(head, d);
            }
            else
            {
                Node newNode = new Node(d);
                Size += 1;
                if (x==tail)
                {
                    x.next = newNode;
                    newNode.rear = x;
                    newNode.next = null;
                    return newNode;
                }
                else
                {
                    return InsertBefore(x.next, d);
                }
            }
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

        public void Delete(Node x)
        {
            if (x == null)
                return;
            Size -= 1;
            if (x==head)
            {
                head = head.next;
                head.rear = null;
                return;
            }
            if(x==tail)
            {
                tail = tail.rear;
                tail.next = null;
                return;
            }
            x.rear.next = x.next;
            x.next.rear = x.rear;
            x.next = null;
            x.rear = null;
        }
        //remove add nodes contains d
        public void Delete(int d)
        {
            Node deletaNode = null;
            int deleteCount = 0;
            while (true)
            {
                deletaNode = Find(d);
                if (deletaNode == null)
                    break;
                deleteCount++;
                Delete(deletaNode);
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
                    Console.Write($"{cur.Data}<->");
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

        /// <summary>
        /// Use this for test!!!
        /// Test whether the DoubleLinkList is correctly builded!!!
        /// </summary>
        public void DisplayReverse()
        {
            Node cur = tail;
            Node next = tail.rear;
            while (true)
            {
                if (next != null)
                {
                    Console.Write($"{cur.Data}->");
                    cur = next;
                    next = next.rear;
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
            Node cur = head;
            Node next = head.next;
            cur.next = null;
            cur.rear = next;
            cur = next;
            next = next.next;
            while (true)
            {
                if (next == null)
                    break;
                cur.next = cur.rear;
                cur.rear = next;
                cur = next;
                next = next.next;
            }
            cur.next = cur.rear;
            cur.rear = null;
            cur = head;
            head = tail;
            tail = cur;
        }
    }
}
