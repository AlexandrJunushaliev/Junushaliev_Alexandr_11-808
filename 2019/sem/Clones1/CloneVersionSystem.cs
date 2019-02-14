using System;
using System.Collections.Generic;

namespace Clones
{
    //класс записи для стека. запись включает в себя то, 
    //что помещаем в стек и ссылку на следущющую запись,
    //стоящуюю в стеке после нее(следующую на выход)
    public class Node
    {
        public Node(string data)
        {
            Data = data;
        }

        public string Data { get; set; }
        public Node Next { get; set; }
    }
    //сам класс стека
    public class Stack
    {
        //два конструктора: один для клонирования, 
        //другой для простого создания "пустого" стека
        //(в каждом стеке будет первый элемент basic)
        public Stack(Stack stack)
        {
            head = stack.head;
        }

        public Stack()
        {
            head = new Node("basic");
        }

        Node head;//поле головы стека
                  //метод добавления в стек
        public void Push(string item)
        {
            Node node = new Node(item);
            node.Next = head;
            head = node;
        }
        //метод удаления из стека элемента и возвращения его значения
        public string Pop()
        {
            Node temp = head;
            head = head.Next;
            return temp.Data;
        }
        //метод получения значения головы стека без удаления
        public string Peek()
        {
            return head.Data;
        }
    }
    //класс клона
    public class Clone
    {   //два конструктора: для простого создания и для клонирования
        public Clone()
        {
            learnedStack = new Stack();
            removedStack = new Stack();
        }

        public Clone(Stack learnedStack, Stack removedStack)
        {
            this.learnedStack = new Stack(learnedStack);
            this.removedStack = new Stack(removedStack);
        }
        //поля выученных и удаленных программ
        Stack learnedStack;
        Stack removedStack;
        public string Learn(string command)
        {
            learnedStack.Push(command);
            return null;
        }

        public string Rollback()
        {
            removedStack.Push(learnedStack.Pop());
            return null;
        }

        public string Relearn()
        {
            learnedStack.Push(removedStack.Pop());
            return null;
        }

        public Clone CopyClone()
        {
            return new Clone
            (learnedStack, removedStack);
        }

        public string Check()
        {
            return learnedStack.Peek().ToString();
        }
    }

    public class CloneVersionSystem : ICloneVersionSystem
    {
        public List<Clone> ClonesList = new List<Clone>() { new Clone() };

        public string Execute(string query)
        {//обработка комманды, поданной на вход
            var command = query.Split(' ');
            if (command[0] == "learn")
            {
                return ClonesList[int.Parse(command[1]) - 1].Learn(command[2]);
            }
            if (command[0] == "rollback")
            {
                return ClonesList[int.Parse(command[1]) - 1].Rollback();
            }
            if (command[0] == "relearn")
            {
                return ClonesList[int.Parse(command[1]) - 1].Relearn();
            }
            if (command[0] == "clone")
            {
                ClonesList.Add(ClonesList[int.Parse(command[1]) - 1].CopyClone());
                return null;
            }
            if (command[0] == "check")
            {
                return ClonesList[int.Parse(command[1]) - 1].Check();
            }
            return null;
        }
    }
}
