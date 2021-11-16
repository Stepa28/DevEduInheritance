using System;
using System.Security.Cryptography;

namespace DevEduInheritance
{
    public class Item
    {
        private int _cost;
        private int _weight;
        
        public string Name { get; set; }
        public ItemType ItemType { get; set; }
        public int Cost
        {
            get => _cost;
            set
            {
                if (value < 0)
                    throw new AggregateException("Цена должна быть не отрицательной");
                _cost = value;
            }
        }
        public int Weight
        {
            get => _weight;
            set
            {
                if (value < 0)
                    throw new AggregateException("Вес должен быть не отрицательной");
                _weight = value;
            }
        }
        
        
        
        public Item(){}

        public Item(string name, ItemType itemType, int cost, int weight) =>
            (Name, ItemType, Cost, Weight) = (name, itemType, cost, weight);
    }
}