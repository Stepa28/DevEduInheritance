using System;

namespace DevEduInheritance.Creatures
{
    public abstract class Creature
    {
        private readonly int _maxHp;
        private          int _hp;

        public string Name  {get; init;}
        public bool   IsDie => _hp == 0;
        public int Hp
        {
            get => _hp;
            set
            {
                if ((value <= 500 || value <= MaxHp) && value >= 0) _hp = value;
                else if (value < 0) _hp = 0;
                else
                    throw new Exception("Неверное количество здоровья");
            }
        }
        public int MaxHp
        {
            get => _maxHp;
            init
            {
                if (value <= 500 && value >= 0) _maxHp = value;
                else throw new Exception("Неверное количество максимального здоровья");
            }
        }


        public abstract void Wounds(int damage);
    }
}