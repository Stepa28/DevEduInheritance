using System;
using System.Collections;
using System.Collections.Generic;
using DevEduInheritance.Creatures;

namespace DevEduInheritance.Inventors
{
    public class Inventory : IEnumerable
    {
        private int _roominess;
        private LinkedList<Item> _items;

        public Humanoid Owner { get; private set; }
        public int Size => _items.Count;
        public int Roominess => _roominess;

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
        
        

        public Inventory(Humanoid humanoid)
        {
            _roominess = 10;
            _items = new LinkedList<Item>();
            Owner = humanoid;
        }
        public Inventory(int roominess, Humanoid humanoid) : this(humanoid)
        {
            _roominess = roominess;
        }
    }
}