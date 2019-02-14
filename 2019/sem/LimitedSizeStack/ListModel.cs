using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;

namespace TodoApplication
{
    public interface ICommand<TItem>
    {
        void Execute();
        void Undo();
    }
    internal class AddItem<TItem> : ICommand<TItem>
    {
        TItem item;
        LimitedSizeStack<ICommand<TItem>> historyStack;
        List<TItem> items;
        internal AddItem(TItem item, LimitedSizeStack<ICommand<TItem>> historyStack, List<TItem> items)
        {
            this.item = item;
            this.historyStack = historyStack;
            this.items = items;
        }
        public void Execute()
        {
            items.Add(item);
            historyStack.Push(this);
        }

        public void Undo()
        {
            var undoCommand = new RemoveItem<TItem>(items.Count - 1, historyStack, items);
            undoCommand.Execute();
            historyStack.Pop();
        }
    }

    public class RemoveItem<TItem> : ICommand<TItem>
    {
        int index;
        TItem item;
        LimitedSizeStack<ICommand<TItem>> historyStack;
        List<TItem> items;
        public RemoveItem(int index, LimitedSizeStack<ICommand<TItem>> historyStack, List<TItem> items)
        {
            this.index = index;
            this.historyStack = historyStack;
            this.items = items;
        }
        public void Execute()
        {
            item = items[index];
            items.RemoveAt(index);
            historyStack.Push(this);
        }

        public void Undo()
        {
            var undoCommand = new AddItem<TItem>(item,historyStack,items);
            undoCommand.Execute();
            historyStack.Pop();
        }
    }

    public class ListModel<TItem>
    {
        public List<TItem> Items { get; }
        public int Limit;
        LimitedSizeStack<ICommand<TItem>> historyStack;
        public ListModel(int limit)
        {
            Items = new List<TItem>();
            Limit = limit;
            historyStack = new LimitedSizeStack<ICommand<TItem>>(limit);
        }

        public void AddItem(TItem item)
        {
            var command = new AddItem<TItem>(item, historyStack, Items);
            command.Execute();
        }

        public void RemoveItem(int index)
        {
            var command = new RemoveItem<TItem>(index, historyStack, Items);
            command.Execute();
        }

        public bool CanUndo()
        {
            return historyStack.Count != 0;
        }

        public void Undo()
        {
            if(CanUndo())
            {
                var undoCommand = historyStack.Pop();
                undoCommand.Undo();
            }        
        }
    }
}
