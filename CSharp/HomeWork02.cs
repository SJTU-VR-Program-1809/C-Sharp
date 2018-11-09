using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeProgram
{
    class Node<T>//T for which type
    {
        public T data;
        public Node<T> next = null;
        public Node()
        { }
        public Node(T i)
        {
            this.data = i;
        }
    }
    class LinkList<T>
    {
        private Node<T> head;
        public LinkList()
        {
            head = null;
        }

        public int count()//a count for linklist
        {
            Node<T> p = head;
            int count = 0;
            while (p != null)
            {
                count++;
                p = p.next;
            }
            return count;
        }
        /// <summary>
        /// get a node
        /// </summary>
        /// <param name="i">i node</param>
        /// <returns></returns>
        public T GetItem(int i)
        {
            Node<T> p = head;
            int k = 0;
            if (i > count() || i < 0)
            {
                Console.WriteLine("i is null");
            }
            while (k < i)
            {
                k++;
                p = p.next;
            }
            return p.data;
        }
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="e"></param>
        /// <param name="i"></param>
        public void Insert(T e, int i)
        {
            Node<T> p = new Node<T>(e);
            Node<T> q = head;
            int k = 0;
            if (i == 0)
            {
                p.next = head;
                head = p;
                return;
            }
            while (k < i - 1)
            {
                k++;
                q = q.next;
            }
            p.next = q.next;
            q.next = p;
        }
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="i"></param>
        public void Add(T i)
        {
            Node<T> p = new Node<T>(i);//insert node
            Node<T> q = new Node<T>();
            //if head==null ,the head is p
            if (head == null)
            {
                head = p;
                return;
            }
            #region if head!=null,get the last node
            q = head;
            while (q.next != null)
            {
                q = q.next;
            }
            q.next = p;
            #endregion 

        }
        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="i"></param>
        public void RemoveAt(int i)
        {
            Node<T> p = head;
            int k = 0;
            if (i > count() || i < 0)
            {
                Console.WriteLine("Error");
            }
            if (i == 0)
            {
                head.next = head.next.next;
                return;
            }
            while (k < i - 1)
            {
                k++;
                p = p.next;
            }
            p.next = p.next.next;
        }
      

        /// <summary>
        /// isEmpty
        /// </summary>
        /// <returns></returns>
        public bool Empty()
        {
            return head == null ? true : false;
        }
        /// <summary>
        /// clear
        /// </summary>
        public void Clear()
        {
            head = null;
        }

        public void ToArrary()
        {
            T[] arr = new T[count()];
            Node<T> p = head;
            int i = 0;
            while (p != null)
            {
                arr[i++] = p.data;
                p = p.next;
            }
            for (int j = 0; j < count(); j++)
            {
                Console.Write(arr[j] + " ");
            }
        }

        /// <summary>
        /// remove a node which you chose
        /// </summary>
        /// <param name="e"></param>
        public void Remove(T e)
        {
            if (head.data.Equals(e))
            {
                head = head.next;
            }
            Node<T> p = head;
            while (p.next.next != null)
            {
                if (p.next.data.Equals(e))
                {
                    p.next = p.next.next;
                    continue;
                }
                p = p.next;
            }
            if (p.next.data.Equals(e))
            {
                p.next = null;
            }
        }
        /// <summary>
        /// Reverse
        /// </summary>
        public void Reverse()
        {
            Node<T> p = head;
            Node<T> q = p;
            Node<T> newHead = head;
            p = p.next;
            newHead.next = null;
            while (p.next != null)
            {
                q = p;
                p = p.next;
                q.next = newHead;
                newHead = q;
            }
            q = p;
            q.next = newHead;
            newHead = q;
            head = newHead;
        }
        /// <summary>
        /// print
        /// </summary>
        public void PrintLinkList()
        {
            Node<T> p = head;
            while (p != null)
            {
                Console.Write(p.data + " ");
                p = p.next;
            }
        }
    }
}
