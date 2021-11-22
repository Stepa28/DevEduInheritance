using System;

namespace DevEduInheritance.Inventors
{
    public class Item
    {
        private int _cost;
        private int _weight;

        public string   Name     {get; set;}
        public ItemType ItemType {get; set;}
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

        public string ItemText =>
            ItemType switch
            {
                ItemType.Gloves       => "перчатки",
                ItemType.Head         => "шлем",
                ItemType.Pants        => "штаны",
                ItemType.Potion       => "зелье",
                ItemType.Scrolls      => "свиток",
                ItemType.Shield       => "щит",
                ItemType.Torso        => "нагрудник",
                ItemType.Weapon       => "оружие",
                ItemType.ShoulderPads => "наплечники",
                _                     => throw new Exception("Неизвестный тип предмета")
            };


        public Item() { }
        public Item(string name, ItemType itemType, int cost, int weight) =>
            (Name, ItemType, Cost, Weight) = (name, itemType, cost, weight);
    }
}