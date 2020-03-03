using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyWeb
{
    public abstract class Storage<T>
    {
        
        //как правильно сделать: хранить элементы и отдельно метод на загрузку
        //или возвращать коллекцию при использовании метода?
        private List<T> _items;

        public List<T> Items
        {
            get
            {
                LoadAll();
                return _items;
            }
            set => _items = value;
        }

        public abstract void LoadAll();
        public abstract void Save(T entry);
        public abstract void Delete(T entry);
        public abstract void Update(T updatedEntry,T newEntry);
    }
}