using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace yield
{
    public class LinkedListNode
    {
        public LinkedListNode(double value)
        {
            Value = value;
        }

        public double Value { get; internal set; }
        public LinkedListNode Next { get; internal set; }
        public LinkedListNode Previous { get; internal set; }
        public int Number { get; set; }
    }

    public class LinkedList
    {
        LinkedListNode head;
        LinkedListNode tail;
        int count;
        int number=0;
        public int Count { get { return count; } }

        public void AddFirst(double value)
        {
            LinkedListNode node = new LinkedListNode(value) { Number = number+1 };
            number++;
            LinkedListNode temp = head;
            head = node;
            head.Next = temp;

            if (Count == 0)
            {
                tail = head;
            }
            else
            {
                temp.Previous = head;
            }
            count++;
        }

        public void AddLast(double value)
        {
            LinkedListNode node = new LinkedListNode(value);

            if (Count == 0)
            {
                head = node;
            }
            else
            {
                tail.Next = node;            
                node.Previous = tail;
            }
            tail = node;
            count++;
        }

        public void RemoveFirst()
        {
            if (Count != 0)
            {
                head = head.Next;
                count--;
                if (Count == 0)
                {
                    tail = null;
                }
                else
                {
                    head.Previous = null;
                }
            }
        }

        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    head = null;
                    tail = null;
                }
                else
                {
                    tail.Previous.Next = null;
                    tail = tail.Previous;
                }

                count--;
            }
        }

        public LinkedListNode SightBottom()
        {
            return tail;
        }

        public LinkedListNode Peek()
        {
            return head;
        }
    }

    public static class MovingMaxTask
    {
        public static IEnumerable<DataPoint> MovingMax(this IEnumerable<DataPoint> data, int windowWidth)
        {
            long count=0;
            var linkedList = new LinkedList();
            foreach (var elem in data)
            {
                count++;
                if (linkedList.SightBottom() != null && linkedList.SightBottom().Number == count -windowWidth)
                {
                    linkedList.RemoveLast();
                }
                while (linkedList.Count != 0 && elem.OriginalY > linkedList.Peek().Value)
                    linkedList.RemoveFirst();
                linkedList.AddFirst(elem.OriginalY);
                elem.MaxY = linkedList.SightBottom().Value;
                yield return elem;
            }
        }                        
    }
}