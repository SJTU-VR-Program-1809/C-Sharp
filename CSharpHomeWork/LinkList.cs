using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LinkList
{
    private Node head = new Node();
    
    public class Node
    {
        public int data;
        public Node next;
        public Node(int i=0)
        {
            data = i;
        }
    }
    public int Size { get; }
    public LinkList(params int[] nums)
    {
        
        if (nums ==null)
        {
            Console.WriteLine("链表为空");
            return;
        }
        head.next = new Node(nums[0]);
        Node p = head.next;
       for (int i = 1; i < nums.Length; i++)
       {
            p.next = new Node(nums[i]);
            p = p.next;
       }
        Size = nums.Length;
    }
    //if x is null, insert d as first node
    public Node InsertBefore(Node x, int d)
    {
        Node p = new Node();
        p = head;
        while ( p.next!= x)
         {
            p = p.next;
         }
        x.next = p.next;
        p.next = x;
        x.data= d;
        //Console.WriteLine(x.next.data);
        return p;
    }
    public Node Insertafter(Node x, int d)
    {
        Node p = new Node();
        p = head.next;
        while (p!= x)
         {
            p = p.next;
         }
        x.next = p.next;
        p.next = x;
        x.data = d;
        return p;
    }
    public Node Find(int d)
    {
        Node p = head;
        while (p.data!= d)
         {
            p = p.next;
        }
        return p;
    }
    public void Delete(Node x)
    {
        Node p = head;
        while (p.next!= x)
         {
            p = p.next;
         }
        p.next = x.next;
        x.next = null;
    }
    //remove all nodes contain d
    public void Delete(int d)
    {
        Node p = head;
        while (p!= null)
        {
            p = p.next;
            if (p.data == d)
                p.data = 0;
        }
    }
    public void Display()
    {
        Console.WriteLine("链表如下：");
        Node p = head.next;
        if (p == null)
        {
            Console.WriteLine("这是一个空链表");
            return;
        }
        while (p!= null)
        {
            Console.Write(p.data);
            p = p.next;
        }
    }
        //翻转public LinkList Reverse();
 }

