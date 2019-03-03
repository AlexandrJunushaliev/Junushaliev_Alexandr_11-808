using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graham
{
    public class MyLinkedListNode<T>
    {
        ///
        /// Конструктор нового узла со значением Value.
        ///
        public MyLinkedListNode(T value)
        {
            Value = value;
        }

        ///
        /// Поле Value.
        ///
        public T Value { get; internal set; }

        ///
        /// Ссылка на следующий узел списка (если узел последний, то null).
        ///
        public MyLinkedListNode<T> Next { get; internal set; }
        public MyLinkedListNode<T> Previous { get; internal set; }
    }
    class MyLinkedList<T>:IEnumerable<MyLinkedListNode<T>>
    {
        private MyLinkedListNode<T> _head;
        private MyLinkedListNode<T> _tail;
        int count;
        public int Count { get { return count; } }
        public void AddFirst(T value)
        {
            MyLinkedListNode<T> node = new MyLinkedListNode<T>(value);

            // Сохраняем ссылку на первый элемент.
            MyLinkedListNode<T> temp = _head;

            // _head указывает на новый узел.
            _head = node;

            // Вставляем список позади первого элемента.
            _head.Next = temp;

            if (Count == 0)
            {
                // Если список был пуст, то head and tail должны
                // указывать на новой узел.
                _tail = _head;
            }
            else
            {
                // До:    head -------> 5  7 -> null
                // После: head  -> 3  5  7 -> null
                temp.Previous = _head;
            }

            count++;
        }
        public void AddLast(T value)
        {
            MyLinkedListNode<T> node = new MyLinkedListNode<T>(value);

            if (Count == 0)
            {
                _head = node;
            }
            else
            {
                _tail.Next = node;

                // До:    Head -> 3  5 -> null
                // После:Head -> 3  5  7 -> null
                // 7.Previous = 5
                node.Previous = _tail;
            }

            _tail = node;
            count++;
        }
        public void RemoveFirst()
        {
            if (Count != 0)
            {
                // До:    Head -> 3  5
                // После: Head -------> 5

                // Head -> 3 -> null
                // Head ------> null
                _head = _head.Next;

                count--;

                if (Count == 0)
                {
                    _tail = null;
                }
                else
                {
                    // 5.Previous было 3; теперь null.
                    _head.Previous = null;
                }
            }
        }
        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    _head = null;
                    _tail = null;
                }
                else
                {
                    // До:    Head --> 3 --> 5 --> 7
                    //        Tail = 7
                    // После: Head --> 3 --> 5 --> null
                    //        Tail = 5
                    // Обнуляем 5.Next
                    _tail.Previous.Next = null;
                    _tail = _tail.Previous;
                }

                count--;
            }
        }
        public bool Remove(T item)
        {
            MyLinkedListNode<T> previous = null;
            MyLinkedListNode<T> current = _head;

            // 1: Пустой список: ничего не делать.
            // 2: Один элемент: установить Previous = null.
            // 3: Несколько элементов:
            //    a: Удаляемый элемент первый.
            //    b: Удаляемый элемент в середине или конце.

            while (current != null)
            {
                // Head -> 3 -> 5 -> 7 -> null
                // Head -> 3 ------> 7 -> null
                if (current.Value.Equals(item))
                {
                    // Узел в середине или в конце.
                    if (previous != null)
                    {
                        // Случай 3b.
                        previous.Next = current.Next;

                        // Если в конце, то меняем _tail.
                        if (current.Next == null)
                        {
                            _tail = previous;
                        }
                        else
                        {
                            // До:    Head -> 3  5  7 -> null
                            // После: Head -> 3  7 -> null

                            // previous = 3
                            // current = 5
                            // current.Next = 7
                            // Значит... 7.Previous = 3
                            current.Next.Previous = previous;
                        }

                        count--;
                    }
                    else
                    {
                        // Случай 2 или 3a.
                        RemoveFirst();
                    }

                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public IEnumerator<MyLinkedListNode<T>> GetEnumerator()
        {
            var currentNode = _head;
            while (currentNode.Next != null)
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
        public MyLinkedListNode<T> First()
        {
            return _head;
        }
    }
}
    


