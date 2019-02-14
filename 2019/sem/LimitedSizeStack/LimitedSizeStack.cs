using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApplication
{
    public class LimitedSizeNode<T>
    {
        public LimitedSizeNode(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
        public LimitedSizeNode<T> Next { get; set; }
        public LimitedSizeNode<T> Previous { get; set; }
    }
    public class LimitedSizeStack<T>
    {
        int limit;
        int count;
        LimitedSizeNode<T> head;
        LimitedSizeNode<T> tail;
        public LimitedSizeStack(int limit)
        {
            this.limit = limit;
        }

        public void Push(T item)
        {
            if (Count == limit)
            {
                RemoveLast();
            }
            var node = new LimitedSizeNode<T>(item);
            var temp = head;
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

        public T Pop()
        {
            if (Count != 0)
            {
                var temp = head;
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
                return temp.Value;
            }
            else throw new Exception();
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
        public LimitedSizeNode<T> Peek()
        {
            return head;
        }
        public int Count
        {
            get
            {
                return count;
            }
        }
    }
}
