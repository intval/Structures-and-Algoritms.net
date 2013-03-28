using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LockFreeStack
{
    public class Stack
    {
        private Node head;

        public void Push(int n)
        {
            Node newNode = new Node(n);
            Node curHead;

            do 
            {
                curHead = head;
            } 
            while(curHead != Interlocked.CompareExchange(ref head, newNode, curHead));

            newNode.next = curHead;
        }

        public int Pop()
        {
            Node retNode;

            do
            {
                retNode = head;
            }
            while(head != Interlocked.CompareExchange(ref head, head.next, retNode));

            if (null == retNode)
                throw new NullReferenceException();
            else
                return retNode.value;
        }
    }

    class Node
    {
        public int value;
        public Node next;

        public Node(int val)
        {
            this.value = val;
        }
    }
}
