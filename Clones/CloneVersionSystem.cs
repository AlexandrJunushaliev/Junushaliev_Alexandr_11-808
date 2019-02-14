using System;
using System.Collections.Generic;

namespace Clones
{
    public class Program<T>
    {
        public Program(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Program<T> Next { get; set; }
    }
    public class ProgramsStack<T>
    {
        public ProgramsStack() { }
        public ProgramsStack(ProgramsStack<T> stack)
        {
            var temporaryStack = new ProgramsStack<T>();
            while (stack.Count != 0)
            {
                temporaryStack.Push(stack.Peek());
                stack.Pop();
            }
            while (temporaryStack.Count != 0)
            {
                Push(temporaryStack.Peek());
                stack.Push(temporaryStack.Pop());
            }
            temporaryStack = null;


        }

        Program<T> head;
        int count;

        public bool IsEmpty
        {
            get { return count == 0; }
        }
        public int Count
        {
            get { return count; }
        }

        public void Push(T item)
        {
           
            // увеличиваем стек
            Program<T> node = new Program<T>(item);
            node.Next = head; // переустанавливаем верхушку стека на новый элемент
            head = node;
            count++;
        }
        public T Pop()
        {
            // если стек пуст, выбрасываем исключение
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст");
            Program<T> temp = head;
            head = head.Next; // переустанавливаем верхушку стека на следующий элемент
            count--;
            return temp.Data;
        }
        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст");
            return head.Data;
        }
    }
    public class Clone
    {
        public Clone()
        {
            LearnedStack = new ProgramsStack<string>();
            RemovedStack = new ProgramsStack<string>();
        }
        public Clone(ProgramsStack<string> learnedStack, ProgramsStack<string> removedStack)
        {
            LearnedStack = new ProgramsStack<string>(learnedStack);
            RemovedStack = new ProgramsStack<string>(removedStack);
        }
        public ProgramsStack<string> LearnedStack;
        public ProgramsStack<string> RemovedStack;
    }
    public class CloneVersionSystem : ICloneVersionSystem
    {
        public List<Clone> clonesList = new List<Clone>() { new Clone() };
        public string Execute(string query)
        {

            var command = query.Split(' ');
            if (string.Compare(command[0], "learn") == 0)
            {
                clonesList[int.Parse(command[1]) - 1].LearnedStack.Push(command[2]);
                return null;
            }
            if (string.Compare(command[0], "rollback") == 0 && clonesList[int.Parse(command[1])-1].LearnedStack.Count != 0)
            {
                clonesList[int.Parse(command[1]) - 1].RemovedStack.Push(clonesList[int.Parse(command[1]) - 1].LearnedStack.Pop());                
                return null;
            }
            if (string.Compare(command[0], "relearn") == 0 && clonesList[int.Parse(command[1]) - 1].RemovedStack.Count != 0)
            {
                clonesList[int.Parse(command[1]) - 1].LearnedStack.Push(clonesList[int.Parse(command[1]) - 1].RemovedStack.Pop());
                return null;
            }
            if (string.Compare(command[0], "clone") == 0)
            {
                clonesList.Add(new Clone(clonesList[int.Parse(command[1]) - 1].LearnedStack, clonesList[int.Parse(command[1]) - 1].RemovedStack));
                return null;
            }
            if (string.Compare(command[0], "check") == 0)
            {
                if (clonesList[int.Parse(command[1]) - 1].LearnedStack.Count==0)
                {
                    return "basic";
                }
                else
                {
                    return clonesList[int.Parse(command[1]) - 1].LearnedStack.Peek().ToString();
                }
            }
            return null;
        }
    }
}
