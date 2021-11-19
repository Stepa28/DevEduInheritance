using System;

namespace DevEduInheritance.Creatures
{
    public abstract class Creature
    {
        private int _maxHp;
        private int _hp;

        public string Name  {get; set;}
        public bool   IsDie => _hp == 0;
        public int Hp
        {
            get => _hp;
            set
            {
                if ((value <= 500 || value <= MaxHp) && value >= 0) _hp = value;
                else if (value < 0) _hp = 0;
                else
                    throw new Exception("Неверное количество здаровья");
            }
        }
        public int MaxHp
        {
            get => _maxHp;
            set
            {
                if (value <= 500 && value >= 0) _maxHp = value;
                else throw new Exception("Неверное количество максимального здаровья");
            }
        }
        

        public abstract void Wounds(int damage);
    }
}