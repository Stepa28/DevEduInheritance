using System;
using System.Collections;
using System.Collections.Generic;

namespace DevEduInheritance
{
    public class Inventar : IEnumerable
    {
        // владелиц
        
        private int _roominess;
        private LinkedList<Item> _items;

        public int Size { get => _items.Count; }
        public int Roominess { get => _roominess; }

        public void Add(Item item)
        {
            if (Size >= _roominess)
                throw new AggregateException("Инвентарь переполнен");
            _items.AddLast(item);
        }

        public bool Remove(Item item)
        {
            return _items.Remove(item);
        }

        public bool Contains(Item item)
        {
            return _items.Contains(item);
        }
        
        public IEnumerator GetEnumerator()
        {
            return _items.GetEnumerator();
        }
        
        

        public Inventar()
        {
            _roominess = 10;
            _items = new LinkedList<Item>();
        }

        public Inventar(int roominess) : this()
        {
            _roominess = roominess;
        }
    }
}