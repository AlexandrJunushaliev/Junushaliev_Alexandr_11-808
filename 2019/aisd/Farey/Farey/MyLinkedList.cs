using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farey
{
    class MyLinkedListNode<T>
    {
        public T Value { get; set; }
        public MyLinkedListNode<T> Next { get; set; }
        public MyLinkedListNode<T> Previous { get; set; }
        public MyLinkedListNode(T item)
        {
            Value = item;
        }
    }
    class MyLinkedList<T>:IEnumerable<MyLinkedListNode<T>>
    {
        int count;
        MyLinkedListNode<T> first;
        MyLinkedListNode<T> last;
        public int Count { get { return count; } }
        public void AddFirst(T item)
        {
            MyLinkedListNode<T> node = new MyLinkedListNode<T>(item);
            MyLinkedListNode<T> temp = first;
            first = node;
            first.Previous = temp;
            if (Count == 0)
            {
                last = first;
            }
            else
            {
                temp.Next = first;
            }
            count++;
        }

        public IEnumerator<MyLinkedListNode<T>> GetEnumerator()
        {
            var currentNode = last;
            while(currentNode.Next!=null)
            {
                yield return currentNode;
                currentNode = currentNode.Next;
            }
            yield return currentNode;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<MyLinkedListNode<T>> IEnumerable<MyLinkedListNode<T>>.GetEnumerator()
        {
            return GetEnumerator();
        }

        public MyLinkedListNode<T> Last
        {
            get { return last; }
        }
        public MyLinkedListNode<T> First
        {
            get{ return first; }
        }
    }
}
