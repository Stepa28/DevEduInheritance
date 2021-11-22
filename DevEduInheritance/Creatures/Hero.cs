using System;

namespace DevEduInheritance.Creatures
{
    public class Hero : Humanoid, ICombatan
    {
        private readonly Random _rnd = new();
        private          int    _minAttack;
        private          int    _maxAttack;

        public int MinAttack
        {
            get => _minAttack;
            set
            {
                if (value <= 20 && value >= 0)
                    _minAttack = value;
                else
                    throw new AggregateException("Недоступное значение минимальной атаки");
            }
        }
        public int MaxAttack
        {
            get => _maxAttack;
            set
            {
                if (value <= 100 && value >= 30)
                    _maxAttack = value;
                else
                    throw new AggregateException("Недоступное значение максимальной атаки");
            }
        }


        public int GetAttack(int bonus)
        {
            return _rnd.Next(_minAttack, _maxAttack + 1) + bonus;
        }


        public Hero() { }

        public Hero(string name, RaceType raceType, int maxHp, int intellect, int minAttack, int maxAttack)
            : base(name, raceType, maxHp, intellect)
        {
            MinAttack = minAttack;
            MaxAttack = maxAttack;
        }
    }
}